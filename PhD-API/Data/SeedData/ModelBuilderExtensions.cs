using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Utilities.StaticHelpers;

namespace Data.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SecurePassword.CreatePasswordHash("123123", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        Name = "Admin",
                        Email = "Admin@gmail.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        IsRandomPassword = true,
                        Role = RoleEnum.Admin
                    }
                );
        }
    }
}
