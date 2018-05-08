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

        //POST: NextMonth()
        [HttpPost]
        public ActionResult NextMonth(DashboardViewModel viewModel)
        {
            DateTime nextMonth = viewModel.SelectedDate.AddMonths(1);
            DateTime startDate = new DateTime(nextMonth.Year, nextMonth.Month, 1);
            DateTime endDate = new DateTime(nextMonth.Year, nextMonth.Month, DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month));
            return View("Index", this.PrepareScheduleData(viewModel.CurrentUser, startDate, endDate));
        }

        //POST: PreviousMonth()
        [HttpPost]
        public ActionResult PreviousMonth(DashboardViewModel viewModel)
        {
            DateTime nextMonth = viewModel.SelectedDate.AddMonths(-1);
            DateTime startDate = new DateTime(nextMonth.Year, nextMonth.Month, 1);
            DateTime endDate = new DateTime(nextMonth.Year, nextMonth.Month, DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month));
            return View("Index", this.PrepareScheduleData(viewModel.CurrentUser, startDate, endDate));
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
                    Schedules = scheds.Where(sched => sched.ScheduleDate.Equals(startDate)).ToList()
                };
                viewModel.ScheduleDays.Add(scheduleListViewModel);
                startDate = startDate.AddDays(1);
            } while (startDate < endDate);

            viewModel.SelectedDate = 
                viewModel.CurrentDate.Month == startDate.Month &&
                viewModel.CurrentDate.Year == startDate.Year 
                    ? viewModel.CurrentDate : startDate;

            return viewModel;
        }
    }
}