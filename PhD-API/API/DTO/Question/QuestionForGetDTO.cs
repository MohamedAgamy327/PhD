using API.DTO.Answer;
using System.Collections.Generic;

namespace API.DTO.Question
{
    public class QuestionForGetDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public ICollection<AnswerForGetDTO> Answers { get; set; }
    }
}
