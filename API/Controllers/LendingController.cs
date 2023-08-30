using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.Views;
using Core.Interfaces;
using CsvHelper;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Formats.Asn1;
using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text.Json;

namespace API.Controllers
{
    public class LendingController : BaseApiController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private InfileServiceReference.WsINFILESoapClient invoiceSoap = new InfileServiceReference.WsINFILESoapClient(new BasicHttpsBinding(BasicHttpsSecurityMode.Transport), new EndpointAddress("https://ws-infile.octtopro.com/WsINFILE.asmx"));
        //private ServiceReferenceCM.MensajesSoapClient mensajesSoap = new ServiceReferenceCM.MensajesSoapClient(new BasicHttpsBinding(BasicHttpsSecurityMode.Transport), new EndpointAddress("https://cm.t4mgo.com/cm_mensajes/mensajes.asmx"));

        public LendingController(ApplicationDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost()]
        public async Task<ActionResult<IEnumerable<object>>> CreateLending(CreateLendingDto createLendingDto)
        {
            int result;

            var entidad = new Entidad
            {
                TipoEntidadId = createLendingDto.TipoEntidad
            };

            _unitOfWork.Repository<Entidad>().Add(entidad);
            result = await _unitOfWork.Complete();
            if (result < 0) return null!;

            if (createLendingDto.CreatePersonDto is not null)
            {
                var persona = _mapper.Map<Persona>(createLendingDto.CreatePersonDto);
                persona.EntidadId = entidad.Id;

                _unitOfWork.Repository<Persona>().Add(persona);
            }

            if (createLendingDto.CreateCompanyDto is not null)
            {
                var empresa = _mapper.Map<Empresa>(createLendingDto.CreateCompanyDto);
                empresa.EntidadId = entidad.Id;

                _unitOfWork.Repository<Empresa>().Add(empresa);
            }

            var relacionEntidades = new RelacionEntidad
            {
                TipoRelacionId = 1,
                EntidadPadreId = 1,
                EntidadHijaId = entidad.Id
            };

            _unitOfWork.Repository<RelacionEntidad>().Add(relacionEntidades);

            createLendingDto.EntidadPrestamoId = entidad.Id;

            createLendingDto.TasaInteres = createLendingDto.TasaInteres / 100.0m;
            createLendingDto.TasaMora = createLendingDto.TasaMora / 100.0m;
            createLendingDto.TasaIva = createLendingDto.TasaIva / 100.0m;

            var prestamo = _mapper.Map<Prestamo>(createLendingDto);

            _unitOfWork.Repository<Prestamo>().Add(prestamo);

            result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ListadoGeneral>>> GetLendings()
        {
            return await _dbContext.Set<ListadoGeneral>().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<object>> GetLendingById(int id)
        {
            var entidadId = await _dbContext.Prestamos.Where(p => p.Id == id).Select(p => p.EntidadPrestamoId).FirstOrDefaultAsync();

            var tipoEntidadId = await _dbContext.Entidades.Where(e => e.Id == entidadId).Select(e => e.TipoEntidadId).FirstOrDefaultAsync();

            var fechaPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == id && p.Aplicado == false).Select(x => x.FechaPago).FirstOrDefaultAsync();

            if (tipoEntidadId == 1)
            {
                var lendingP = await (from pre in _dbContext.Prestamos
                                      join ent in _dbContext.Entidades on pre.EntidadPrestamoId equals ent.Id
                                      join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                      where pre.Id == id
                                      select new
                                      {
                                          PrestamoId = pre.Id,
                                          PrestamoReferencia = pre.ReferenciaMigracion,
                                          PersonaId = per.Id,
                                          Nombres = $"{per.PrimerNombre} {per.SegundoNombre}",
                                          Apellidos = $"{per.PrimerApellido} {per.SegundoApellido}",
                                          DPI = per.NumeroDocumento,
                                          per.Direccion,
                                          per.NumeroTelefono,
                                          per.NIT,
                                          EstadoCivil = per.EstadoCivil.Nombre,
                                          EstadoPrestamo = pre.EstadoPrestamo.Nombre,
                                          AsesorId = pre.GestorPrestamoId,
                                          TipoPrestamoId = pre.TipoPrestamoId,
                                          TipoPrestamo = pre.TipoPrestamo.Nombre,
                                          MontoTotal = pre.MontoOtorgado,
                                          MontoTotalProyectado = pre.MontoTotalProyectado,
                                          Plazo = pre.Plazo,
                                          TasaInteres = pre.TasaInteres,
                                          TasaMora = pre.TasaMora,
                                          TasaIva = pre.TasaIva,
                                          FechaPlan = pre.FechaPlan,
                                          FechaAprobacion = pre.FechaAprobacion,
                                          FechaProximoPago = fechaPago.AddMonths(1),
                                          DiasMora = pre.DiasMora,
                                      }).ToListAsync();

                var agenteP = await (from pre in _dbContext.Prestamos
                                     join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                     join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                     where pre.Id == id
                                     select new
                                     {
                                         Nombre = per.PrimerNombre + " " + per.SegundoApellido,

                                     }).FirstOrDefaultAsync();

                var empresaPlanilla = await (from pre in _dbContext.Prestamos
                                             join ent in _dbContext.Entidades on pre.EmpresaPrestamoId equals ent.Id
                                             join emp in _dbContext.Empresas on ent.Id equals emp.EntidadId
                                             where pre.Id == id
                                             select new
                                             {
                                                 Nombre = emp.Nombre
                                             }).FirstOrDefaultAsync();

                return Ok(new { lendingP, agenteP, empresaPlanilla });
            }

            var lendingE = await (from pre in _dbContext.Prestamos
                                  join ent in _dbContext.Entidades on pre.EntidadPrestamoId equals ent.Id
                                  join emp in _dbContext.Empresas on ent.Id equals emp.EntidadId
                                  where pre.Id == id
                                  select new
                                  {
                                      PrestamoId = pre.Id,
                                      PrestamoReferencia = pre.ReferenciaMigracion,
                                      Nombre = emp.Nombre,
                                      emp.Direccion,
                                      emp.Telefono,
                                      emp.Email,
                                      emp.Nit,
                                      AsesorId = pre.GestorPrestamoId,
                                      TipoPrestamoId = pre.TipoPrestamoId,
                                      TipoPrestamo = pre.TipoPrestamo.Nombre,
                                      EstadoPrestamo = pre.EstadoPrestamo.Nombre,
                                      MontoTotal = pre.MontoOtorgado,
                                      MontoTotalProyectado = pre.MontoTotalProyectado,
                                      Plazo = pre.Plazo,
                                      TasaInteres = pre.TasaInteres,
                                      TasaMora = pre.TasaMora,
                                      TasaIva = pre.TasaIva,
                                      FechaPlan = pre.FechaPlan,
                                      FechaAprobacion = pre.FechaAprobacion,
                                      FechaProximoPago = fechaPago.AddMonths(1),
                                      DiasMora = pre.DiasMora
                                  }).ToListAsync();

            var agenteE = await (from pre in _dbContext.Prestamos
                                 join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                 join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                 where pre.Id == id
                                 select new
                                 {
                                     Nombre = per.PrimerNombre + " " + per.SegundoApellido,

                                 }).FirstOrDefaultAsync();

            return Ok(new { lendingE, agenteE });

        }

        [HttpGet("serbipagos/{idstr}")]
        public async Task<ActionResult<object>> GetCreditById(string idstr)
        {
            var totalCuota = 0.00m;

            int id;
            bool result = int.TryParse(idstr, out id);

            if (id == 0)
            {
                return new
                {
                    CodigoError = "04",
                    Mensaje = $"Error en Datos de identificador"
                };
            }

            var credito = await _dbContext.Prestamos.FirstOrDefaultAsync(x => x.Id == id);
            if (credito is null)
            {
                return new
                {
                    CodigoError = "01",
                    Mensaje = $"El identificador {id} no existe"
                };
            }

            if (credito.EstadoPrestamoId == 4)
            {
                return new
                {
                    CodigoError = "02",
                    Mensaje = $"El identificador {id} no se encuentra Vigente se encuentra en estado Cancelado"
                };
            }


            var totalSaldo = _dbContext.PlanPagos
                .Where(p => p.PrestamoId == id && p.FechaPago <= DateTime.Now)
                .Sum(p => p.SaldoCapital + p.SaldoIntereses + p.SaldoIvaIntereses + p.SaldoMora + p.SaldoIvaMora + p.SaldoGastos + p.SaldoIvaGastos);

            if (totalSaldo <= 0)
            {
                return new
                {
                    CodigoError = "03",
                    Mensaje = $"El identificador {id} no se encuentra Vigente se encuentra en estado Cancelado"
                };
            }
            


            //using (var context = _dbContext)
            //{
            //    var total = context.PlanPagos
            //        .Where(p => p.PrestamoId == 1075 && p.FechaPago <= DateTime.Now)
            //        .Sum(p => p.SaldoCapital + p.SaldoIntereses + p.SaldoIvaIntereses + p.SaldoMora + p.SaldoIvaMora + p.SaldoGastos + p.SaldoIvaGastos);
            //}
            //    total = context.PlanPagos
            //.Where(p => p.PrestamoId == 1075 && p.FechaPago <= DateTime.Now)
            //.Sum(p => p.SaldoCapital + p.SaldoIntereses + p.SaldoIvaIntereses + p.SaldoMora + p.SaldoIvaMora + p.SaldoGastos + p.SaldoIvaGastos);



            //if (totalSaldo == null)
            //{
            //    totalCuota = 0.00m;
            //}
            //else
            //{
            //    totalCuota = credit.SaldoCapital + credit.SaldoIntereses + credit.SaldoIvaIntereses + credit.SaldoMora + credit.SaldoIvaMora; 
            //}


            var entidadId = await _dbContext.Prestamos.Where(x => x.Id == id).Select(x => x.EntidadPrestamoId).FirstOrDefaultAsync();

            var nombre = await _dbContext.ListadoGeneral.Where(x => x.EntidadId == entidadId).Select(x => x.Nombre).FirstOrDefaultAsync();

            return new { nombre, totalSaldo };
        }

        [HttpGet("persona/{prestamoId}")]
        public async Task<ActionResult<IReadOnlyList<object>>> GetPersonById(int prestamoId)
        {

            var lendingP = await (from pre in _dbContext.Prestamos
                                  join ent in _dbContext.Entidades on pre.EntidadPrestamoId equals ent.Id
                                  join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                  where pre.Id == prestamoId
                                  select new
                                  {
                                      PersonaId = per.Id,
                                      per.PrimerNombre,
                                      per.SegundoNombre,
                                      per.PrimerApellido,
                                      per.SegundoApellido,
                                      per.ApellidoCasada,
                                      per.FechaNacimiento,
                                      per.GeneroId,
                                      per.Email,
                                      DPI = per.NumeroDocumento,
                                      per.Direccion,
                                      per.Colonia,
                                      per.NumeroTelefono,
                                      per.NumeroCelular,
                                      per.NumeroTelefonoLaboral,
                                      per.NIT,
                                      per.PaisNacimientoId,
                                      per.DepartamentoId,
                                      per.MunicipioId,
                                      per.EstadoCivilId,
                                      pre.EstadoPrestamoId,
                                      EstadoPrestamo = pre.EstadoPrestamo.Nombre,
                                      AsesorId = pre.GestorPrestamoId,
                                      EmpresaPlanillaId = pre.EmpresaPrestamoId,
                                      per.DireccionLaboral,
                                      per.OcupacionId,
                                      per.Comentarios,
                                      TipoPrestamo = pre.TipoPrestamoId,
                                      pre.DiasMora,

                                  }).ToListAsync();

            return Ok(lendingP);
        }

        [HttpPut("persona/{prestamoId}")]
        public async Task<ActionResult<object>> PutPersonaById(int prestamoId, UpdatePersonLendingDto updatePersonLendingDto)
        {
            var prestamo = await _dbContext.Prestamos.Where(p => p.Id == prestamoId).FirstOrDefaultAsync();

            prestamo.GestorPrestamoId = updatePersonLendingDto.AsesorId;
            prestamo.EmpresaPrestamoId = updatePersonLendingDto.EmpresaPlanillaId;
            prestamo.TipoPrestamoId = updatePersonLendingDto.TipoPrestamoId;
            prestamo.EstadoPrestamoId = updatePersonLendingDto.EstadoPrestamoId;

            _unitOfWork.Repository<Prestamo>().Update(prestamo);

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            var persona = await _dbContext.Personas.Where(p => p.Id == updatePersonLendingDto.personId).FirstOrDefaultAsync();

            persona.PrimerNombre = updatePersonLendingDto.PrimerNombre;
            persona.SegundoNombre = updatePersonLendingDto.SegundoNombre;
            persona.PrimerApellido = updatePersonLendingDto.PrimerApellido;
            persona.SegundoApellido = updatePersonLendingDto.SegundoApellido;
            persona.ApellidoCasada = updatePersonLendingDto.ApellidoCasada;
            persona.FechaNacimiento = updatePersonLendingDto.FechaNacimiento;
            persona.GeneroId = updatePersonLendingDto.GeneroId;
            persona.Email = updatePersonLendingDto.Email;
            persona.NumeroDocumento = updatePersonLendingDto.NumeroDocumento;
            persona.Direccion = updatePersonLendingDto.Direccion;
            persona.Colonia = updatePersonLendingDto.Colonia;
            persona.TipoViviendaId = updatePersonLendingDto.TipoViviendaId;
            persona.NumeroTelefono = updatePersonLendingDto.NumeroTelefono;
            persona.NumeroCelular = updatePersonLendingDto.NumeroCelular;
            persona.NumeroTelefonoLaboral = updatePersonLendingDto.NumeroTelefonoLaboral;
            persona.NIT = updatePersonLendingDto.NIT;
            persona.EstadoCivilId = updatePersonLendingDto.EstadoCivilId;
            persona.PaisNacimientoId = updatePersonLendingDto.PaisNacimientoId;
            persona.DepartamentoId = updatePersonLendingDto.DepartamentoId;
            persona.MunicipioId = updatePersonLendingDto.MunicipioId;
            persona.OcupacionId = updatePersonLendingDto.OcupacionId;
            persona.DireccionLaboral = updatePersonLendingDto.DireccionLaboral;
            persona.Comentarios = updatePersonLendingDto.Comentarios;

            _unitOfWork.Repository<Persona>().Update(persona);

            result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            return Ok(new { message = "Acción realizada Satisfactoriamente" });

        }

        [HttpGet("saldos/{prestamoId:int}")]
        public async Task<ObtenerSaldosDto> GetSaldos(int prestamoId)
        {
            /** Aplicación de Mora **/
            var saldosPrestamo = await _dbContext.Prestamos.Where(p => p.Id == prestamoId).FirstOrDefaultAsync();

            var saldoCapital = saldosPrestamo.MontoOtorgado;
            var saldoInteres = saldosPrestamo.InteresProyectado;
            var saldoIvaInteres = saldosPrestamo.IvaProyectado;
            var saldoMora = 0.0m;
            var saldoIvaMora = 0.0m;
            var totalSaldo = saldoCapital + saldoInteres + saldoIvaInteres + saldoMora + saldoIvaMora;

            var pagoCapital = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == prestamoId && e.TipoTransaccionId == 8).SumAsync(e => e.Abono);
            var pagoInteres = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == prestamoId && e.TipoTransaccionId == 9).SumAsync(e => e.Abono);
            var pagoIvaInteres = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == prestamoId && e.TipoTransaccionId == 10).SumAsync(e => e.Abono);

            saldoCapital -= pagoCapital;
            saldoInteres -= pagoInteres;
            saldoIvaInteres -= pagoIvaInteres;

            var resultado = await _dbContext.SaldosMigracion(prestamoId).FirstOrDefaultAsync();

            if (resultado is not null)
            {
                saldoCapital = resultado.SaldoCapital;
                saldoInteres = resultado.SaldoInteres;
                saldoIvaInteres = resultado.SaldoIvaInteres;
                saldoMora = resultado.SaldoMora;
                saldoIvaMora = resultado.SaldoIvaMora;
                totalSaldo = resultado.SaldoCapital + resultado.SaldoInteres + resultado.SaldoIvaInteres + resultado.SaldoMora + resultado.SaldoIvaMora;
            }


            return new ObtenerSaldosDto
            { SaldoCapital = saldoCapital, SaldoIntereses = saldoInteres, SaldoIvaInteres = saldoIvaInteres, SaldoMora = saldoMora, SaldoIvaMora = saldoIvaMora, TotalSaldo = totalSaldo };

        }

        [HttpGet("plan_pago/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetPlanPago(int prestamoId)
        {
            return await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId).Select(p => new
            {
                p.PrestamoId,
                p.Periodo,
                p.CuotaCapital,
                p.CuotaIntereses,
                p.CuotaIvaIntereses,
                p.CuotaGastos,
                p.TotalCuota,
                p.SaldoTotal,
                p.FechaPago,
                p.Aplicado
            }).ToListAsync();

        }

        [HttpGet("saldos_plan_pago/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetSaldosPlanPago(int prestamoId)
        {
            return await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId).Select(p => new
            {
                p.PrestamoId,
                p.Periodo,
                p.SaldoCapital,
                p.SaldoIntereses,
                p.SaldoIvaIntereses,
                p.SaldoMora,
                p.SaldoIvaMora,
                SaldoTotal = p.SaldoCapital + p.SaldoIntereses + p.SaldoIvaIntereses + p.SaldoMora + p.SaldoIvaMora,
                p.FechaPago,
                p.Aplicado,
                planPagoId = p.Id
            }).ToListAsync();

        }

        [HttpGet("estado_cuenta/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetEstadoCuenta(int prestamoId)
        {
            return await _dbContext.EstadoCuentaPrestamos.Where(x => x.PrestamoId == prestamoId).ToListAsync();
        }

        [HttpGet("historial_pago/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetHIstorialPago(int prestamoId, string appUserId)
        {

            var entidadId = await _dbContext.Prestamos.Where(p => p.Id == prestamoId).Select(p => p.EntidadPrestamoId).FirstOrDefaultAsync();

            var tipoEntidadId = await _dbContext.Entidades.Where(e => e.Id == entidadId).Select(e => e.TipoEntidadId).FirstOrDefaultAsync();

            string deudor;

            if (tipoEntidadId == 1)
            {
                var deudorPersona = await (from pre in _dbContext.Prestamos
                                           join ent in _dbContext.Entidades on pre.EntidadPrestamoId equals ent.Id
                                           join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                           where pre.Id == prestamoId
                                           select new
                                           {
                                               Nombre = per.PrimerNombre + " " + per.PrimerApellido,
                                           }).FirstOrDefaultAsync();
                deudor = deudorPersona.Nombre;
            }
            else
            {
                var deudorEmpresa = await (from pre in _dbContext.Prestamos
                                           join ent in _dbContext.Entidades on pre.EntidadPrestamoId equals ent.Id
                                           join per in _dbContext.Empresas on ent.Id equals per.EntidadId
                                           where pre.Id == prestamoId
                                           select new
                                           {
                                               Nombre = per.Nombre,
                                           }).FirstOrDefaultAsync();
                deudor = deudorEmpresa.Nombre;
            }

            var usuario = await (from user in _dbContext.Users
                                 join per in _dbContext.Personas on user.PersonaId equals per.Id
                                 where user.Id == appUserId
                                 select new
                                 {
                                     Nombre = per.PrimerNombre + " " + per.PrimerApellido,
                                 }).FirstOrDefaultAsync();

            var gestor = await (from pre in _dbContext.Prestamos
                                join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                where pre.Id == prestamoId
                                select new
                                {
                                    Nombre = per.PrimerNombre + " " + per.PrimerApellido,
                                }).FirstOrDefaultAsync();

            return await _dbContext.RegistroCajas.Where(x => x.PrestamoId == prestamoId).Select(x => new
            {
                ReciboNo = x.Id,
                NombreDeudor = deudor,
                NombreUsuario = usuario.Nombre,
                NombreGestor = gestor.Nombre,
                FechaRecibo = DateTime.Now,
                Caja = x.Caja.Nombre,
                FechaTransaccion = x.FechaPago,
                TipoTranCapital = 8,
                Capital = x.MontoCapital,
                TipoTranIntereses = 9,
                Intereses = x.MontoInteres,
                TipoTranIvaIntereses = 10,
                Iva = x.MontoIvaIntereses,
                TipoTransaccionMora = 11,
                Mora = x.MontoMora,
                TipoTransaccionIvaMora = 12,
                IvaMora = x.MontoIvaMora,
                TipoTransaccionGastos = 13,
                Gastos = x.MontoGastos,
                TipoTransaccionIvaGastos = 14,
                IvaGastos = x.MontoIvaGastos,
                MontoPago = x.MontoPago,
                FormaPago = x.FormaPago.Nombre,
                NombreBanco = x.Banco.Nombre,
                Habilitado = x.Habilitado
            }).ToListAsync();
        }

        [HttpGet("distribuye_pago/{prestamoId:int}")]
        public async Task<DistribuyePagoDto> GetDistribuyePago(int prestamoId, decimal montoPago, DateTime fechaPago, bool aplicaMora = true)
        {
            decimal saldoMonto = montoPago;
            int diasMora = 0;
            decimal montoMora = 0.0m, montoIvaMora = 0.0m, montoIntereses = 0.0m, montoIvaIntereses = 0.0m, montoCapital = 0.0m, montoExcedente = 0.0m, capitalVencido = 0.0m,
                    cargoMontoMora = 0.0m, cargoMontoIvaMora = 0.0m;

            /** Plan de Pago Couta Vigente **/

            var planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId && p.Aplicado == false).FirstOrDefaultAsync();

            /** Se Calcula Mora si Existe **/
            var tasaMora = await _dbContext.Prestamos.Where(p => p.Id == prestamoId).Select(p => p.TasaMora).FirstOrDefaultAsync();

            if (aplicaMora == true)
            {
                //tasaMora = tasaMora / 100.00m;                

                diasMora = (int)(fechaPago - planPago.FechaPago).TotalDays;

                if (diasMora <= 0)
                {
                    diasMora = 0;
                }
            }


            var planesPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId && p.Aplicado == false).ToListAsync();



            foreach (var plan in planesPago)
            {
                var fechaReferencia = fechaPago.Date; //DateTime.Now.Date;               

                if (!aplicaMora)
                {
                    fechaReferencia = (plan.FechaCreacion == plan.FechaModificacion) ? plan.FechaCreacion.Date.AddDays(1) : plan.FechaCreacion.Date;
                }

                if (fechaReferencia.Date < plan.FechaModificacion)
                {
                    plan.CuotaMora = 0;
                    plan.SaldoMora = 0;
                    plan.CuotaIvaMora = 0;
                    plan.SaldoIvaMora = 0;
                    //plan.FechaModificacion = plan.FechaCreacion;
                    //plan.TotalCuota = plan.CuotaCapital + plan.CuotaIntereses + plan.CuotaIvaIntereses + plan.CuotaMora + plan.CuotaIvaMora;
                    _dbContext.Update(plan);
                    await _dbContext.SaveChangesAsync();
                }
                if (fechaReferencia > plan.FechaModificacion)
                {
                    plan.CuotaMora = 0;
                    plan.SaldoMora = 0;
                    plan.CuotaIvaMora = 0;
                    plan.SaldoIvaMora = 0;
                    //plan.TotalCuota = plan.CuotaCapital + plan.CuotaIntereses + plan.CuotaIvaIntereses + plan.CuotaMora + plan.CuotaIvaMora;
                    _dbContext.Update(plan);
                    await _dbContext.SaveChangesAsync();
                }


                if (plan.FechaPago <= fechaPago && plan.FechaModificacion.Date != fechaReferencia)
                {
                    var anio = plan.FechaPago.Year;
                    var mes = plan.FechaPago.Month;

                    int daysInMonth = DateTime.DaysInMonth(anio, mes);

                    //capitalVencido += plan.SaldoCapital; //* tasaMora;                
                    cargoMontoMora = plan.SaldoCapital * tasaMora / 365 * daysInMonth;
                    cargoMontoIvaMora = cargoMontoMora * 0.12m;
                    if (!aplicaMora) { plan.CuotaMora = 0; } else { plan.CuotaMora += cargoMontoMora; }
                    if (!aplicaMora) { plan.SaldoMora = 0; } else { plan.SaldoMora += cargoMontoMora; }
                    if (!aplicaMora) { plan.CuotaIvaMora = 0; } else { plan.CuotaIvaMora += cargoMontoIvaMora; }
                    if (!aplicaMora) { plan.SaldoIvaMora = 0; } else { plan.SaldoIvaMora += cargoMontoIvaMora; }
                    if (!aplicaMora) { plan.FechaModificacion = plan.FechaCreacion; } else { plan.FechaModificacion = fechaPago.Date; /*DateTime.Now;*/ }
                    //plan.TotalCuota = plan.CuotaCapital + plan.CuotaIntereses + plan.CuotaIvaIntereses + plan.CuotaMora + plan.CuotaIvaMora; 
                    _dbContext.Update(plan);
                    await _dbContext.SaveChangesAsync();
                }
            }

            var ultimaCuotaEnMora = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId
            && p.Aplicado == false && p.FechaPago <= fechaPago)
                                                                    .OrderByDescending(p => p.Id).FirstOrDefaultAsync();

            if (ultimaCuotaEnMora is not null)
            {
                diasMora = (int)(fechaPago - ultimaCuotaEnMora.FechaPago).TotalDays;

                cargoMontoMora = ultimaCuotaEnMora.SaldoCapital * tasaMora / 365 * diasMora;
                cargoMontoIvaMora = cargoMontoMora * 0.12m;
                if (!aplicaMora) { ultimaCuotaEnMora.CuotaMora = 0; } else { ultimaCuotaEnMora.CuotaMora = cargoMontoMora; }
                if (!aplicaMora) { ultimaCuotaEnMora.SaldoMora = 0; } else { ultimaCuotaEnMora.SaldoMora = cargoMontoMora; }
                if (!aplicaMora) { ultimaCuotaEnMora.CuotaIvaMora = 0; } else { ultimaCuotaEnMora.CuotaIvaMora = cargoMontoIvaMora; }
                if (!aplicaMora) { ultimaCuotaEnMora.SaldoIvaMora = 0; } else { ultimaCuotaEnMora.SaldoIvaMora = cargoMontoIvaMora; }
                if (!aplicaMora) { ultimaCuotaEnMora.FechaModificacion = ultimaCuotaEnMora.FechaCreacion; } else { ultimaCuotaEnMora.FechaModificacion = fechaPago.Date; }
                _dbContext.Update(ultimaCuotaEnMora);
                await _dbContext.SaveChangesAsync();
            }

            /** Pago Mora  **/
            if ((planPago.SaldoMora > 0 || planPago.SaldoIvaMora > 0) && saldoMonto <= (planPago.SaldoMora + planPago.SaldoIvaMora))
            {
                montoMora = (saldoMonto * 100) / 112;
                montoIvaMora = montoMora * 0.12m;
                saldoMonto = 0.0m;
            }
            else
            {
                montoIvaMora = planPago.SaldoIvaMora;
                saldoMonto -= montoIvaMora;
                montoMora = planPago.SaldoMora;
                saldoMonto -= planPago.SaldoMora;
            }

            /** Si el pago es mayor a la cuota **/
            if (saldoMonto > (planPago.SaldoCapital + planPago.SaldoIntereses + planPago.SaldoIvaIntereses))
            {
                montoExcedente = saldoMonto - (planPago.SaldoCapital + planPago.SaldoIntereses + planPago.SaldoIvaIntereses);
                saldoMonto = planPago.SaldoCapital + planPago.SaldoIntereses + planPago.SaldoIvaIntereses;
                foreach (var plan in planesPago)
                {
                    if (montoExcedente >= 0.01m && plan.Id > planPago.Id)
                    {
                        AbonarExcedente(plan.SaldoIvaMora, plan.SaldoMora, plan.SaldoIvaIntereses, plan.SaldoIntereses, plan.SaldoCapital, ref montoExcedente,
                            ref montoIvaMora, ref montoMora, ref montoIvaIntereses, ref montoIntereses, ref montoCapital);
                    }
                }
            }


            if (planPago.SaldoIntereses > 0.00m || planPago.SaldoIvaIntereses > 0.00m)
            {
                /** Pago Intereses **/
                if (planPago.SaldoIntereses > 0 && saldoMonto < planPago.SaldoIntereses)
                {
                    /** Se calcula IVA correspondiente **/
                    montoIntereses = (saldoMonto * 100) / 112;
                    montoIvaIntereses += montoIntereses * 0.12m;
                    saldoMonto = 0;
                }

                if (saldoMonto >= planPago.SaldoIntereses)
                {
                    saldoMonto -= planPago.SaldoIntereses;
                    montoIntereses += planPago.SaldoIntereses;
                }

                /** Pago Iva Intereses **/
                if (planPago.SaldoIvaIntereses > 0 && saldoMonto < planPago.SaldoIvaIntereses)
                {
                    montoIvaIntereses += saldoMonto;
                    saldoMonto = 0.0m;
                }
                if (saldoMonto >= planPago.SaldoIvaIntereses)
                {
                    saldoMonto -= planPago.SaldoIvaIntereses;
                    montoIvaIntereses += planPago.SaldoIvaIntereses;
                }
            }

            /** Cuota Capital **/
            if (planPago.SaldoCapital > 0 && saldoMonto < planPago.SaldoCapital)
            {
                montoCapital += saldoMonto;
                saldoMonto = 0.0m;
            }

            if (saldoMonto >= planPago.SaldoCapital)
            {
                saldoMonto -= planPago.SaldoCapital;
                montoCapital += planPago.SaldoCapital;
            }


            var EstadoCredito = await _dbContext.Prestamos.Where(p => p.Id == planPago.PrestamoId).Select(p => p.EstadoPrestamo.Nombre).FirstOrDefaultAsync();

            var getSaldos = await GetSaldos(prestamoId);
            var saldoTotal = getSaldos.TotalSaldo;

            var prestamo = await _dbContext.Prestamos.FirstOrDefaultAsync(x => x.Id == prestamoId);
            if (prestamo != null)
            {
                prestamo.DiasMora = diasMora;
                _dbContext.Update(prestamo);
                await _dbContext.SaveChangesAsync();
            }

            return (new DistribuyePagoDto
            {
                MontoPago = montoPago,
                PagoCapital = montoCapital,
                PagoCapitalAnticipado = 0.00m,
                PagoIntereses = montoIntereses,
                PagoIvaIntereses = montoIvaIntereses,
                PagoMora = montoMora,
                PagoIvaMora = montoIvaMora,
                TotalGastos = planPago.CuotaGastos,
                IvaGastos = planPago.CuotaIvaGastos,
                SaldoTotalPagar = saldoTotal,
                FechaProximoPago = planPago.FechaPago.AddMonths(1),
                DiasMora = diasMora,
                EstadoCredito = await _dbContext.Prestamos.Where(p => p.Id == planPago.PrestamoId).Select(p => p.EstadoPrestamo.Nombre).FirstOrDefaultAsync(),
                TotalCuotasVencidas = 0,
                CuotasVencidasPagadas = 0
            });
        }

        private decimal AbonarExcedente(decimal cuotaIvaMora, decimal cuotaMora, decimal cuotaIvaIntereses, decimal cuotaIntereses, decimal cuotaCapital, ref decimal montoExcedente, ref decimal montoIvaMora, ref decimal montoMora, ref decimal montoIvaIntereses, ref decimal montoIntereses, ref decimal montoCapital)
        {
            if (montoExcedente >= (cuotaMora + cuotaIvaMora))
            {
                montoIvaMora += cuotaIvaMora;
                montoMora += cuotaMora;
                montoExcedente -= cuotaIvaMora + cuotaMora;
            }
            else
            {
                montoMora = (montoExcedente * 100) / 112;
                montoIvaMora += montoMora * 0.12m;
                montoExcedente = 0;
            }

            if (montoExcedente >= (cuotaIntereses + cuotaIvaIntereses))
            {
                montoIvaIntereses += cuotaIvaIntereses;
                montoIntereses += cuotaIntereses;
                montoExcedente -= cuotaIvaIntereses + cuotaIntereses;
            }
            else
            {
                montoIntereses = (montoExcedente * 100) / 112;
                montoIvaIntereses += montoIntereses * 0.12m;
                montoExcedente = 0;
            }

            if (montoExcedente >= cuotaCapital)
            {
                montoCapital += cuotaCapital;
                montoExcedente -= cuotaCapital;
            }
            else if (montoExcedente > 0 && cuotaCapital > montoExcedente)
            {
                montoCapital += montoExcedente;
                montoExcedente = 0;
            }

            return montoExcedente;
        }

        [HttpPost("plan-pago-temporal")]
        public async Task<ActionResult<IEnumerable<object>>> CreatePaymentPlanTemporal(CreatePaymentPlanTemporalDto createPaymentPlanDto)
        {
            decimal
                principalAmount = createPaymentPlanDto.PrincipalAmount,
                interestRate = createPaymentPlanDto.InterestRate,
                administrativeExpensesRate = createPaymentPlanDto.AdministrativeExpesesRate,
                taxRate = createPaymentPlanDto.TaxRate,
                principalFee, interestFee, administrativeExpensesFee, taxFee, subTotalFee, totalFee, balance;

            int term = createPaymentPlanDto.Term;

            var fechaPago = /*new DateTime(createPaymentPlanDto.StartDate.Year, createPaymentPlanDto.StartDate.Month, 2)*/createPaymentPlanDto.PayDate;//.AddDays(-1);

            IEnumerable<DetallePlanPagoTemporal> projection = new List<DetallePlanPagoTemporal>();


            if (interestRate == 0)
            {
                interestFee = 0.0m;
                principalFee = principalAmount;
                administrativeExpensesFee = 0.0m;
                taxFee = 0.0m;
                subTotalFee = principalAmount;
                totalFee = principalAmount;
                balance = principalAmount;
            }
            else
            {
                //subTotalFee = await _dbContext.Prestamos.Select(
                //                            p => Scalars.CalculateFee(createPaymentPlanDto.PrincipalAmount, createPaymentPlanDto.InterestRate, createPaymentPlanDto.Term))
                //                    .FirstOrDefaultAsync();

                interestFee = principalAmount * interestRate /*(interestRate * 0.01m)*/ / 12;
                principalFee = principalAmount / term;
                //administrativeExpensesFee = subTotalFee * (administrativeExpensesRate * 0.01m);
                taxFee = interestFee * taxRate; //(taxRate * 0.01m);
                totalFee = principalFee + interestFee + taxFee; //+ administrativeExpensesFee;
                balance = principalAmount - principalFee;

                if (balance < 0)
                {
                    balance = 0;
                }

                var code = Guid.NewGuid();

                for (int i = 1; i <= term; i++)
                {
                    var temporal = new DetallePlanPagoTemporal
                    {
                        PlanPagoId = code.ToString(),
                        Mes = i,
                        CuotaCapital = principalFee,
                        CuotaIntereses = interestFee,
                        CuotaGastosAdministrativos = 0,// administrativeExpensesFee,
                        CuotaIvaIntereses = taxFee,
                        TotalCuota = totalFee,
                        SaldoCapital = balance,
                        FechaPago = fechaPago
                    };

                    _dbContext.DetallePlanPagoTemporales.Add(temporal);
                    await _dbContext.SaveChangesAsync();

                    //interestFee = balance * (interestRate * 0.01m) / 12;
                    //principalFee = subTotalFee - interestFee;
                    balance = balance - principalFee;

                    if (balance < 0) { balance = 0; }

                    //fechaPago = new DateTime(fechaPago.Year, fechaPago.Month, 1);
                    fechaPago = fechaPago.AddMonths(1);
                }

                projection = await _dbContext.DetallePlanPagoTemporales.Where(p => p.PlanPagoId == code.ToString()).ToListAsync();
            }


            return Ok(projection);
        }

        [HttpPost("plan-pago")]
        public async Task<ActionResult<IEnumerable<object>>> CreatePaymentPlan(CreatePaymentPlanDto createPaymentPlanDto)
        {
            var prestamo = await _unitOfWork.Repository<Prestamo>().GetByIdAsync(createPaymentPlanDto.PrestamoId);

            prestamo.Plazo = createPaymentPlanDto.Plazo;
            prestamo.TasaInteres = createPaymentPlanDto.TasaInteres; // / 100.0m;
            prestamo.TasaIva = createPaymentPlanDto.TasaIva; /// 100.0m;
            prestamo.TasaMora = createPaymentPlanDto.TasaMora; /// 100.0m;
            prestamo.TasaGastos = createPaymentPlanDto.TasaGastos;/// 100.0m;
            prestamo.FechaPlan = createPaymentPlanDto.FechaPlan;

            PlanPago planPago = new PlanPago();

            int result;

            if (createPaymentPlanDto.PlanPagos != null)
            {
                var fila = createPaymentPlanDto.PlanPagos.FirstOrDefault();
                var totalProyectado = (fila.CuotaCapital * prestamo.Plazo) + (fila.CuotaIntereses * prestamo.Plazo) + (fila.CuotaIvaIntereses * prestamo.Plazo);
                foreach (var plan in createPaymentPlanDto.PlanPagos)
                {
                    totalProyectado -= fila.TotalCuota;
                    planPago = _mapper.Map<PlanPago>(plan);
                    planPago.PrestamoId = prestamo.Id;
                    planPago.SaldoCapital = planPago.CuotaCapital;
                    planPago.SaldoIntereses = planPago.CuotaIntereses;
                    planPago.SaldoIvaIntereses = planPago.CuotaIvaIntereses;
                    planPago.SaldoMora = planPago.CuotaMora;
                    planPago.SaldoGastos = planPago.CuotaGastos;
                    planPago.SaldoTotal = totalProyectado;
                    _unitOfWork.Repository<PlanPago>().Add(planPago);
                }

            }

            prestamo.InteresProyectado = planPago.CuotaIntereses * prestamo.Plazo;
            prestamo.IvaProyectado = planPago.CuotaIvaIntereses * prestamo.Plazo;
            prestamo.GastosProyectados = planPago.CuotaGastos * prestamo.Plazo;
            prestamo.MontoTotalProyectado = prestamo.MontoOtorgado + prestamo.InteresProyectado + prestamo.IvaProyectado + prestamo.GastosProyectados;

            EstadoCuenta estadoCuenta = new EstadoCuenta
            {
                AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PrestamoId = planPago.PrestamoId,
                TipoTransaccionId = 1,
                Cargo = prestamo.MontoOtorgado,
                SaldoAnterior = 0,
                SaldoActual = prestamo.MontoOtorgado,
                Concepto = "Monto Saldo Capital Inicial"
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

            estadoCuenta = new EstadoCuenta
            {
                AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PrestamoId = planPago.PrestamoId,
                TipoTransaccionId = 2,
                Cargo = prestamo.InteresProyectado,
                SaldoAnterior = prestamo.MontoOtorgado,
                SaldoActual = prestamo.MontoOtorgado + prestamo.InteresProyectado,
                Concepto = "Monto Saldo de Intereses Inicial"
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

            estadoCuenta = new EstadoCuenta
            {
                AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PrestamoId = planPago.PrestamoId,
                TipoTransaccionId = 3,
                Cargo = prestamo.IvaProyectado,
                SaldoAnterior = prestamo.MontoOtorgado + prestamo.MontoOtorgado,
                SaldoActual = prestamo.MontoOtorgado + prestamo.InteresProyectado + prestamo.IvaProyectado,
                Concepto = "Monto Saldo Iva Inicial"
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

            prestamo.EstadoPrestamoId = 1;

            _unitOfWork.Repository<Prestamo>().Update(prestamo);

            result = await _unitOfWork.Complete();


            if (result < 0) return null!;

            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }

        [HttpPost("registro-pago")]
        public async Task<ActionResult<object>> CreateRegistroPago(CreateRegistroCajaDto createRegistroCajaDto)
        {
            //return Ok(new { Mensaje = "Bloqueado Temporalmente" });

            var tipoCredito = await _dbContext.Prestamos.Where(x => x.Id == createRegistroCajaDto.PrestamoId).Select(x => x.TipoPrestamoId).FirstOrDefaultAsync();

            createRegistroCajaDto.MontoPago = createRegistroCajaDto.MontoCapital + createRegistroCajaDto.MontoInteres + createRegistroCajaDto.MontoIvaIntereses
                        + createRegistroCajaDto.MontoMora + createRegistroCajaDto.MontoIvaMora + createRegistroCajaDto.MontoGastos + createRegistroCajaDto.MontoIvaGastos;

            if (tipoCredito != 11 && tipoCredito != 12)
            {
                var montoPagoCalculado = createRegistroCajaDto.MontoPago;


                if (createRegistroCajaDto.MontoPago != montoPagoCalculado)
                {
                    return BadRequest("No se pudo realizar el pago. Se ha producido una Excepción por favor comuniquese con el Administrador");
                }

            }

            //return Ok(new { Mensaje = "I feel good" });

            var registroPago = _mapper.Map<RegistroCaja>(createRegistroCajaDto);

            _unitOfWork.Repository<RegistroCaja>().Add(registroPago);

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            var planPagos = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).ToListAsync();

            var planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).FirstOrDefaultAsync();

            if (planPago != null)
            {
                var ultimoEstadoCuenta = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == createRegistroCajaDto.PrestamoId).OrderByDescending(e => e.Id).FirstOrDefaultAsync();
                var saldoActual = ultimoEstadoCuenta.SaldoActual;

                if (createRegistroCajaDto.MontoMora > 0)
                {
                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 5, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaMora, "Cargo Iva Mora", createRegistroCajaDto.AppUserId, saldoActual);

                    /** Abono Iva Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 12, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaMora, "Abono Iva Mora", createRegistroCajaDto.AppUserId, saldoActual, planPagos);

                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 4, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoMora, "Cargo Mora", createRegistroCajaDto.AppUserId, saldoActual);

                    /** Abono Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 11, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoMora, "Abono Mora", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.MontoIvaIntereses > 0)
                {
                    /** Abono Iva Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 10, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaIntereses, "Abono Iva Intereses", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.MontoInteres > 0)
                {
                    /** Abono Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 9, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoInteres, "Abono Intereses", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.MontoCapital > 0)
                {
                    /** Abono Capital **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 8, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoCapital, "Abono Capital", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                await _dbContext.SaveChangesAsync();

            }

            /** Actualización de Pagos en el Plan de Pagos **/

            decimal montoCapital = createRegistroCajaDto.MontoCapital, montoIntereses = createRegistroCajaDto.MontoInteres, montoIvaIntereses = createRegistroCajaDto.MontoIvaIntereses,
                montoMora = createRegistroCajaDto.MontoMora, montoIvaMora = createRegistroCajaDto.MontoIvaMora, montoGastos = createRegistroCajaDto.MontoGastos,
                montoIvaGastos = createRegistroCajaDto.MontoIvaGastos;

            var actualizaPlanPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).ToListAsync();



            foreach (var plan in actualizaPlanPago)
            {
                if (montoCapital >= plan.SaldoCapital)
                {
                    montoCapital -= plan.SaldoCapital;
                    plan.SaldoCapital -= plan.SaldoCapital;
                }
                else
                {
                    plan.SaldoCapital -= montoCapital;
                    montoCapital = 0;
                }

                if (montoIntereses >= plan.SaldoIntereses)
                {
                    montoIntereses -= plan.SaldoIntereses;
                    plan.SaldoIntereses -= plan.SaldoIntereses;
                }
                else
                {
                    plan.SaldoIntereses -= montoIntereses;
                    montoIntereses = 0;
                }

                if (montoIvaIntereses >= plan.SaldoIvaIntereses)
                {
                    montoIvaIntereses -= plan.SaldoIvaIntereses;
                    plan.SaldoIvaIntereses -= plan.SaldoIvaIntereses;
                }
                else
                {
                    plan.SaldoIvaIntereses -= montoIvaIntereses;
                    montoIvaIntereses = 0;
                }

                if (montoMora >= plan.SaldoMora)
                {
                    montoMora -= plan.SaldoMora;
                    plan.SaldoMora -= plan.SaldoMora;
                }
                else
                {
                    plan.SaldoMora -= montoMora;
                    montoMora = 0;
                }

                if (montoIvaMora >= plan.SaldoIvaMora)
                {
                    montoIvaMora -= plan.SaldoIvaMora;
                    plan.SaldoIvaMora -= plan.SaldoIvaMora;
                }
                else
                {
                    plan.SaldoIvaMora -= montoIvaMora;
                    montoIvaMora = 0;
                }

                if (montoGastos >= plan.SaldoGastos)
                {
                    montoGastos -= plan.SaldoGastos;
                    plan.SaldoGastos -= plan.SaldoGastos;
                }
                else
                {
                    plan.SaldoGastos -= montoGastos;
                    montoGastos = 0;
                }


                if (montoIvaGastos >= plan.SaldoIvaGastos)
                {
                    montoIvaGastos -= plan.SaldoIvaGastos;
                    plan.SaldoIvaGastos -= plan.SaldoIvaGastos;
                }
                else
                {
                    plan.SaldoIvaGastos -= montoIvaGastos;
                    montoIvaGastos = 0;
                }

                if (plan.SaldoCapital < 0.01m && plan.SaldoIntereses < 0.01m && plan.SaldoIvaIntereses < 0.01m
                    && plan.SaldoMora < 0.01m && plan.SaldoIvaMora < 0.01m && plan.SaldoGastos < 0.01m && plan.SaldoIvaGastos < 0.01m)
                {
                    plan.Aplicado = true;
                }
                _unitOfWork.Repository<PlanPago>().Update(plan);

            }

            await _unitOfWork.Complete();

            /** Actualización de Días de Mora **/
            var prestamo = await _dbContext.Prestamos.FirstOrDefaultAsync(x => x.Id == createRegistroCajaDto.PrestamoId);
            planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).FirstOrDefaultAsync();

            if (planPago is not null)
            {
                var diasMora = (int)(DateTime.Now - planPago.FechaPago).TotalDays;

                if (diasMora < 0) diasMora = 0;
                prestamo.DiasMora = diasMora;
            }
            else
            {
                prestamo.DiasMora = 0;
            }

            /** Verificación de Saldo Total **/
            var saldos = await GetSaldos(prestamo.Id);

            if (saldos.TotalSaldo < 0.01m)
            {
                prestamo.EstadoPrestamoId = 4;
            }

            _unitOfWork.Repository<Prestamo>().Update(prestamo);

            await _unitOfWork.Complete();

            /** Generación de Factura **/

            //var billingMessage = "Factura Generada Satisfactoriamente";

            //if (createRegistroCajaDto.MontoInteres != 0 || createRegistroCajaDto.MontoMora != 0)
            //{
            //    var receptor = await _dbContext.ListadoGeneral.Where(x => x.EntidadId == prestamo.EntidadPrestamoId).FirstOrDefaultAsync();

            //    var descripcion = $"Abono a intereses de préstamo ID : {createRegistroCajaDto.PrestamoId}";
            //    if (createRegistroCajaDto.MontoMora > 0 || createRegistroCajaDto.MontoIvaMora > 0)
            //    {
            //        descripcion = $"Abono a intereses y Mora de préstamo ID : {createRegistroCajaDto.PrestamoId} según transacción: {registroPago.Id}";
            //    }

            //    var precioUnitario = createRegistroCajaDto.MontoInteres + createRegistroCajaDto.MontoMora + createRegistroCajaDto.MontoIvaIntereses + createRegistroCajaDto.MontoIvaMora;
            //    var montoGravable = createRegistroCajaDto.MontoInteres + createRegistroCajaDto.MontoMora;
            //    var montoImpuesto = createRegistroCajaDto.MontoIvaIntereses + createRegistroCajaDto.MontoIvaMora;

            //    /** Se genera la llave Hash **/
            //    GetHashed getHashed = new GetHashed();
            //    var instanceId = "SINFIN-DEV";
            //    var sharedKeyAccess = "ULTRAKEY";
            //    var keyAccess = getHashed.GetHashedKey(instanceId, registroPago.Id.ToString(), instanceId + sharedKeyAccess);


            //    var facturaDto = new FacturaDto
            //    {
            //        RequesterBackendRef = new RequesterBackendRef
            //        {
            //            InstanceId = instanceId,
            //            ReferenceId = registroPago.Id.ToString(),
            //            AccessKey = keyAccess
            //        },
            //        GralData = new GralData
            //        {
            //            CodigoMoneda = "GTQ",
            //            FechaHoraEmision = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK"),
            //            Tipo = "FCAM",
            //            Exportacion = "",
            //            NumeroAcceso = "",
            //            TipoPersoneria = ""
            //        },
            //        Emisor = new Emisor
            //        {
            //            AfiliacionIVA = "GEN",
            //            CodigoEstablecimiento = "1",
            //            CodigoPostal = "01010",
            //            CorreoEmisor = "mercedes.delcid@plataforma.com.gt",
            //            Pais = "GT",
            //            Departamento = "GUATEMALA",
            //            Municipio = "GUATEMALA",
            //            Direccion = "14 CALLE 3-51 EDIFICIO MURANO CENTER ZONA 10 1601",
            //            NITEmisor = "11800103K", //"104273402K" Validar Producción,
            //            NombreEmisor = "CORPORACIÓN LENDING S.A.",
            //            NombreComercial = "CORPORACIÓN LENDING S.A."
            //        },
            //        Receptor = new Receptor
            //        {
            //            IDReceptor = receptor.NIT.IsNullOrEmpty() ? "CF" : receptor.NIT,
            //            NombreReceptor = receptor.Nombre,
            //            CodigoPostal = "0",
            //            CorreoReceptor = receptor.Email.IsNullOrEmpty() ? "" : receptor.Email,
            //            Pais = "GT",
            //            Departamento = "GUATEMALA",
            //            Municipio = "GUATEMALA",
            //            Direccion = "CIUDAD",
            //            TipoEspecial = ""
            //        },
            //        Frase = new Frase
            //        {
            //            frase = "1",
            //            Escenario = "1",
            //            NumeroResolucion = "",
            //            FechaResolucion = ""
            //        },
            //        Detalle = new List<Dtos.Detalle>
            //    {
            //        new Dtos.Detalle
            //        {
            //            BienOServicio = "S",
            //            UnidadMedida = "UND",
            //            Cantidad = "1",
            //            Descripcion = descripcion,
            //            NumeroLinea = "1",
            //            PrecioUnitario = precioUnitario.ToString(),
            //            Precio = precioUnitario.ToString(),
            //            Descuento = "0.0",
            //            Total = precioUnitario.ToString(),
            //            NombreCorto1 = "IVA",
            //            CodigoUnidadGravable1 = "1",
            //            CantidadUnidadesGravables1 = "",
            //            MontoGravable1 = montoGravable.ToString(),
            //            MontoImpuesto1 = montoImpuesto.ToString(),
            //            OtrosDescuento = "",
            //            CodigoProducto = ""
            //        }
            //    },
            //        TotalImpuestos = new Dtos.TotalImpuestos
            //        {
            //            NombreCorto = "IVA",
            //            TotalMontoImpuesto = montoImpuesto.ToString()
            //        },
            //        GranTotal = new GrandTotal
            //        {
            //            GranTotal = precioUnitario.ToString()
            //        },
            //        AbonosFacturaCambiaria = new List<AbonosFacturaCambiaria>
            //    {
            //        new AbonosFacturaCambiaria
            //        {
            //            Fecha_vencimiento = DateTime.Now.AddMonths(1).Date.ToString("yyyy-MM-dd"),
            //            Numero_abono = "1",
            //            Monto_abono = precioUnitario.ToString()
            //        }
            //    },
            //        ComplementoCambiaria = new ComplementoCambiaria
            //        {
            //            IDComplemento = "Cambiaria",
            //            NombreComplemento = "Cambiaria",
            //            URIComplemento = "http://www.sat.gob.gt/fel/cambiaria.xsd"
            //        },
            //        Adendas = new List<Adendas>
            //        {

            //        }

            //    };


            //    string miJson = JsonSerializer.Serialize(facturaDto);
            //    var resultado = invoiceSoap.GenerateInvoice(miJson);

            //    JObject json = JObject.Parse(resultado);

            //    if ((string)json["result"] != "0")
            //    {
            //        billingMessage = "Atención!!! Hubo un error en el Proceso de Facturación, La Factura no se emitió!";
            //    }

                //return Ok(resultado);
            //}




            await _dbContext.Database.ExecuteSqlRawAsync($"sp_job_calcularMoraPrestamo {createRegistroCajaDto.PrestamoId}, 0, 1");


            return Ok(new { Mensaje = "Pago realizado Satisfactoriamente", RegistroCajaId = registroPago.Id /*, billingMessage */});
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    string aux = @"{    ""data"": {      ""RESULTADO"": ""True"",      ""DESCRIPCION"": ""Validado y Certificado Exitosamente"",      ""ORIGEN"": ""Validaciones XML Segun FEL Reglas y Validaciones Versión 1.7.5"",      ""TOKEN_VALIDO: "": ""False"",      ""PDF-LNK"": ""https://report.feel.com.gt/ingfacereport/ingfacereport_documento?uuid=57C768DE-CD32-4DA5-A66A-4B52E4FB3A87"",      ""UUID"": ""57C768DE-CD32-4DA5-A66A-4B52E4FB3A87"",      ""SERIE"": ""*PRUEBAS*"",      ""NUMERO"": ""3442625957""    },    ""errorMessages"": {},    ""result"": 0,    ""message"": ""Ok""  }";
        //    aux = @"{    ""data"": {      ""RESULTADO"": ""False"",      ""DESCRIPCION"": ""Existen errores en la validacion del XML. Por favor revisa e intenta de nuevo."",      ""ORIGEN"": ""Validaciones XML Segun FEL Reglas y Validaciones Versión 1.7.5"",      ""TOKEN_VALIDO: "": ""False""    },    ""errorMessages"": {      ""1"": ""{\""resultado\"":false,\""fuente\"":\""FEL Reglas y Validaciones\"",\""categoria\"":\""2.7 Validaciones específicas para el IVA\"",\""numeral\"":\""2.7.1\"",\""validacion\"":\""2\"",\""mensaje_error\"":\""FEL-GUI-24 | 2.7 | 2.7.1 | No. 2 | Error - Monto Gravable calculado incorrectamente para el impuesto [IVA]. Cod. Unidad Gravable [1] (Detalle linea No. 1).\""}"",      ""2"": ""{\""resultado\"":false,\""fuente\"":\""FEL Reglas y Validaciones\"",\""categoria\"":\""2.7 Validaciones específicas para el IVA\"",\""numeral\"":\""2.7.4\"",\""validacion\"":\""1\"",\""mensaje_error\"":\""FEL-GUI-25 | 2.7 | 2.7.4 | No. 1 | Error - Monto del Impuesto calculado incorrectamente para para el impuesto [IVA] (Detalle linea No. 1).\""}""    },    ""result"": 800,    ""message"": ""INFILE-WS report problem""  }";


        //    JObject json = JObject.Parse(aux);

        //    this.textBox1.Text =
        //        "RESULTADO GENERAL: " + (string)json["result"] + "\r\n"
        //        + "MENSAJE GENERAL: " + (string)json["message"] + "\r\n"
        //        + "\r\n"

        //        + "data {" + "\r\n"
        //        + "\t" + "RESULTADO" + ": " + (string)json["data"]["RESULTADO"] + "\r\n"
        //        + "\t" + "DESCRIPCION" + ": " + (string)json["data"]["DESCRIPCION"] + "\r\n"
        //        + "\t" + "ORIGEN" + ": " + (string)json["data"]["ORIGEN"] + "\r\n"
        //        + "\t" + "TOKEN_VALIDO" + ": " + (string)json["data"]["TOKEN_VALIDO"] + "\r\n"
        //        + "}" + "\r\n"
        //      ;

        //    this.textBox1.Text += "\r\n" + "\r\n";

        //    var vx = json["errorMessages"];
        //    this.textBox1.Text += "errorMessages: " + vx.Count().ToString() + "\r\n";
        //    for (int i = 0; i < vx.Count(); i++)
        //    {
        //        this.textBox1.Text += vx.ToList()[i].ToString() + "\r\n";
        //    }
        //    aux += "";
        //}

        [HttpPost("registro-pago-planilla")]
        public async Task<IActionResult> StoreFile([FromForm] PagoPlanillaDto pagoPlanillaDto)
        {
            List<DetallePagosDto> records;

            using (var memoryStream = new MemoryStream())
            {
                await pagoPlanillaDto.ListadoPlanilla.CopyToAsync(memoryStream);

                using (var streamReader = new StreamReader(new MemoryStream(memoryStream.ToArray())))
                {
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        records = csvReader.GetRecords<DetallePagosDto>().ToList();
                    }
                }
            }

            //foreach (var record in records)
            //{
            //    var newStudent = new AcademyStudent
            //    {
            //        GradeId = updateImage.GradeId,
            //        FullName = record.Responsable,
            //        IdentityCard = record.IdentityCard,
            //        Email = record.Email,
            //        Responsable = record.Responsable,
            //        Contact = record.Contact,
            //    };

            //    _dbcontext.Add(newStudent);
            //    _dbcontext.SaveChanges();
            //}

            //return Ok(records);

            return Ok(new { message = "Successful Action" });
        }

        [HttpPost("reversion_total")]
        public async Task<ActionResult<object>> GetTotalRevertion(RemoveRegistroCajaDto removeRegistroCajaDto)
        {
            var credito = await _dbContext.Prestamos.FirstOrDefaultAsync(x => x.Id == removeRegistroCajaDto.PrestamoId);
            if (credito is null)
            {
                return new
                {
                    CodigoError = 1930,
                    Mensaje = $"El identificador {removeRegistroCajaDto.PrestamoId} no existe"
                };
            }

            var itemsEstadoCuenta = await _dbContext.EstadoCuentas.Where(x => x.RegistroCajaId == removeRegistroCajaDto.RegistroCajaId).ToListAsync();



            if (itemsEstadoCuenta.Count == 0)
            {
                return new
                {
                    CodigoError = 1935,
                    Mensaje = $"No existe el Registro {removeRegistroCajaDto.RegistroCajaId}"
                };
            }

            foreach (var item in itemsEstadoCuenta)
            {
                var registroAbonoPagos = await _dbContext.AbonoPlanes.Where(x => x.EstadoCuentaId == item.Id).ToListAsync();

                if (registroAbonoPagos is not null)
                {
                    foreach (var itemAbono in registroAbonoPagos)
                    {
                        var planPago = await _dbContext.PlanPagos.Where(x => x.Id == itemAbono.PlanPagoId).FirstOrDefaultAsync();

                        planPago.SaldoCapital += itemAbono.CuotaCapital;
                        planPago.SaldoIntereses += itemAbono.CuotaIntereses;
                        planPago.SaldoIvaIntereses += itemAbono.CuotaIvaIntereses;
                        planPago.SaldoMora += itemAbono.CuotaMora;
                        planPago.SaldoIvaMora += itemAbono.CuotaIvaMora;
                        _dbContext.PlanPagos.Update(planPago);
                        if (planPago.SaldoCapital == planPago.CuotaCapital && planPago.SaldoIntereses == planPago.CuotaIntereses &&
                            planPago.SaldoIvaIntereses == planPago.CuotaIvaIntereses && planPago.SaldoMora == planPago.CuotaMora &&
                            planPago.SaldoIvaMora == planPago.CuotaIvaMora)
                        {
                            planPago.Aplicado = false;
                        }
                    }
                }
                _dbContext.AbonoPlanes.RemoveRange(registroAbonoPagos);
            }
            _dbContext.EstadoCuentas.RemoveRange(itemsEstadoCuenta);

            var registroCaja = await _dbContext.RegistroCajas.FirstOrDefaultAsync(x => x.Id == removeRegistroCajaDto.RegistroCajaId);

            _dbContext.RegistroCajas.Remove(registroCaja);

            _dbContext.SaveChanges();


            return Ok(new { Mensaje = "Accion Realizada Satisfactoriamente" });
        }

        [HttpPost("reversion")]
        public async Task<ActionResult<object>> GetRevertion(RemoveRegistroCajaDto removeRegistroCajaDto)
        {
            var credito = await _dbContext.Prestamos.FirstOrDefaultAsync(x => x.Id == removeRegistroCajaDto.PrestamoId);
            if (credito is null)
            {
                return new
                {
                    CodigoError = 1930,
                    Mensaje = $"El identificador {removeRegistroCajaDto.PrestamoId} no existe"
                };
            }

            var itemsEstadoCuenta = await _dbContext.EstadoCuentas.Where(x => x.RegistroCajaId == removeRegistroCajaDto.RegistroCajaId).ToListAsync();



            if (itemsEstadoCuenta.Count == 0)
            {
                return new
                {
                    CodigoError = 1935,
                    Mensaje = $"No existe el Registro {removeRegistroCajaDto.RegistroCajaId}"
                };
            }


            /** Se Aplica de nuevo al Plan de Pago los Pagos Revertidos **/
            var totalAbonoCapital = 0.0m;
            var totalAbonoIntereses = 0.0m;
            var totalAbonoIvaIntereses = 0.0m;

            foreach (var item in itemsEstadoCuenta)
            {
                var registroAbonoPagos = await _dbContext.AbonoPlanes.Where(x => x.EstadoCuentaId == item.Id).ToListAsync();

                if (registroAbonoPagos is not null)
                {
                    foreach (var itemAbono in registroAbonoPagos)
                    {
                        var planPago = await _dbContext.PlanPagos.Where(x => x.Id == itemAbono.PlanPagoId).FirstOrDefaultAsync();

                        planPago.SaldoCapital += itemAbono.CuotaCapital;
                        planPago.SaldoIntereses += itemAbono.CuotaIntereses;
                        planPago.SaldoIvaIntereses += itemAbono.CuotaIvaIntereses;
                        planPago.SaldoMora += itemAbono.CuotaMora;
                        planPago.CuotaMora = 0;
                        planPago.SaldoIvaMora += itemAbono.CuotaIvaMora;
                        planPago.CuotaIvaMora = 0;
                        _dbContext.PlanPagos.Update(planPago);
                        if (planPago.SaldoCapital != 0 || planPago.SaldoIntereses != 0 ||
                            planPago.SaldoIvaIntereses != 0 || planPago.SaldoMora != 0 ||
                            planPago.SaldoIvaMora != 0)
                        {
                            planPago.Aplicado = false;
                        }

                        /** En el Estado de Cuenta se Revierten los Abonos y se reestablecen los rubros correspondientes **/


                        switch (item.TipoTransaccionId)
                        {
                            case 8:
                                totalAbonoCapital += itemAbono.CuotaCapital;
                                break;
                            case 9:
                                totalAbonoIntereses += itemAbono.CuotaIntereses;
                                break;
                            case 10:
                                totalAbonoIvaIntereses += itemAbono.CuotaIvaIntereses;
                                break;
                            default:
                                break;
                        }

                    }
                }
                /** Se elimina los Abonos realizados en la tabla AbonoPlanes**/
                _dbContext.AbonoPlanes.RemoveRange(registroAbonoPagos);



            }
            var ultimoEstadoCuenta = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == removeRegistroCajaDto.PrestamoId).OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            var saldoActual = ultimoEstadoCuenta.SaldoActual;

            saldoActual = await CargoEstadoCuenta(removeRegistroCajaDto.PrestamoId, 29, null, 0, totalAbonoCapital, "Reestablecimiento de Capital", "8f00ad3d-22d4-424d-8e48-6df7aef4f7d6", saldoActual);
            saldoActual = await CargoEstadoCuenta(removeRegistroCajaDto.PrestamoId, 30, null, 0, totalAbonoIntereses, "Reestablecimiento de Intereses", "8f00ad3d-22d4-424d-8e48-6df7aef4f7d6", saldoActual);
            saldoActual = await CargoEstadoCuenta(removeRegistroCajaDto.PrestamoId, 31, null, 0, totalAbonoIvaIntereses, "Reestablecimiento de Iva de Intereses", "8f00ad3d-22d4-424d-8e48-6df7aef4f7d6", saldoActual);

            //_dbContext.EstadoCuentas.RemoveRange(itemsEstadoCuenta);

            var registroCaja = await _dbContext.RegistroCajas.FirstOrDefaultAsync(x => x.Id == removeRegistroCajaDto.RegistroCajaId);

            registroCaja.MotivoAnulacion = "Pago Revertido";
            registroCaja.Habilitado = false;

            _dbContext.RegistroCajas.Update(registroCaja);

            _dbContext.SaveChanges();

            await GetDistribuyePago(removeRegistroCajaDto.PrestamoId, 100.00m, DateTime.Now, false);
            await _dbContext.Database.ExecuteSqlRawAsync($"sp_job_calcularMoraPrestamo {removeRegistroCajaDto.PrestamoId}, 0, 1");


            return Ok(new { Mensaje = "Accion Realizada Satisfactoriamente" });
        }

        [HttpPost("pago-ajustes")]
        public async Task<ActionResult<object>> CreateRegistroAjustes(CreateRegistroCajaDto createRegistroCajaDto)
        {
            var registroPago = _mapper.Map<RegistroCaja>(createRegistroCajaDto);

            _unitOfWork.Repository<RegistroCaja>().Add(registroPago);

            var result = await _unitOfWork.Complete();

            //return Ok(new { message = "Acción realizada Satisfactoriamente" });

            if (result < 0) return null!;

            var planPagos = await _dbContext.PlanPagos.Where(p => p.Id == createRegistroCajaDto.PlanPagoId).ToListAsync();

            var planPago = await _dbContext.PlanPagos.Where(p => p.Id == createRegistroCajaDto.PlanPagoId).FirstOrDefaultAsync();

            if (planPago != null)
            {
                var ultimoEstadoCuenta = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == createRegistroCajaDto.PrestamoId).OrderByDescending(e => e.Id).FirstOrDefaultAsync();
                var saldoActual = ultimoEstadoCuenta.SaldoActual;

                if (createRegistroCajaDto.TipoTransaccionId == 17)
                {
                    /** Abono Ajuste Iva Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 17, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Iva Intereses", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 20)
                {
                    /** Abono Ajuste Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 20, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Intereses", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 21)
                {
                    /** Abono Ajuste Iva Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 21, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Iva Mora", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 22)
                {
                    /** Abono Ajuste Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 22, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Mora", createRegistroCajaDto.AppUserId, saldoActual, planPagos);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 23)
                {
                    /** Cargo Ajuste Iva Intereses **/
                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 23, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Iva Intereses", createRegistroCajaDto.AppUserId, saldoActual);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 24)
                {
                    /** Abono Ajuste Intereses **/
                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 24, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Intereses", createRegistroCajaDto.AppUserId, saldoActual);
                }

                await _dbContext.SaveChangesAsync();

            }

            /** Actualización de Pagos en el Plan de Pagos **/

            decimal montoPago = createRegistroCajaDto.MontoPago;
            var actualizaPlanPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).ToListAsync();



            foreach (var plan in actualizaPlanPago)
            {
                if (createRegistroCajaDto.TipoTransaccionId == 17)
                {
                    if (montoPago > 0)
                    {
                        if (montoPago >= plan.CuotaIvaIntereses)
                        {
                            montoPago -= plan.CuotaIvaIntereses;
                            plan.SaldoIvaIntereses -= plan.CuotaIvaIntereses;
                        }
                        else
                        {
                            plan.SaldoIvaIntereses = montoPago;
                            montoPago = 0;
                        }
                    }
                }

                if (createRegistroCajaDto.TipoTransaccionId == 20)
                {
                    if (montoPago > 0)
                    {
                        if (montoPago >= plan.CuotaIntereses)
                        {
                            montoPago -= plan.CuotaIntereses;
                            plan.SaldoIntereses -= plan.CuotaIntereses;
                        }
                        else
                        {
                            plan.SaldoIntereses = montoPago;
                            montoPago = 0;
                        }
                    }
                }

                if (createRegistroCajaDto.TipoTransaccionId == 21)
                {
                    if (montoPago > 0)
                    {
                        if (montoPago >= plan.CuotaIvaMora)
                        {
                            montoPago -= plan.CuotaIvaMora;
                            plan.SaldoIvaMora -= plan.CuotaIvaMora;
                        }
                        else
                        {
                            plan.SaldoIvaMora = montoPago;
                            montoPago = 0;
                        }
                    }
                }

                if (createRegistroCajaDto.TipoTransaccionId == 22)
                {
                    if (montoPago > 0)
                    {
                        if (montoPago >= plan.CuotaMora)
                        {
                            montoPago -= plan.CuotaMora;
                            plan.SaldoMora -= plan.CuotaMora;
                        }
                        else
                        {
                            plan.SaldoMora -= montoPago;
                            montoPago = 0;
                        }
                    }
                }


                if (plan.SaldoCapital == 0 && plan.SaldoIntereses == 0 && plan.SaldoIvaIntereses == 0
                    && plan.SaldoMora == 0 && plan.SaldoIvaMora == 0 && plan.SaldoGastos == 0 && plan.SaldoIvaGastos == 0)
                {
                    plan.Aplicado = true;
                }
                _unitOfWork.Repository<PlanPago>().Update(plan);

            }


            await _unitOfWork.Complete();

            return Ok(new { Mensaje = "Accion Realizada Satisfactoriamente" });
        }

        [HttpGet]

        private async Task<decimal> AbonoEstadoCuenta(int prestamoId, int tipoTransaccionId, int registroCajaId, int planPagoId, decimal monto, string concepto, string appUserId, decimal saldoActual, List<PlanPago> planPago)
        {
            var estadoCuenta = new EstadoCuenta
            {
                AppUserId = appUserId,
                PrestamoId = prestamoId,
                RegistroCajaId = registroCajaId,
                TipoTransaccionId = tipoTransaccionId,
                Cargo = 0,
                Abono = monto,
                SaldoAnterior = saldoActual,
                SaldoActual = saldoActual - monto,
                Concepto = concepto,
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

            await _unitOfWork.Complete();

            //await _dbContext.EstadoCuentas.AddAsync(estadoCuenta);
            //await _dbContext.SaveChangesAsync();

            CuotaAbonoPlan(estadoCuenta.Id, planPagoId, tipoTransaccionId, monto, planPago);


            return estadoCuenta.SaldoActual;
        }

        private async Task<decimal> CargoEstadoCuenta(int prestamoId, int tipoTransaccionId, int? registroCajaId, int planPagoId, decimal monto, string concepto, string appUserId, decimal saldoActual)
        {
            EstadoCuenta estadoCuenta;
            if (monto > 0)
            {
                estadoCuenta = new EstadoCuenta
                {
                    AppUserId = appUserId,
                    PrestamoId = prestamoId,
                    RegistroCajaId = registroCajaId,
                    TipoTransaccionId = tipoTransaccionId,
                    Cargo = monto,
                    Abono = 0,
                    SaldoAnterior = saldoActual,
                    SaldoActual = saldoActual + monto,
                    Concepto = concepto,
                };
                _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);
                await _unitOfWork.Complete();
                return estadoCuenta.SaldoActual;
            }

            return saldoActual;
            //await _dbContext.EstadoCuentas.AddAsync(estadoCuenta);
            //await _dbContext.SaveChangesAsync();

            //CuotaAbonoPlan(estadoCuenta.Id, planPagoId, tipoTransaccionId, monto);
        }

        private async void CuotaAbonoPlan(int estadoCuentaId, int planPagoId, int tipoTransaccionId, decimal monto, List<PlanPago> planPago)
        {
            decimal cuotaCapital = 0, abonoCapital = 0, cuotaIntereses = 0, abonoIntereses = 0, cuotaIvaIntereses = 0, abonoIvaIntereses = 0,
                    cuotaMora = 0, abonoMora = 0, cuotaIvaMora = 0, abonoIvaMora = 0, cuotaGastos = 0, cuotaIvaGastos = 0;

            if (tipoTransaccionId == 8) cuotaCapital = monto;
            if (tipoTransaccionId == 9 || tipoTransaccionId == 20 || tipoTransaccionId == 24) cuotaIntereses = monto;
            if (tipoTransaccionId == 10 || tipoTransaccionId == 17 || tipoTransaccionId == 23) cuotaIvaIntereses = monto;
            if (tipoTransaccionId == 11) cuotaMora = monto;
            if (tipoTransaccionId == 12) cuotaIvaMora = monto;


            //var planPago = await _dbContext.PlanPagos.Where(p => p.Id == planPagoId).ToListAsync();

            foreach (var plan in planPago)
            {

                if (cuotaCapital > 0 && cuotaCapital >= plan.SaldoCapital)
                {
                    cuotaCapital -= plan.SaldoCapital;
                    abonoCapital = plan.SaldoCapital;
                }
                else
                {
                    abonoCapital = cuotaCapital;
                    cuotaCapital = 0;
                }


                if (cuotaIntereses > 0 && cuotaIntereses >= plan.SaldoIntereses)
                {
                    cuotaIntereses -= plan.SaldoIntereses;
                    abonoIntereses = plan.SaldoIntereses;
                }
                else
                {
                    abonoIntereses = cuotaIntereses;
                    cuotaIntereses = 0;
                }

                if (cuotaIvaIntereses > 0 && cuotaIvaIntereses >= plan.SaldoIvaIntereses)
                {
                    cuotaIvaIntereses -= plan.SaldoIvaIntereses;
                    abonoIvaIntereses = plan.SaldoIvaIntereses;
                }
                else
                {
                    abonoIvaIntereses = cuotaIvaIntereses;
                    cuotaIvaIntereses = 0;
                }

                if (cuotaMora > 0 && cuotaMora >= plan.SaldoMora)
                {
                    cuotaMora -= plan.SaldoMora;
                    abonoMora = plan.SaldoMora;
                }
                else
                {
                    abonoMora = cuotaMora;
                    cuotaMora = 0;
                }

                if (cuotaIvaMora > 0 && cuotaIvaMora >= plan.SaldoIvaMora)
                {
                    cuotaIvaMora -= plan.SaldoIvaMora;
                    abonoIvaMora = plan.SaldoIvaMora;
                }
                else
                {
                    abonoIvaMora = cuotaIvaMora;
                    cuotaIvaMora = 0;
                }

                if (abonoCapital > 0 || abonoIntereses > 0 || abonoIvaIntereses > 0 || abonoMora > 0 || abonoIvaMora > 0)
                {
                    var cuotaAbono = new AbonoPlan
                    {
                        EstadoCuentaId = estadoCuentaId,
                        PlanPagoId = plan.Id,
                        CuotaCapital = abonoCapital,
                        CuotaIntereses = abonoIntereses,
                        CuotaIvaIntereses = abonoIvaIntereses,
                        CuotaMora = abonoMora,
                        CuotaIvaMora = abonoIvaMora,
                        CuotaGastos = cuotaGastos,
                        CuotaIvaGastos = cuotaIvaGastos
                    };

                    await _dbContext.AbonoPlanes.AddAsync(cuotaAbono);
                }

            }

        }

        [HttpGet("liquidar_credito/{creditoId}")]
        public async Task<ActionResult<object>> LiquidaCredito(int creditoId)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"sp_sct_payAllCurrentDebtAndCloseLoan {creditoId}");

            return Ok(new { Mensaje = "Accion Realizada Satisfactoriamente" });
        }
    }
}
