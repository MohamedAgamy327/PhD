namespace API.DTO.Research
{
    public class ResearchForResultsGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public string Entity { get; set; }
        public string Address { get; set; }
        public int FullTimeEmployeesNumber { get; set; }
        public int PartTimeEmployeesNumber { get; set; }
        public int PhDResearchersNumber { get; set; }
        public int MastersResearchersNumber { get; set; }
        public int BachelorsResearchersNumber { get; set; }
        public int TechniciansNumber { get; set; }
        public bool CanEdit { get; set; }
        public int? AnswersCount { get; set; }
        public decimal? Q8 { get; set; }
        public decimal? Q9 { get; set; }
        public decimal? Q10 { get; set; }
        public decimal? Q12 { get; set; }
        public decimal? Q13 { get; set; }
        public decimal? Q14 { get; set; }
        public decimal? Q15 { get; set; }
        public decimal? Q16 { get; set; }
        public decimal? Q17 { get; set; }
        public decimal? First { get; set; }
        public decimal? Second { get; set; }
        public decimal? Third { get; set; }
        public decimal? Final { get; set; }
    }
}
