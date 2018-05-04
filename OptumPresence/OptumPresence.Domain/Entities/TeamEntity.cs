using OptumPresence.Domain.Common;

namespace OptumPresence.Domain.Entities
{
    public class TeamEntity : EntityBase
    {
        public long TeamUID { get; set; }
        public string TeamName { get; set; }
    }
}
