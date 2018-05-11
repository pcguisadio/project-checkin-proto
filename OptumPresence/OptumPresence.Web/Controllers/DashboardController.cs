using OptumPresence.Domain.Interfaces;
using OptumPresence.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OptumPresence.Domain.Entities;

namespace OptumPresence.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IHotelingRepository _hotelingRepository;

        public DashboardController(IUserRepository userRepository, IHotelingRepository hotelingRepository)
        {
            this._userRepository = userRepository;
            this._hotelingRepository = hotelingRepository;
        }

        // GET: Index()
        public ActionResult Index()
        {
            UserEntity user = null;
            if (Session["Username"] != null)
            {
                user = _userRepository.GetUserByUsername(Session["Username"].ToString());
            }
             
            if (user == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            //Get scheds and prepare view model

            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            DashboardViewModel viewModel = this.PrepareScheduleData(user, startDate, endDate);

            return View(viewModel);
        }

        // GET: Index(startDate)
        public ActionResult GetSchedules(DateTime selectedDate)
        {
            UserEntity user = null;
            if (Session["Username"] != null)
            {
                user = _userRepository.GetUserByUsername(Session["Username"].ToString());
            }

            if (user == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            //Get scheds and prepare view model
            DateTime startDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            DateTime endDate = new DateTime(selectedDate.Year, selectedDate.Month,
                DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month));
            DashboardViewModel viewModel = this.PrepareScheduleData(user, startDate, endDate);

            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult AddSchedule(DateTime date)
        {
            UserEntity user = null;
            if (Session["Username"] != null)
            {
                user = _userRepository.GetUserByUsername(Session["Username"].ToString());
            }

            if (user == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            bool addSuccess = _hotelingRepository.AddSchedule(new ScheduleEntity()
            {
                User = user,
                ScheduleDate = date,
                ApplicationDate = DateTime.Now,
                Status = new StatusEntity() { StatusUID = 1},
                RecordCreateDate = DateTime.Now,
                RecordCreateUserId = user.Username,
                RecordUpdateDate = DateTime.Now,
                RecordUpdateUserId = user.Username
            });

            return Json(new {success = addSuccess });
        }

        [HttpPost]
        public ActionResult UpdateSchedule(long scheduleUid, short statusUid)
        {
            UserEntity user = null;
            if (Session["Username"] != null)
            {
                user = _userRepository.GetUserByUsername(Session["Username"].ToString());
            }

            if (user == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            bool updateSuccess = _hotelingRepository.UpdateSchedule(new ScheduleEntity()
            {
                User = user,
                ScheduleUID = scheduleUid,
                Status = new StatusEntity() { StatusUID = statusUid },
                ApprovedBy = statusUid == 2 ? user.Username : null,
                RecordUpdateDate = DateTime.Now,
                RecordUpdateUserId = user.Username
            });

            return Json(new { success = updateSuccess });
        }

        /// <summary>
        /// Prepares Dashboard view model based on schedule search params.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private DashboardViewModel PrepareScheduleData(UserEntity user, DateTime startDate, DateTime endDate)
        {
            DashboardViewModel viewModel = new DashboardViewModel();
            viewModel.CurrentUser = user;

            var scheds =
                this._hotelingRepository.GetSchedulesByTeamDateRange(user.Team.TeamUID, startDate, endDate);
            do
            {
                ScheduleListViewModel scheduleListViewModel = new ScheduleListViewModel()
                {
                    Date = startDate,
                    Schedules = scheds.Where(sched => sched.ScheduleDate.Equals(startDate)).ToList(),
                    CurrentUser = user
                };
                viewModel.ScheduleDays.Add(startDate.Day, scheduleListViewModel);
                startDate = startDate.AddDays(1);
            } while (startDate <= endDate);
            startDate = startDate.AddMonths(-1);

            viewModel.SelectedDate = 
                viewModel.CurrentDate.Month == startDate.Month &&
                viewModel.CurrentDate.Year == startDate.Year 
                    ? viewModel.CurrentDate : startDate;

            return viewModel;
        }
    }
}