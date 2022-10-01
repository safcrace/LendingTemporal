using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Functions;
using Core.Entities.Views;
using Core.Interfaces;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

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
                                          Nombre = per.Nombres + " " + per.Apellidos,
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
                                          TasaIva = pre.TasaIva
                                      }).ToListAsync();

                var agenteP = await (from pre in _dbContext.Prestamos
                                     join ent in _dbContext.Entidades on pre.GestorPrestamoId equals ent.Id
                                     join per in _dbContext.Personas on ent.Id equals per.EntidadId
                                     where pre.Id == id
                                     select new
                                     {
                                         Nombre = per.Nombres + " " + per.Apellidos,

                                     }).FirstOrDefaultAsync();

                return Ok(new { lendingP, agenteP });
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


            //{
            //    PrestamoId = p.Id,
            //    Nombre = p.Persona.Nombres + " " + p.Persona.Apellidos,
            //    DPI = p.Persona.NumeroDocumento,
            //    p.Persona.Direccion,
            //    p.Persona.NumeroTelefono,
            //    p.Persona.NIT,
            //    EstadoCivil = p.Persona.EstadoCivil.Nombre,
            //    EstadoPrestamo = p.EstadoPresamo.Nombre,
            //    NombreGestor = p.Gestor.Nombre,
            //    MontoTotal = p.MontoCapital,
            //    p.SaldoCapital,
            //    p.SaldoIntereses,
            //    p.SaldoGastosAdministrativos,
            //    p.SaldoIva
            //}).FirstOrDefaultAsync(p => p.PrestamoId == id);   
        }

        [HttpGet("saldos/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetSaldos(int prestamoId)
        {
            var saldosPrestamo =await _dbContext.Prestamos.Where(p => p.Id == prestamoId).FirstOrDefaultAsync();

            var saldoCapital = saldosPrestamo.MontoOtorgado;
            var saldoInteres = saldosPrestamo.InteresProyectado;
            var saldoIvaInteres = saldosPrestamo.IvaProyectado;
            var saldoMora = 0;
            var saldoIvaMora =0;

            var pagoCapital = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == prestamoId && e.TipoTransaccionId == 8).SumAsync(e => e.Abono);
            var pagoInteres = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == prestamoId && e.TipoTransaccionId == 9).SumAsync(e => e.Abono);
            var pagoIvaInteres = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == prestamoId && e.TipoTransaccionId == 10).SumAsync(e => e.Abono);

            saldoCapital -= pagoCapital;
            saldoInteres -= pagoInteres;
            saldoIvaInteres -= pagoIvaInteres;

            return Ok(new { SaldoCapital = saldoCapital, SaldoIntereses = saldoInteres, SaldoIvaInteres = saldoIvaInteres, SaldoMora = saldoMora, SaldoIvaMora = saldoIvaMora });

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
        public async Task<ActionResult<object>> GetDistribuyePago(int prestamoId, decimal montoPago)
        {
            decimal saldoMonto = montoPago; 
            decimal montoMora = 0.0m, montoIvaMora = 0.0m, montoIntereses = 0.0m, montoIvaIntereses = 0.0m , montoCapital = 0.0m;

            var planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == prestamoId && p.Aplicado == false).FirstOrDefaultAsync();
            
            if (saldoMonto >= planPago.CuotaMora)
            {
                saldoMonto -= planPago.CuotaMora;
                montoMora = planPago.CuotaMora;
            }
            
            if (saldoMonto >= planPago.CuotaIvaMora)
            {
                saldoMonto -= planPago.CuotaIvaMora;
                montoIvaMora = planPago.CuotaIvaMora;
            }

            if (saldoMonto >= planPago.CuotaIntereses)
            {
                saldoMonto -= planPago.CuotaIntereses;
                montoIntereses = planPago.CuotaIntereses;
            }

            if (saldoMonto >= planPago.CuotaIvaIntereses)
            {
                saldoMonto -= planPago.CuotaIvaIntereses;
                montoIvaIntereses = planPago.CuotaIvaIntereses;
            }

            if (saldoMonto >= planPago.CuotaCapital)
            {
                saldoMonto -= planPago.CuotaCapital;
                montoCapital = planPago.CuotaCapital;
            } 



            var EstadoCredito = await _dbContext.Prestamos.Where(p => p.Id == planPago.PrestamoId).Select(p => p.EstadoPrestamo.Nombre).FirstOrDefaultAsync();

            //var desgloce = new
            //{                
            //    MontoPago = montoPago,
            //    PagoCapital = montoCapital,
            //    PagoCapitalAnticipado = 0.00,
            //    PagoIntereses = planPago.CuotaIntereses,
            //    PagoIvaIntereses = planPago.CuotaIvaIntereses,
            //    PagoMora = planPago.CuotaMora,
            //    PagoIvaMora = planPago.CuotaIvaMora,
            //    TotalGastos = planPago.CuotaGastos,
            //    IvaGastos = planPago.CuotaIvaGastos,
            //    SaldoTotalPagar = planPago.SaldoTotal,                                
            //    FechaProximoPago = planPago.FechaPago,
            //    DiasMora =  0,                
            //    EstadoCredito = await _dbContext.Prestamos.Where(p => p.Id == planPago.PrestamoId).Select(p => p.EstadoPrestamo.Nombre).FirstOrDefaultAsync(),               
            //    TotalCuotasVencidas = 0,
            //    CuotasVencidasPagadas = 0                
            //};


            return Ok(new {
                            MontoPago = montoPago, 
                            PagoCapital = montoCapital,
                            PagoCapitalAnticipado = 0.00,
                            PagoIntereses = montoIntereses,
                            PagoIvaIntereses = montoIvaIntereses,
                            PagoMora = montoMora,
                            PagoIvaMora = montoIvaMora,
                            TotalGastos = planPago.CuotaGastos,
                            IvaGastos = planPago.CuotaIvaGastos,
                            SaldoTotalPagar = planPago.SaldoTotal,
                            FechaProximoPago = planPago.FechaPago.AddMonths(1),
                            DiasMora = 0,
                            EstadoCredito = await _dbContext.Prestamos.Where(p => p.Id == planPago.PrestamoId).Select(p => p.EstadoPrestamo.Nombre).FirstOrDefaultAsync(),
                            TotalCuotasVencidas = 0,
                            CuotasVencidasPagadas = 0
            });
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

            var fechaPago = /*new DateTime(createPaymentPlanDto.StartDate.Year, createPaymentPlanDto.StartDate.Month, 2)*/createPaymentPlanDto.StartDate.AddMonths(1);//.AddDays(-1);

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
            var registroPago = _mapper.Map<RegistroCaja>(createRegistroCajaDto);


            _unitOfWork.Repository<RegistroCaja>().Add(registroPago);

            var result = await _unitOfWork.Complete();

            if (result < 0) return null!;

            var planPago = await _dbContext.PlanPagos.Where(p => p.PrestamoId == createRegistroCajaDto.PrestamoId && p.Aplicado == false).FirstOrDefaultAsync();

            if (planPago != null)
            {
                planPago.Aplicado = true;

                _unitOfWork.Repository<PlanPago>().Update(planPago);
            }          

            await _unitOfWork.Complete();


            var ultimoEstadoCuenta = await _dbContext.EstadoCuentas.Where(e => e.PrestamoId == createRegistroCajaDto.PrestamoId).OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            var saldoActual = ultimoEstadoCuenta.SaldoActual;

            /** Abono Iva Intereses **/
            saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 10, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoIvaIntereses, "Abono Iva Intereses", createRegistroCajaDto.AppUserId, saldoActual);

            /** Abono Intereses **/
            saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 9, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoInteres, "Abono Intereses", createRegistroCajaDto.AppUserId, saldoActual);

            /** Abono Capital **/
            saldoActual = await AbonoEstadoCuenta(createRegistroCajaDto.PrestamoId, 8, registroPago.Id, planPago.Id, createRegistroCajaDto.MontoCapital, "Abono Capital", createRegistroCajaDto.AppUserId, saldoActual);

            await _dbContext.SaveChangesAsync();
            return Ok(new { Mensaje = "Accion Realizada Satisfactoriamente" });
        }

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

        private async void CuotaAbonoPlan(int estadoCuentaId, int planPagoId, int tipoTransaccionId, decimal monto)
        {
            decimal cuotaCapital = 0, cuotaIntereses = 0, cuotaIvaIntereses = 0, cuotaMora = 0, cuotaIvaMora = 0, cuotaGastos = 0, cuotaIvaGastos = 0;

            if (tipoTransaccionId == 8) cuotaCapital = monto;
            if (tipoTransaccionId == 9) cuotaIntereses = monto;
            if (tipoTransaccionId == 10) cuotaIvaIntereses = monto;

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
    }
}
