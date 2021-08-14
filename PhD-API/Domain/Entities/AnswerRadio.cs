namespace Domain.Entities
{
    public class AnswerRadio : BaseEntity
    {
        public int ResearchId { get; set; }
        public Research Research { get; set; }
        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
        public int QuestionId { get; set; }
    }
}
