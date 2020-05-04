using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registeration.Form.Controllers
{
    public class Attendee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AttendingOption { get; set; }
    }

    public class HomeController : Controller
    {
       
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RegisterForm()
        {
            return View("RegisterForm");
        }

        [HttpPost]
        public ViewResult RegisterForm(Attendee attendee)
        {
            if (attendee != null && attendee.Name != null)
            {
                ViewBag.Name = attendee.Name;
                return View("Successful");
            }
            return View("RegisterForm");
        }
    }
}