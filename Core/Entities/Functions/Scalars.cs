using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Functions
{
    public static class Scalars
    {
        public static void RegisterFunctions(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => CalculateFee(0.0m, 0.0m, 0));
            modelBuilder.HasDbFunction(() => FxSaldoPrestamoListado(0));
        }

        public static decimal CalculateFee(decimal capital, decimal InterestAnnual, int payments)
        {
            return 0.0m;
        }

        public static decimal FxSaldoPrestamoListado(int prestamoId)
        {
            return 0.0m;
        }
    }
}
