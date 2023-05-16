using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed;

public static class UsersSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var users = new AppUser[]
        {
            new()
            {
                Id = "c44ab09d-9b73-4ea9-9191-064c903ac294",
                PersonaId = 1,
                UserName = "user@example.com",
                NormalizedUserName = "USER@EXAMPLE.COM",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEDTdljWg8MONBgC2PsrNPXLd6cOkQSwl8lAG69T1gHxFKSf75bihF/rOzt7P/hGu2A==",
                SecurityStamp = "NWJLHEJLBLE32NELL55BUTYT5VUGH4BT",
                ConcurrencyStamp = "901ccf30-20ec-4565-abfe-8db39ab1c597",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
        };

        builder.Entity<AppUser>().HasData(users);
    }
}