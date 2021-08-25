using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Research : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Entity { get; set; }
        public string Address { get; set; }
        public int FullTimeEmployeesNumber { get; set; }
        public int PartTimeEmployeesNumber { get; set; }
        public int PhDResearchersNumber { get; set; }
        public int MastersResearchersNumber { get; set; }
        public int BachelorsResearchersNumber { get; set; }
        public int TechniciansNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsRandomPassword { get; set; }
        public bool CanEdit { get; set; }
        public int? AnswersCount { get; set; }
        public ResearchStatusEnum Status { get; set; }
        public ICollection<AnswerRadio> AnswerRadios { get; set; }
        public ICollection<AnswerNumber> AnswerNumbers { get; set; }
        public ICollection<AnswerCheckbox> AnswerCheckboxs { get; set; }
        public ICollection<AnswerMultiAmount> AnswerMultiAmounts { get; set; }
        public ICollection<AnswerMultiPercentage> AnswerMultiPercentages { get; set; }
        public ICollection<AnswerMultiCheckbox> AnswerMultiCheckboxs { get; set; }
        public ICollection<ResearchQuestion> ResearchsQuestions { get; set; }
    }
}
