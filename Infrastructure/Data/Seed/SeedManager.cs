using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed;

public static class SeedManager
{
    public static void Seed(ModelBuilder builder)
    {
        TipoPrestamoSeed.Seed(builder);
    }
}