using OptumPresence.Domain.Entities;
using OptumPresence.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptumPresence.Models.Dashboard
{
    public class ScheduleListViewModel : ViewModelBase
    {
        public DateTime Date { get; set; }
        public List<ScheduleEntity> Schedules;
    }
}