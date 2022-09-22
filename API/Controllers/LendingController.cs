using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Functions;
using Core.Interfaces;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
            if (createLendingDto.CreatePersonDto is null)
            {
                return null;
            }

            var persona = _mapper.Map<Persona>(createLendingDto.CreatePersonDto);            

            _unitOfWork.Repository<Persona>().Add(persona);

            var result = await _unitOfWork.Complete();

            if (result < 0) return null;

            createLendingDto.PersonaId = persona.Id;

            var prestamo = _mapper.Map<Prestamo>(createLendingDto);            

            _unitOfWork.Repository<Prestamo>().Add(prestamo);

            result = await _unitOfWork.Complete();

            if (result < 0) return null;

            return Ok(new { message = "Acción realizada Satisfactoriamente" });
        }


        [HttpGet()]
        public async Task<IEnumerable<object>> GetLendings()
        {
            var lendings = await _dbContext.Prestamos.Select(p => new {PrestamoId = p.Id, p.EstadoPresamo.Nombre, p.MontoCapital, p.SaldoCapital, Asesor = "", 
                                                                       PersonaId = p.Persona.Id, p.Persona.Nombres, p.Persona.Apellidos, p.Persona.NumeroDocumento}).ToListAsync();

            return lendings;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<object>> GetLendingById(int id)
        {
            var lending = await _dbContext.Prestamos.Select(p => new { PrestamoId = p.Id, Nombre = p.Persona.Nombres + " " +  p.Persona.Apellidos, DPI = p.Persona.NumeroDocumento, p.Persona.Direccion, p.Persona.NumeroTelefono, p.Persona.NIT,
                                                                       EstadoCivil = p.Persona.EstadoCivil.Nombre, EstadoPrestamo = p.EstadoPresamo.Nombre, NombreGestor = p.Gestor.Nombre , MontoTotal = p.MontoCapital, p.SaldoCapital, p.SaldoIntereses,
                                                                       p.SaldoGastosAdministrativos, p.SaldoIva }).FirstOrDefaultAsync(p => p.PrestamoId == id);

            return lending;
        }

        [HttpGet("plan_pago/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetPlanPago(int prestamoId)
        {
            return await _dbContext.PlanPagos.Join(_dbContext.DetallePlanPagos,
                                                   plan => plan.Id,
                                                   detalle => detalle.PlanPagoId,
                                                   (plan, detalle) => new
                                                   {
                                                       prestamoId = plan.PrestamoId,
                                                       detalle.Mes,
                                                       detalle.CuotaCapital,
                                                       detalle.CuotaIntereses,
                                                       detalle.CuotaGastosAdministrativos,
                                                       detalle.CuotaIva,
                                                       detalle.TotalCuota,
                                                       detalle.Saldo,
                                                       detalle.FechaPago,
                                                       detalle.Aplicado
                                                   }).Where(p => p.prestamoId == prestamoId).ToListAsync();            
        }

        [HttpGet("estado_cuenta/{prestamoId:int}")]
        public async Task<ActionResult<object>> GetEstadoCuenta(int prestamoId)
        {
            return await _dbContext.EstadoCuentas.Where(x => x.PrestamoId == prestamoId).Select(x =>  new
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
                subTotalFee = await _dbContext.Prestamos.Select(
                                            p => Scalars.CalculateFee(createPaymentPlanDto.PrincipalAmount, createPaymentPlanDto.InterestRate, createPaymentPlanDto.Term))
                                    .FirstOrDefaultAsync();                                
                
                interestFee = principalAmount * (interestRate * 0.01m)/12;
                principalFee = principalAmount / term;
                administrativeExpensesFee = subTotalFee * (administrativeExpensesRate * 0.01m);
                taxFee = interestFee * (taxRate * 0.01m);                
                totalFee = principalFee + interestFee + taxFee + administrativeExpensesFee;
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
                        CuotaGastosAdministrativos = administrativeExpensesFee,
                        CuotaIva = taxFee,
                        TotalCuota = totalFee,
                        Saldo = balance,
                        FechaPago = fechaPago
                    };

                    _dbContext.DetallePlanPagoTemporales.Add(temporal);
                    await _dbContext.SaveChangesAsync();

                    //interestFee = balance * (interestRate * 0.01m) / 12;
                    //principalFee = subTotalFee - interestFee;
                    balance = balance - principalFee;

                    if(balance < 0) { balance = 0; }

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
            var planPago = _mapper.Map<PlanPago>(createPaymentPlanDto);

            planPago.AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294";

            _unitOfWork.Repository<PlanPago>().Add(planPago);

            var result = await _unitOfWork.Complete();

            if (result < 0) return null;

            DetallePlanPago detallePlanPago = new DetallePlanPago();

            if (createPaymentPlanDto.PlanPagos != null)
            {
                foreach (var plan in createPaymentPlanDto.PlanPagos)
                {
                     detallePlanPago = _mapper.Map<DetallePlanPago>(plan);
                    detallePlanPago.PlanPagoId = planPago.Id;
                    _unitOfWork.Repository<DetallePlanPago>().Add(detallePlanPago);
                }
                result = await _unitOfWork.Complete();


                if (result < 0) return null;
            }

            planPago.MontoCapital = detallePlanPago.CuotaCapital * planPago.Plazo;
            planPago.SaldoIntereses = detallePlanPago.CuotaIntereses * planPago.Plazo;
            planPago.SaldoIva = detallePlanPago.CuotaIva * planPago.Plazo;
            planPago.SaldoGastosAdministrativos = detallePlanPago.CuotaGastosAdministrativos * planPago.Plazo;
            _unitOfWork.Repository<PlanPago>().Update(planPago);

            result = await _unitOfWork.Complete();

            /** Se Crea Estado de Cuenta **/

            EstadoCuenta estadoCuenta = new EstadoCuenta
            {
                AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PrestamoId = planPago.PrestamoId,
                TipoTransaccionId = 1,
                Cargo = planPago.MontoCapital,
                SaldoAnterior = 0,
                SaldoActual = planPago.MontoCapital,
                Concepto = "Monto Saldo Capital Inicial"
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

            estadoCuenta = new EstadoCuenta
            {
                AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PrestamoId = planPago.PrestamoId,
                TipoTransaccionId = 2,
                Cargo = planPago.SaldoIntereses,
                SaldoAnterior = planPago.MontoCapital,
                SaldoActual = planPago.MontoCapital + planPago.SaldoIntereses,
                Concepto = "Monto Saldo de Intereses Inicial"
            };

            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);            

            estadoCuenta = new EstadoCuenta
            {
                AppUserId = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PrestamoId = planPago.PrestamoId,
                TipoTransaccionId = 3,
                Cargo = planPago.SaldoIva,
                SaldoAnterior = planPago.MontoCapital + planPago.SaldoIntereses,
                SaldoActual = planPago.MontoCapital + planPago.SaldoIntereses + planPago.SaldoIva,
                Concepto = "Monto Saldo Iva Inicial"
            };
            
            _unitOfWork.Repository<EstadoCuenta>().Add(estadoCuenta);

             result = await _unitOfWork.Complete();

            var prestamo = await _unitOfWork.Repository<Prestamo>().GetByIdAsync(planPago.PrestamoId);

            prestamo.EstadoPrestamoId = 2;

            _unitOfWork.Repository<Prestamo>().Update(prestamo);

            result = await _unitOfWork.Complete();


            if (result < 0) return null;

            return Ok(new {message = "Acción realizada Satisfactoriamente" });
        }        
    }
}
