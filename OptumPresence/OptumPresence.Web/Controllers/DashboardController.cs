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
            DashboardViewModel viewModel = new DashboardViewModel();
            viewModel.CurrentUser = user;
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
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
            
            return View();
        }
    }
}