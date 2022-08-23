using Core.Entities;

namespace Core.Interfaces
{
    public interface IHelperRepository
    {
        /** Contactos **/       
        Task<IEnumerable<DetallePlanPagoTemporal>> GetDetailPaymentPlan(decimal principalAmount, decimal interestRate, decimal administrativeExpensesRate,
                                                                        decimal taxRate, int term, DateTime payDay);
    }
}
