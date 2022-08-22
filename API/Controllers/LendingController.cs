using API.Dtos;
using Core.Entities;
using Core.Entities.Functions;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class LendingController : BaseApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public LendingController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost()]
        public async Task<ActionResult<object>> CreatePaymentPlan(CreatePaymentPlanDto createPaymentPlanDto)
        {
            decimal
                principalAmount = createPaymentPlanDto.PrincipalAmount,
                interestRate = createPaymentPlanDto.InterestRate, 
                administrativeExpensesRate = createPaymentPlanDto.AdministrativeExpesesRate, 
                taxRate = createPaymentPlanDto.TaxRate, 
                principalFee, interestFee, administrativeExpensesFee, taxFee, subTotalFee, totalFee, balance;

            int term = createPaymentPlanDto.Term;

            var fechaPago = /*new DateTime(createPaymentPlanDto.StartDate.Year, createPaymentPlanDto.StartDate.Month, 2)*/createPaymentPlanDto.StartDate.AddMonths(1);//.AddDays(-1);

            DetallePlanPagoTemporal projection = new DetallePlanPagoTemporal();


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
                        SubTotalCuota = subTotalFee,
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

                    fechaPago = new DateTime(fechaPago.Year, fechaPago.Month, 1);
                    fechaPago = fechaPago.AddMonths(1).AddDays(1);
                }

                projection = await _dbContext.DetallePlanPagoTemporales.Where(p => p.PlanPagoId == code.ToString()).FirstOrDefaultAsync();
            }


            return Ok(projection);
        }
    }
}
