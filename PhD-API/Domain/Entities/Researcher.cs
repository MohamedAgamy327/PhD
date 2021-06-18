using Domain.Enums;

namespace Domain.Entities
{
    public class Researcher : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsRandomPassword { get; set; }
        public SearchStatusEnum SearchStatus { get; set; }
    }
}
