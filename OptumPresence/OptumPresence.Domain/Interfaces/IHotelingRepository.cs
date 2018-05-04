using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptumPresence.Domain.Entities;

namespace OptumPresence.Domain.Interfaces
{
    public interface IHotelingRepository
    {
        /// <summary>
        /// Get all schedules by team and month (1-12)
        /// </summary>
        /// <param name="teamUid"></param>
        /// <param name="startDate"></param>
        /// /// <param name="endDate"></param>
        /// <returns></returns>
        List<ScheduleEntity> GetSchedulesByTeamDateRange(long teamUid, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Adds a new schedule to db.
        /// </summary>
        /// <param name="scheduleEntity"></param>
        /// <returns></returns>
        bool AddSchedule(ScheduleEntity scheduleEntity);

        /// <summary>
        /// Updates existing schedule in db.
        /// </summary>
        /// <param name="scheduleEntity"></param>
        /// <returns></returns>
        bool UpdateSchedule(ScheduleEntity scheduleEntity);
    }
}
