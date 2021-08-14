namespace Domain.Entities
{
    public class AnswerCheckbox : BaseEntity
    {
        public int ResearchId { get; set; }
        public Research Research { get; set; }
        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
        public bool Checked { get; set; }
        public int QuestionId { get; set; }
    }
}
