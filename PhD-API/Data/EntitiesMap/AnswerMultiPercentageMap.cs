using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesMap
{
    public class AnswerMultiPercentageMap : IEntityTypeConfiguration<AnswerMultiPercentage>
    {
        public void Configure(EntityTypeBuilder<AnswerMultiPercentage> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.QuestionId).IsRequired();
            builder.Property(t => t.ResearchId).IsRequired();
            builder.Property(t => t.Radio).HasDefaultValue(false);
            builder.HasOne(s => s.Research).WithMany(s => s.AnswerMultiPercentages).HasForeignKey(s => s.ResearchId);
            builder.HasOne(s => s.Answer).WithMany(s => s.AnswerMultiPercentages).HasForeignKey(s => s.AnswerId);
        }
    }
}
