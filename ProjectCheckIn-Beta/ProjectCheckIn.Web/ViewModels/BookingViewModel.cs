using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ProjectCheckIn_Beta.Models;

namespace ProjectCheckIn_Beta.ViewModels
{
    public class BookingViewModel
    {
        public Booking Booking { get; set; }
        public string MemberName { get; set; }
        public string MemberPosition { get; set; }
    }
}