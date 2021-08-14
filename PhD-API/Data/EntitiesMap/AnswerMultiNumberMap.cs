using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesMap
{
    public class AnswerMultiAmountMap : IEntityTypeConfiguration<AnswerMultiAmount>
    {
        public void Configure(EntityTypeBuilder<AnswerMultiAmount> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.QuestionId).IsRequired();
            builder.Property(t => t.ResearchId).IsRequired();
            builder.HasOne(s => s.Research).WithMany(s => s.AnswerMultiAmounts).HasForeignKey(s => s.ResearchId);
            builder.HasOne(s => s.Answer).WithMany(s => s.AnswerMultiAmounts).HasForeignKey(s => s.AnswerId);
        }
    }
}
