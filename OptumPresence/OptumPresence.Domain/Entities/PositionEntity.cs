using OptumPresence.Domain.Common;

namespace OptumPresence.Domain.Entities
{
    public class PositionEntity : EntityBase
    {
        public long PositionUID { get; set; }
        public string PositionName { get; set; }
    }
}
