using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OptumPresence.Domain.Entities;
using OptumPresence.Models.Shared;

namespace OptumPresence.Models.Dashboard
{
    public class DashboardViewModel : ViewModelBase
    {
        public DashboardViewModel()
        {
            this.ScheduleDays = new List<ScheduleListViewModel>();
            this.SelectedDate = base.CurrentDate;
        }

        public DateTime SelectedDate { get; set; }
        public List<ScheduleListViewModel> ScheduleDays { get; set; }
        public long TeamUID {
            get
            {
                return base.CurrentUser.Team.TeamUID;
            }
            set
            {
                base.CurrentUser.Team.TeamUID = value;
            }
        }
    }
}