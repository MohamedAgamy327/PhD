namespace API.DTO.AnswerMultiAmount

{
    public class AnswerMultiAmountForGetDTO
    {
        public int Id { get; set; }
        public int ResearchId { get; set; }
        public int? AnswerId { get; set; }
        public int QuestionId { get; set; }
        public decimal? Amount { get; set; }
    }
}
