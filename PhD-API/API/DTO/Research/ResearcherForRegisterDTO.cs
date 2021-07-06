﻿namespace API.DTO.Research
{
    public class ResearchForRegisterDTO
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
    }
}
