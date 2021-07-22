using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesMap
{
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Content).IsRequired();
            builder.HasOne(s => s.Question).WithMany(s => s.Answers).HasForeignKey(s => s.QuestionId);
        }
    }
}
