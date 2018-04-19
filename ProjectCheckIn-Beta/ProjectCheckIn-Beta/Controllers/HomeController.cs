using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProjectCheckIn_Beta.Models;
using ProjectCheckIn_Beta.ViewModels;

namespace ProjectCheckIn_Beta.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Initial Week Display
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            BookingCalendarViewModel viewModel = new BookingCalendarViewModel();
            using (MainDbContext dbContext = new MainDbContext())
            {
                //Get bookings 2 Weeks from today 
                var bookings = dbContext.Bookings.Where(x => x.DesiredDate >= DateTime.Now && x.DesiredDate < DateTime.Now.AddDays(14))
                    .OrderBy(x => x.DesiredDate).ToList();
                //Prepare week data
                if (bookings.Count() > 0)
                {
                    DateTime date = bookings.First().DesiredDate;
                    int workDays = 0;
                    do
                    {
                        BookingDayViewModel bdViewModel = new BookingDayViewModel();
                        bdViewModel.Date = date;
                        bdViewModel.Bookings = new List<BookingViewModel>();
                        if (date.DayOfWeek != DayOfWeek.Saturday 
                            && date.DayOfWeek != DayOfWeek.Sunday
                            && bookings.Any(x => x.DesiredDate == date))
                        {
                            //group all bookings for this day
                            bdViewModel.Bookings.AddRange(
                                bookings.Where(x => x.DesiredDate == date).Select(x => new BookingViewModel
                                {
                                    Booking = x,
                                    MemberName = dbContext.Members.Find(x.MemberID).LastName,
                                    MemberPosition = dbContext.Members.Find(x.MemberID).Position
                                }).ToList()
                            );
                            workDays++;
                        }
                        date = date.AddDays(1);
                    } while (workDays < 5 || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
                }
            }
            return View();
        }
    }
}