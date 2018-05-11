using OptumPresence.Data.EntityModels;
using OptumPresence.Domain.Entities;

namespace OptumPresence.Data.Hoteling.Mappers
{
    /// <summary>
    /// Mapper class for user data
    /// </summary>
    public class HotelingMapper : IHotelingMapper
    {
        public void DataToBusiness(tbl4Schedule schedule, ScheduleEntity scheduleEntity)
        {
            if (scheduleEntity != null && schedule != null)
            {
                scheduleEntity.ScheduleUID = schedule.ScheduleUID;
                scheduleEntity.ScheduleDate = schedule.ScheduleDate;
                scheduleEntity.ApplicationDate = schedule.ApplicationDate;
                scheduleEntity.ApprovedBy = schedule.ApprovedBy;
                this.DataToBusiness(schedule.tbl4Status, scheduleEntity.Status);
            }
        }

        public void DataToBusiness(tbl4Status status, StatusEntity statusEntity)
        {
            if (statusEntity != null && status != null)
            {
                statusEntity.StatusUID = status.StatusUID;
                statusEntity.StatusDescription = status.StatusDescription;
            }
        }
    }
}
