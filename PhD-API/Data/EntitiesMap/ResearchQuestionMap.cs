using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesMap
{
    public class ResearchQuestionMap : IEntityTypeConfiguration<ResearchQuestion>
    {
        public void Configure(EntityTypeBuilder<ResearchQuestion> builder)
        {
            builder.HasKey(t => new { t.QuestionId, t.ResearchId});
            builder.HasOne(h => h.Question).WithMany(w => w.ResearchsQuestions).HasForeignKey(h => h.QuestionId);
            builder.HasOne(h => h.Research).WithMany(w => w.ResearchsQuestions).HasForeignKey(h => h.ResearchId);
        }
    }
}
