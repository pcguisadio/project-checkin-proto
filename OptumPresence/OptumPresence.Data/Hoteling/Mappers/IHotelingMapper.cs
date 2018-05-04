using OptumPresence.Data.EntityModels;
using OptumPresence.Domain.Entities;

namespace OptumPresence.Data.Hoteling.Mappers
{
    /// <summary>
    /// Interface for user data mappers
    /// </summary>
    public interface IHotelingMapper
    {
        /// <summary>
        /// Convert schedule data to schedule entity
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="scheduleEntity"></param>
        void DataToBusiness(Schedule schedule, ScheduleEntity scheduleEntity);

        /// <summary>
        /// Convert status data to status entity
        /// </summary>
        /// <param name="status"></param>
        /// <param name="statusEntity"></param>
        void DataToBusiness(Status status, StatusEntity statusEntity);
    }
}
