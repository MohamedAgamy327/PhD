namespace Domain.Entities
{
    public class AnswerMultiCheckbox : BaseEntity
    {
        public int ResearchId { get; set; }
        public Research Research { get; set; }
        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
        public bool Checked1 { get; set; }
        public bool Checked2 { get; set; }
        public int QuestionId { get; set; }
        public bool Radio { get; set; }
    }
}
