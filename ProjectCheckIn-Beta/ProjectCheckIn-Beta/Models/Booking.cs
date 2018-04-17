using System;
using ProjectCheckIn_Beta.Enums;

namespace ProjectCheckIn_Beta.Models
{
    public class Booking
    {
        public long ID { get; set; }
        public long MemberID { get; set; }
        public DateTime DesiredDate { get; set; }
        public BookingStatus Status { get; set; }
    }
}