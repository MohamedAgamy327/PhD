namespace API.DTO.AnswerCheckbox
{
    public class AnswerCheckboxForGetDTO
    {
        public int Id { get; set; }
        public int ResearchId { get; set; }
        public int? AnswerId { get; set; }
        public int QuestionId { get; set; }
        public bool Checked { get; set; }
    }
}
