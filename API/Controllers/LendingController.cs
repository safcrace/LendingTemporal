using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Views;
using Core.Interfaces;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class LendingController : BaseApiController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

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
                                          Nombres = per.Nombres, 
                                          Apellidos = per.Apellidos,
                                          DPI = per.NumeroDocumento,
                                          per.Direccion,
                                          per.NumeroTelefono,
                                          per.NIT,
                                          EstadoCivil = per.EstadoCivil.Nombre,
                                          EstadoPrestamo = pre.EstadoPrestamo.Nombre,
                                          AsesorId = pre.GestorPrestamoId,
                                          TipoPrestamo = pre.TipoPrestamo.Nombre,
                                          MontoTotal = pre.MontoOtorgado,
                                          MontoTotalProyectado = pre.MontoTotalProyectado,
                                          Plazo = pre.Plazo,
                                          TasaInteres = pre.TasaInteres,
                                          TasaMora = pre.TasaMora,
                                          TasaIva = pre.TasaIva,
                                          FechaPlan = pre.FechaPlan,
                                          FechaAprobacion = pre.FechaAprobacion,
                                          DiasMora = pre.DiasMora
                                      }).ToListAsync();

                var agenteP = await (from pre in _dbContext.Prestamos
                                     join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                     join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                     where pre.Id == id
                                     select new
                                     {
                                         Nombre = per.Nombres + " " + per.Apellidos,

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
                                      TipoPrestamo = pre.TipoPrestamo.Nombre,
                                      MontoTotal = pre.MontoOtorgado,
                                      MontoTotalProyectado = pre.MontoTotalProyectado,
                                      Plazo = pre.Plazo,
                                      TasaInteres = pre.TasaInteres,
                                      TasaMora = pre.TasaMora,
                                      TasaIva = pre.TasaIva
                                  }).ToListAsync();

            var agenteE = await (from pre in _dbContext.Prestamos
                                 join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                 join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                 where pre.Id == id
                                 select new
                                 {
                                     Nombre = per.Nombres + " " + per.Apellidos,

                                 }).FirstOrDefaultAsync();

            return Ok(new { lendingE, agenteE });
           
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
                                      Nombres = per.Nombres,
                                      Apellidos = per.Apellidos,
                                      DPI = per.NumeroDocumento,
                                      per.Direccion,
                                      NumeroTelefono = per.NumeroTelefono,
                                      per.NIT,
                                      EstadoCivilId = per.EstadoCivilId,
                                      EstadoPrestamo = pre.EstadoPrestamo.Nombre,
                                      AsesorId = pre.GestorPrestamoId,
                                      EmpresaPlanillaId = pre.EmpresaPrestamoId,
                                      TipoPrestamo = pre.TipoPrestamoId
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

            _unitOfWork.Repository<Prestamo>().Update(prestamo);

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            var persona = await _dbContext.Personas.Where(p => p.Id == updatePersonLendingDto.personId).FirstOrDefaultAsync();

            persona.Nombres = updatePersonLendingDto.Nombres;
            persona.Apellidos = updatePersonLendingDto.Apellidos;
            persona.NumeroDocumento = updatePersonLendingDto.NumeroDocumento;
            persona.Direccion = updatePersonLendingDto.Direccion;
            persona.NumeroTelefono = updatePersonLendingDto.NumeroTelefono;
            persona.NIT = updatePersonLendingDto.NIT;
            persona.EstadoCivilId = updatePersonLendingDto.EstadoCivilId;

            _unitOfWork.Repository<Persona>().Update(persona);

            result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            return Ok(new { message = "Acción realizada Satisfactoriamente" });

        }
           


        [HttpGet("saldos/{prestamoId:int}")]
        public async Task<ObtenerSaldosDto> GetSaldos(int prestamoId)
        {
            var saldosPrestamo =await _dbContext.Prestamos.Where(p => p.Id == prestamoId).FirstOrDefaultAsync();

            var saldoCapital = saldosPrestamo.MontoOtorgado;
            var saldoInteres = saldosPrestamo.InteresProyectado;
            var saldoIvaInteres = saldosPrestamo.IvaProyectado;
            var saldoMora = 0.0m;
            var saldoIvaMora =0.0m;
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
            return await _dbContext.EstadoCuentas.Where(x => x.PrestamoId == prestamoId).Select(x => new
            {
                x.TipoTransaccionId,
                x.Cargo,
                x.Abono,
                x.SaldoAnterior,
                x.SaldoActual,
                x.Concepto,
                x.FechaCreacion
            }).ToListAsync();
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
                                                       Nombre = per.Nombres + " " + per.Apellidos,
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
                                     Nombre = per.Nombres + " " + per.Apellidos,
                                 }).FirstOrDefaultAsync();

            var gestor = await (from pre in _dbContext.Prestamos
                                join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                where pre.Id == prestamoId
                                select new
                                {
                                    Nombre = per.Nombres + " " + per.Apellidos,
                                }).FirstOrDefaultAsync();

            return await _dbContext.RegistroCajas.Where(x => x.PrestamoId == prestamoId).Select(x => new
            {
                ReciboNo = x.Id,
                NombreDeudor = deudor,
                NombreUsuario = usuario.Nombre,
                NombreGestor = gestor.Nombre,
                FechaRecibo = DateTime.Now,
                Caja = x.Caja.Nombre,
                x.FechaTransaccion,
                TipoTranCapital = 8, 
                Capital = x.MontoCapital,
                TipoTranIntereses = 9,
                Intereses =x.MontoInteres,
                TipoTranIvaIntereses = 10,
                Iva = x.MontoIvaIntereses,
                MontoPago = x.MontoPago,
                FormaPago = x.FormaPago.Nombre,
                NombreBanco = x.Banco.Nombre
            }).ToListAsync();
        }


        [HttpGet("distribuye_pago/{prestamoId:int}")]
        public async Task<DistribuyePagoDto> GetDistribuyePago(int prestamoId, decimal montoPago, bool aplicaMora = true)
        {
            decimal saldoMonto = montoPago;
            int diasMora = 0;
            decimal montoMora = 0.0m, montoIvaMora = 0.0m, montoIntereses = 0.0m, montoIvaIntereses = 0.0m , montoCapital = 0.0m, montoExcedente = 0.0m, capitalVencido = 0.0m,
                    cargoMontoMora = 0.0m, cargoMontoIvaMora = 0.0m;

            /** Plan de Pago Couta Vigente **/

            var planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId && p.Aplicado == false).FirstOrDefaultAsync();
            
            /** Se Calcula Mora si Existe **/
            var tasaMora = await _dbContext.Prestamos.Where(p => p.Id == prestamoId).Select(p => p.TasaMora).FirstOrDefaultAsync();

            if (aplicaMora == true)
            {

                if (tasaMora > 1)
                {
                    tasaMora = tasaMora / 100.00m;
                }

                diasMora = (int)(DateTime.Now - planPago.FechaPago).TotalDays;

                if (diasMora <= 0)
                {
                    diasMora = 0;
                }
            }


            var planesPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId && p.Aplicado == false).ToListAsync();
            
            foreach (var plan in planesPago)
            {

                if (plan.FechaPago <= DateTime.Now)
                {
                    capitalVencido += plan.SaldoCapital; //* tasaMora;                
                    cargoMontoMora += capitalVencido * tasaMora / 365 * diasMora;
                    cargoMontoIvaMora += cargoMontoMora * 0.12m;
                    plan.CuotaMora = cargoMontoMora;
                    plan.SaldoMora = cargoMontoMora;
                    plan.CuotaIvaMora = cargoMontoIvaMora;
                    plan.SaldoIvaMora = cargoMontoIvaMora;
                    plan.TotalCuota = plan.CuotaCapital + plan.CuotaIntereses + plan.CuotaIvaIntereses + plan.CuotaMora + plan.CuotaIvaMora; 
                    _dbContext.Update(plan);
                    await _dbContext.SaveChangesAsync();
                }
            }            


            /** Pago Mora  **/
            if (planPago.SaldoMora > 0 && saldoMonto < planPago.SaldoMora)
            {
                montoMora = saldoMonto;
                saldoMonto = 0.0m;
            }

            if (saldoMonto >= planPago.SaldoMora)
            {
                saldoMonto -= planPago.SaldoMora;
                montoMora = planPago.SaldoMora;
            }

            /** Pago Iva Mora **/
            if (planPago.SaldoIvaMora > 0 && saldoMonto < planPago.SaldoIvaMora)
            {
                montoIvaMora = saldoMonto;
                saldoMonto = 0.0m;
            }

            if (saldoMonto >= planPago.SaldoIvaMora)
            {
                saldoMonto -= planPago.SaldoIvaMora;
                montoIvaMora = planPago.SaldoIvaMora;
            }


            /** Si el pago es mayor a la cuota **/
            if (saldoMonto > (planPago.SaldoCapital + planPago.SaldoIntereses + planPago.SaldoIvaIntereses))
            {
                montoExcedente = saldoMonto - (planPago.SaldoCapital + planPago.SaldoIntereses + planPago.SaldoIvaIntereses);
                saldoMonto = planPago.SaldoCapital + planPago.SaldoIntereses + planPago.SaldoIvaIntereses;
                foreach (var plan in planesPago)
                {
                    if (montoExcedente >= 1 && plan.Id > planPago.Id)
                    {
                        AbonarExcedente(plan.SaldoIvaIntereses, plan.SaldoIntereses, plan.SaldoCapital, ref montoExcedente, ref montoIvaIntereses, ref montoIntereses, ref montoCapital);
                    }
                }                
            }

            //return Ok(new { montoExcedente, saldoMonto, montoIvaIntereses, montoIntereses, montoCapital });            


            if (planPago.SaldoIntereses > 0.00m || planPago.SaldoIvaIntereses > 0.00m)
            {
                /** Pago Intereses **/
                if (planPago.SaldoIntereses > 0 && saldoMonto < planPago.SaldoIntereses)
                {
                    montoIntereses += saldoMonto;
                    saldoMonto = 0.0m;
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
            }) ;
        }

        private decimal AbonarExcedente(decimal cuotaIvaIntereses, decimal cuotaIntereses, decimal cuotaCapital, ref decimal montoExcedente, ref decimal montoIvaIntereses, ref decimal montoIntereses, ref decimal montoCapital)
        {
            if (montoExcedente >= (cuotaIntereses + cuotaIvaIntereses))
            {
                montoIvaIntereses += cuotaIvaIntereses;
                montoIntereses += cuotaIntereses;
                montoExcedente -= cuotaIvaIntereses + cuotaIntereses;
            } else
            {
                montoIvaIntereses += montoExcedente * 0.12m;
                montoIntereses += montoExcedente - montoIvaIntereses;
                montoExcedente -= cuotaIvaIntereses + cuotaIntereses;
            }

            if (montoExcedente >= cuotaCapital)
            {
                montoCapital += cuotaCapital;                
                montoExcedente -= cuotaCapital;
            }
            else if(montoExcedente > 0 && cuotaCapital > montoExcedente)
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

                interestFee = principalAmount * (interestRate * 0.01m) / 12;
                principalFee = principalAmount / term;
                //administrativeExpensesFee = subTotalFee * (administrativeExpensesRate * 0.01m);
                taxFee = interestFee * (taxRate * 0.01m);
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
            prestamo.TasaInteres = createPaymentPlanDto.TasaInteres;
            prestamo.TasaIva = createPaymentPlanDto.TasaIva;
            prestamo.TasaMora = createPaymentPlanDto.TasaMora;
            prestamo.TasaGastos = createPaymentPlanDto.TasaGastos;
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
            var registroPago = _mapper.Map<RegistroCaja>(createRegistroCajaDto);

            _unitOfWork.Repository<RegistroCaja>().Add(registroPago);

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            var planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).FirstOrDefaultAsync();

            if (planPago != null)
            {
                var ultimoEstadoCuenta = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == createRegistroCajaDto.PrestamoId).OrderByDescending(e => e.Id).FirstOrDefaultAsync();
                var saldoActual = ultimoEstadoCuenta.SaldoActual;

                if (createRegistroCajaDto.MontoMora > 0)
                {
                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 5, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaMora, "Cargo Iva Mora", createRegistroCajaDto.AppUserId, saldoActual);

                    /** Abono Iva Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 12, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaMora, "Abono Iva Mora", createRegistroCajaDto.AppUserId, saldoActual);

                    saldoActual = await CargoEstadoCuenta(createRegistroCajaDto.PrestamoId, 4, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoMora, "Cargo Mora", createRegistroCajaDto.AppUserId, saldoActual);

                    /** Abono Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 11, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoMora, "Abono Mora", createRegistroCajaDto.AppUserId, saldoActual);
                }

                if (createRegistroCajaDto.MontoIvaIntereses > 0)
                {
                    /** Abono Iva Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 10, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaIntereses, "Abono Iva Intereses", createRegistroCajaDto.AppUserId, saldoActual);
                }

                if (createRegistroCajaDto.MontoInteres > 0)
                {
                    /** Abono Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 9, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoInteres, "Abono Intereses", createRegistroCajaDto.AppUserId, saldoActual);
                }

                if (createRegistroCajaDto.MontoCapital > 0)
                {
                    /** Abono Capital **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 8, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoCapital, "Abono Capital", createRegistroCajaDto.AppUserId, saldoActual);
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

                if (plan.SaldoCapital < 1 && plan.SaldoIntereses < 1  && plan.SaldoIvaIntereses < 1
                    && plan.SaldoMora < 1 && plan.SaldoIvaMora < 1 && plan.SaldoGastos < 1 && plan.SaldoIvaGastos <1 )
                {
                    plan.Aplicado = true;
                }
                _unitOfWork.Repository<PlanPago>().Update(plan);

            }

            
            await _unitOfWork.Complete();
            
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

            var planPago = await _dbContext.PlanPagos.Where(p => p.Id == createRegistroCajaDto.PlanPagoId).FirstOrDefaultAsync();

            if (planPago != null)
            {
                var ultimoEstadoCuenta = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == createRegistroCajaDto.PrestamoId).OrderByDescending(e => e.Id).FirstOrDefaultAsync();
                var saldoActual = ultimoEstadoCuenta.SaldoActual;

                if (createRegistroCajaDto.TipoTransaccionId == 17)
                {
                    /** Abono Ajuste Iva Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 17, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Iva Intereses", createRegistroCajaDto.AppUserId, saldoActual);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 20)
                {
                    /** Abono Ajuste Intereses **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 20, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Intereses", createRegistroCajaDto.AppUserId, saldoActual);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 21)
                {
                    /** Abono Ajuste Iva Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 21, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Iva Mora", createRegistroCajaDto.AppUserId, saldoActual);
                }

                if (createRegistroCajaDto.TipoTransaccionId == 22)
                {
                    /** Abono Ajuste Mora **/
                    saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 22, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoPago, "Exoneración de Mora", createRegistroCajaDto.AppUserId, saldoActual);
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

        private async Task<decimal> AbonoEstadoCuenta(int prestamoId, int tipoTransaccionId, int registroCajaId, int planPagoId, decimal monto, string concepto, string appUserId, decimal saldoActual)
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

            CuotaAbonoPlan(estadoCuenta.Id, planPagoId, tipoTransaccionId, monto);


            return estadoCuenta.SaldoActual;
        }

        private async Task<decimal> CargoEstadoCuenta(int prestamoId, int tipoTransaccionId, int registroCajaId, int planPagoId, decimal monto, string concepto, string appUserId, decimal saldoActual)
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

        private async void CuotaAbonoPlan(int estadoCuentaId, int planPagoId, int tipoTransaccionId, decimal monto)
        {
            decimal cuotaCapital = 0, cuotaIntereses = 0, cuotaIvaIntereses = 0, cuotaMora = 0, cuotaIvaMora = 0, cuotaGastos = 0, cuotaIvaGastos = 0;

            if (tipoTransaccionId == 8) cuotaCapital = monto;
            if (tipoTransaccionId == 9 || tipoTransaccionId == 20 ||tipoTransaccionId == 24) cuotaIntereses = monto;
            if (tipoTransaccionId == 10 || tipoTransaccionId == 17 || tipoTransaccionId == 23) cuotaIvaIntereses = monto;
            if (tipoTransaccionId == 11) cuotaMora = monto;
            if (tipoTransaccionId == 12) cuotaIvaMora = monto;

            var cuotaAbono = new AbonoPlan
            {
                EstadoCuentaId = estadoCuentaId,
                PlanPagoId = planPagoId,
                CuotaCapital = cuotaCapital,
                CuotaIntereses = cuotaIntereses,
                CuotaIvaIntereses = cuotaIvaIntereses,
                CuotaMora = cuotaMora,
                CuotaIvaMora = cuotaIvaMora,
                CuotaGastos = cuotaGastos,
                CuotaIvaGastos = cuotaIvaGastos
            };

            await _dbContext.AbonoPlanes.AddAsync(cuotaAbono);           
        }

        [HttpGet("liquidar_credito/{creditoId}")]
        public async Task<ActionResult<object>> LiquidaCredito(int creditoId)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"sp_sct_payAllCurrentDebtAndCloseLoan {creditoId}");
           
            return Ok(new { Mensaje = "Accion Realizada Satisfactoriamente" });
        }
    }
}
