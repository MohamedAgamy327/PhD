﻿namespace API.DTO.AnswerMultiPercentage
{
    public class AnswerMultiPercentageForEditDTO
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public decimal? Number1 { get; set; }
        public decimal? Number2 { get; set; }
        public int QuestionId { get; set; }
        public string Radio { get; set; }
    }
}