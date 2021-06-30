using Domain.Enums;

namespace Domain.Entities
{
    public class Research : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsRandomPassword { get; set; }
        public ResearchStatusEnum Status { get; set; }
    }
}
