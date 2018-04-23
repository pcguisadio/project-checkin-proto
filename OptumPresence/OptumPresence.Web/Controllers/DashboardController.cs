using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OptumPresence.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Index()
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }
            return View();
        }
    }
}