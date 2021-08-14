namespace API.DTO.AnswerRadio
{
    public class AnswerRadioForGetDTO
    {
        public int Id { get; set; }
        public int ResearchId { get; set; }
        public int? AnswerId { get; set; }
        public int QuestionId { get; set; }
    }
}
