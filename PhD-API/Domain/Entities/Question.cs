using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Question : BaseEntity
    {
        public int? Order { get; set; }
        public string Content { get; set; }
        public QuestionTypeNum Type { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
