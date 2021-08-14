using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesMap
{
    public class AnswerCheckboxMap : IEntityTypeConfiguration<AnswerCheckbox>
    {
        public void Configure(EntityTypeBuilder<AnswerCheckbox> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.QuestionId).IsRequired();
            builder.Property(t => t.ResearchId).IsRequired();
            builder.Property(t => t.Checked).HasDefaultValue(false);
            builder.HasOne(s => s.Research).WithMany(s => s.AnswerCheckboxs).HasForeignKey(s => s.ResearchId);
            builder.HasOne(s => s.Answer).WithMany(s => s.AnswerCheckboxs).HasForeignKey(s => s.AnswerId);
        }
    }
}
