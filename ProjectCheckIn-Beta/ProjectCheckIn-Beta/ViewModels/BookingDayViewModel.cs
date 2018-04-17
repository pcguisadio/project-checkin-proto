using System;
using System.Collections.Generic;

namespace ProjectCheckIn_Beta.ViewModels
{
    public class BookingDayViewModel
    {
        public DateTime Date { get; set; }
        public List<BookingViewModel> Bookings { get; set; }
    }
}