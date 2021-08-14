namespace API.DTO.AnswerNumber
{
    public class AnswerNumberForGetDTO
    {
        public int Id { get; set; }
        public int ResearchId { get; set; }
        public int? Number { get; set; }
        public int QuestionId { get; set; }
    }
}
