using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsRandomPassword { get; set; }
        public RoleEnum Role { get; set; }
    }
}
