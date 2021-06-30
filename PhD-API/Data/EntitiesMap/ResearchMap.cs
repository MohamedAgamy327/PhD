using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesMap
{
    public class ResearchMap : IEntityTypeConfiguration<Research>
    {
        public void Configure(EntityTypeBuilder<Research> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.IsRandomPassword).HasDefaultValue(true);
        }
    }
}
