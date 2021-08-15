namespace Domain.Entities
{
    public class AnswerMultiPercentage : BaseEntity
    {
        public int ResearchId { get; set; }
        public Research Research { get; set; }
        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
        public decimal? Number1 { get; set; }
        public decimal? Number2 { get; set; }
        public int QuestionId { get; set; }
        public bool Radio { get; set; }
    }
}
