namespace API.DTO.AnswerMultiCheckbox
{
    public class AnswerMultiCheckboxForGetDTO
    {
        public int Id { get; set; }
        public int ResearchId { get; set; }
        public int AnswerId { get; set; }
        public bool Checked1 { get; set; }
        public bool Checked2 { get; set; }
        public int QuestionId { get; set; }
        public string Radio { get; set; }
    }
}
