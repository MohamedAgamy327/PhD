namespace Domain.Entities
{
    public class AnswerMultiAmount : BaseEntity
    {
        public int ResearchId { get; set; }
        public Research Research { get; set; }
        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
        public double? Amount { get; set; }
        public int QuestionId { get; set; }
    }
}
