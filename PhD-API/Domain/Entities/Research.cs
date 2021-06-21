using Domain.Enums;

namespace Domain.Entities
{
    public class Research : BaseEntity
    {
        public SearchStatusEnum SearchStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
