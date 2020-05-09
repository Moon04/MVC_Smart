using MVC.DAL;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        ModelContext ctx = new ModelContext();

        // GET: Employee
        [HttpGet]
        public ViewResult Index()
        {
            return View(ctx.Employees.ToList());
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            if (ModelState.IsValid)
            {
                ctx.Employees.Add(emp);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}