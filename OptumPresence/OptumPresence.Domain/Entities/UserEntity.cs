using OptumPresence.Domain.Common;

namespace OptumPresence.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public PositionEntity Position { get; set; }
        public TeamEntity Team { get; set; }
    }
}
