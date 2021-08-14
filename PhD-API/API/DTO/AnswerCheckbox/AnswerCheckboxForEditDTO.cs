namespace API.DTO.AnswerCheckbox
{
    public class AnswerCheckboxForEditDTO
    {
        public int Id { get; set; }
        public int? AnswerId { get; set; }
        public int QuestionId { get; set; }
        public bool Checked { get; set; }
    }
}
