using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesMap
{
    public class AnswerRadioMap : IEntityTypeConfiguration<AnswerRadio>
    {
        public void Configure(EntityTypeBuilder<AnswerRadio> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(s => s.Research).WithMany(s => s.AnswerRadios).HasForeignKey(s => s.ResearchId);
            builder.HasOne(s => s.Answer).WithMany(s => s.AnswerRadios).HasForeignKey(s => s.AnswerId);
        }
    }
}
