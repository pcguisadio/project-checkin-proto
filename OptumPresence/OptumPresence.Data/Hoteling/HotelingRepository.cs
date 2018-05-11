using OptumPresence.Data.Encryption;
using OptumPresence.Data.EntityModels;
using OptumPresence.Domain.Entities;
using OptumPresence.Domain.Interfaces;
using System;
using System.Linq;
using OptumPresence.Data.Hoteling.Mappers;
using System.Collections.Generic;
using OptumPresence.Data.Users.Mappers;

namespace OptumPresence.Data.Hoteling
{
    public class HotelingRepository : IHotelingRepository
    {
        #region Constants and Variables

        /// <summary>
        /// The data mapper for hoteling data.
        /// </summary>
        private readonly IHotelingMapper _hotelingMapper;

        /// <summary>
        /// The data mapper for user data.
        /// </summary>
        private readonly IUserMapper _userMapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Repository Constructor with mapper setting
        /// </summary>
        /// <param name="hotelingMapper"></param>
        public HotelingRepository(IHotelingMapper hotelingMapper, IUserMapper userMapper)
        {
            this._hotelingMapper = hotelingMapper;
            this._userMapper = userMapper;
        }
        #endregion

        #region Methods
        public bool AddSchedule(ScheduleEntity scheduleEntity)
        {
            bool success = false;
            try
            {
                using (HotelingDataContext dbContext = new HotelingDataContext())
                {
                    //Check for duplicates
                    if (!dbContext.tbl4Schedules.Any(sched => sched.ScheduleDate.Equals(scheduleEntity.ScheduleDate) && sched.UserUID == scheduleEntity.User.UserUID))
                    {
                        dbContext.tbl4Schedules.InsertOnSubmit(new tbl4Schedule
                        {
                            UserUID = scheduleEntity.User.UserUID,
                            ScheduleDate = scheduleEntity.ScheduleDate,
                            ApplicationDate = scheduleEntity.ApplicationDate,
                            StatusUID = scheduleEntity.Status.StatusUID,
                            RecordCreateUserID = scheduleEntity.RecordCreateUserId,
                            RecordCreateDate = scheduleEntity.RecordCreateDate,
                            RecordUpdateDate = scheduleEntity.RecordUpdateDate,
                            RecordUpdateUserID = scheduleEntity.RecordUpdateUserId
                        });
                        dbContext.SubmitChanges();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement error logging.
                success = false;
            }

            return success;
        }

        public List<ScheduleEntity> GetSchedulesByTeamDateRange(long teamUid, DateTime startDate, DateTime endDate)
        {
            List<ScheduleEntity> result = new List<ScheduleEntity>();
            using (HotelingDataContext dbContext = new HotelingDataContext())
            {
                var query = dbContext.tbl4Schedules.Where(sched =>
                    sched.tbl4User.TeamUID == teamUid && sched.ScheduleDate >= startDate && sched.ScheduleDate <= endDate).OrderBy(order => order.ScheduleDate).ToList();
                foreach (tbl4Schedule schedule in query)
                {
                    ScheduleEntity scheduleEntity = new ScheduleEntity();
                    this._hotelingMapper.DataToBusiness(schedule, scheduleEntity);
                    this._userMapper.DataToBusiness(schedule.tbl4User, scheduleEntity.User);

                    result.Add(scheduleEntity);
                }
            }
            return result;
        }

        public bool UpdateSchedule(ScheduleEntity scheduleEntity)
        {
            bool success = false;
            try
            {
                using (HotelingDataContext dbContext = new HotelingDataContext())
                {
                    tbl4Schedule schedule = dbContext.tbl4Schedules.First(sched => sched.ScheduleUID == scheduleEntity.ScheduleUID);
                    if (schedule != null)
                    {
                        schedule.StatusUID = scheduleEntity.Status.StatusUID;
                        schedule.RecordUpdateDate = scheduleEntity.RecordUpdateDate;
                        schedule.RecordUpdateUserID = scheduleEntity.RecordUpdateUserId;
                        dbContext.SubmitChanges();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement error logging.
                success = false;
            }

            return success;
        }
        #endregion
    }
}
