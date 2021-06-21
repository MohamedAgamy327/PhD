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
            builder.Property(t => t.SearchStatus).IsRequired();
            builder.HasOne(d => d.User).WithOne(w => w.Research).HasForeignKey<Research>(h => h.UserId);
        }
    }
}
