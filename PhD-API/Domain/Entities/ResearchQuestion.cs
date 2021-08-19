namespace Domain.Entities
{
    public class ResearchQuestion
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int ResearchId { get; set; }
        public Research Research { get; set; }
    }
}
