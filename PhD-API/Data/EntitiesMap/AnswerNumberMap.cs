using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesMap
{
    public class AnswerNumberMap : IEntityTypeConfiguration<AnswerNumber>
    {
        public void Configure(EntityTypeBuilder<AnswerNumber> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.QuestionId).IsRequired();
            builder.Property(t => t.ResearchId).IsRequired();
            builder.HasOne(s => s.Research).WithMany(s => s.AnswerNumbers).HasForeignKey(s => s.ResearchId);
        }
    }
}
