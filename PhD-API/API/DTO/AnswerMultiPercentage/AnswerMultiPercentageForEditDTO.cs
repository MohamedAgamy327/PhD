namespace API.DTO.AnswerMultiPercentage
{
    public class AnswerMultiPercentageForEditDTO
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public double? Number1 { get; set; }
        public double? Number2 { get; set; }
        public int QuestionId { get; set; }
        public string Radio { get; set; }
    }
}
