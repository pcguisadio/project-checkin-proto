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
            this.ScheduleDays = new Dictionary<int, ScheduleListViewModel>();
            this.SelectedDate = base.CurrentDate;
            this.CurrentUser = new UserEntity();
        }

        public DateTime SelectedDate { get; set; }
        public Dictionary<int, ScheduleListViewModel> ScheduleDays { get; set; }
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

        public bool IsApprover
        {
            get { return this.CurrentUser.Position.PositionUID == 1 || this.CurrentUser.Position.PositionUID == 2; }
        }
    }
}