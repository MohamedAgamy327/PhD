using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesMap
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Role).IsRequired();
            builder.Property(t => t.IsRandomPassword).HasDefaultValue(true);
            builder.Property(t => t.Role).HasDefaultValue(RoleEnum.Admin);
            builder.Property(t => t.PasswordHash).IsRequired();
            builder.Property(t => t.PasswordSalt).IsRequired();
        }
    }
}
