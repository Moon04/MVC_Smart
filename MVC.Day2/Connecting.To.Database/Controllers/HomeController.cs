using Connecting.To.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Connecting.To.Database.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AddEmployeeForm()
        {
            return View("AddEmployeeForm");
        }

        [HttpPost]
        public ViewResult AddEmployeeForm(Employee employee)
        {
            if (employee != null && employee.Name != null)
            {
                ModelContext ctx = new ModelContext();

                Employee newEmp = new Employee
                {
                    Name = employee.Name,
                    Address = employee.Address,
                    Salary = employee.Salary,
                    Gender = employee.Gender
                };

                ctx.Employees.Add(newEmp);
                ctx.SaveChanges();

                return View("Done");
            }
            return View("AddEmployeeForm");
        }
    }
}