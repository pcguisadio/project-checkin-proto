using OptumPresence.Data.EntityModels;
using OptumPresence.Domain.Entities;

namespace OptumPresence.Data.Hoteling.Mappers
{
    /// <summary>
    /// Mapper class for user data
    /// </summary>
    public class HotelingMapper : IHotelingMapper
    {
        public void DataToBusiness(Schedule schedule, ScheduleEntity scheduleEntity)
        {
            if (scheduleEntity != null && schedule != null)
            {
                scheduleEntity.ScheduleUID = schedule.ScheduleUID;
                scheduleEntity.ScheduleDate = schedule.ScheduleDate;
                scheduleEntity.ApplicationDate = schedule.ApplicationDate;
                scheduleEntity.ApprovedBy = schedule.ApprovedBy;
                this.DataToBusiness(schedule.Status, scheduleEntity.Status);
            }
        }

        public void DataToBusiness(Status status, StatusEntity statusEntity)
        {
            if (statusEntity != null && status != null)
            {
                statusEntity.StatusUID = status.StatusUID;
                statusEntity.StatusDescription = status.StatusDescription;
            }
        }
    }
}
