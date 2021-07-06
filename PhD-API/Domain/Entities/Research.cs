﻿using Domain.Enums;

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
        public ResearchStatusEnum Status { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
