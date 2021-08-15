using System.Collections.Generic;

namespace Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswerRadio> AnswerRadios { get; set; }
        public ICollection<AnswerCheckbox> AnswerCheckboxs { get; set; }
        public ICollection<AnswerMultiAmount> AnswerMultiAmounts { get; set; }
        public ICollection<AnswerMultiPercentage> AnswerMultiPercentages { get; set; }
        public ICollection<AnswerMultiCheckbox> AnswerMultiCheckboxs { get; set; }
    }
}
