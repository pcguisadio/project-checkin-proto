using System;
using OptumPresence.Domain.Common;

namespace OptumPresence.Domain.Entities
{
    public class ScheduleEntity : EntityBase
    {
        public ScheduleEntity()
        {
            this.User = new UserEntity();
            this.Status = new StatusEntity();
        }
        public long ScheduleUID { get; set; }
        public UserEntity User { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public StatusEntity Status { get; set; }
        public string ApprovedBy { get; set; }
    }
}
