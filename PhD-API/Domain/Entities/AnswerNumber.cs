﻿namespace Domain.Entities
{
    public class AnswerNumber : BaseEntity
    {
        public int ResearchId { get; set; }
        public Research Research { get; set; }
        public int? Number { get; set; }
        public int QuestionId { get; set; }
    }
}
