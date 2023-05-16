using Infrastructure.Data.Seed.Catalogs;
using Infrastructure.Seed.Catalogs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed;

public static class SeedManager
{
    public static void Seed(ModelBuilder builder)
    {
        EntidadSeed.Seed(builder);
        CompanySeed.Seed(builder);
        PersonsSeed.Seed(builder);
        UsersSeed.Seed(builder);
        TipoPrestamoSeed.Seed(builder);
        BankSeed.Seed(builder);
        CommonSeed.Seed(builder);
        CountriesSeed.Seed(builder);
        DepartmentSeed.Seed(builder);
        LendingSeed.Seed(builder);
        MunicipalitiesSeed.Seed(builder);
        OccupationsSeed.Seed(builder);
    }
}