using OptumPresence.Domain.Common;

namespace OptumPresence.Domain.Entities
{
    public class StatusEntity : EntityBase
    {
        public short StatusUID { get; set; }
        public string StatusDescription { get; set; }
    }
}
