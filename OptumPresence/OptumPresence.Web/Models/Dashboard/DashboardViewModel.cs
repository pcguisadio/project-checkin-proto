using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OptumPresence.Models.Shared;

namespace OptumPresence.Models.Dashboard
{
    public class DashboardViewModel : ViewModelBase
    {
        public DateTime SelectedDate { get; set; }
        public List<ScheduleListViewModel> ScheduleDays { get; set; }
    }
}