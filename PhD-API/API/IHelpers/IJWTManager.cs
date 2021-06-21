using Domain.Entities;

namespace API.IHelpers
{
    public interface IJWTManager
    {
        public string GenerateToken(User user);
        public string GenerateToken(Researcher researcher);
    }
}
