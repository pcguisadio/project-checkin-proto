using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OptumPresence.Domain.Interfaces;
using OptumPresence.Models.Users;

namespace OptumPresence.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                return View("~/Views/Dashboard/Index.cshtml");
            }
            return View(new LoginViewModel());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Login Method
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                var user = _userRepository.GetUserByUsername(viewModel.Username);
                if (user == null || !user.Password.Equals(viewModel.Password))
                {
                    this.ModelState.AddModelError("Username", "Username or Password is incorrect.");
                }
                else
                {
                    //TODO: Make constant variables for session keys
                    Session["Username"] = user.Username;
                    viewModel.CurrentUser = user;
                    //TODO: prepare dashboard model and pass to view
                    return View("~/Views/Dashboard/Index.cshtml");
                }
            }
            return View("Index", viewModel);
        }

        /// <summary>
        /// Logout Method
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Clear();
            return View("Index", new LoginViewModel());
        }

        /// <summary>
        /// Navigate to change password screen
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangePassword()
        {
            //TODO: Make constant variables for session keys
            var sessionUsername = Session["Username"];
            LoginViewModel viewModel = new LoginViewModel();
            if (sessionUsername != null)
            {
                viewModel.Username = sessionUsername.ToString();
                return View(viewModel);
            }
            return View("Index", viewModel);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(LoginViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                //TODO: Create user service class and use it for validation and logic (transfer below logic codes)
                var user = _userRepository.GetUserByUsername(viewModel.Username);
                if (user == null)
                {
                    this.ModelState.AddModelError("Username", "Session invalid, Please Log In");
                    return View("Index", new LoginViewModel());
                }
                else if (!user.Password.Equals(viewModel.Password))
                {
                    this.ModelState.AddModelError("Password", "Password is incorrect.");
                }
                else if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
                {
                    this.ModelState.AddModelError("ConfirmPassword", "Password Does not Match");
                } 
                else
                {
                    user.Password = viewModel.NewPassword;
                    this._userRepository.ChangePassword(user);
                    viewModel.CurrentUser = user;
                    //TODO: prepare dashboard model and pass to view
                    return View("~/Views/Dashboard/Index.cshtml");
                }
            }
            return View(viewModel);
        }
    }
}