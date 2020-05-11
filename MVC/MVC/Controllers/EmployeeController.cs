using MVC.DAL;
using MVC.Models;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            EmployeeViewModel empVM = new EmployeeViewModel
            {
                Employees = ctx.Employees.ToList(),
                Departments = ctx.Departments.ToList()
            };
            return View(empVM);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            EmployeeViewModel empVM = new EmployeeViewModel
            {
                Departments = ctx.Departments.ToList()
            };
            return View("EmployeeForm", empVM);
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ctx.Employees.Add(employee);
                ctx.SaveChanges();
                TempData["Message"] = "Employee Added Successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "Add";
            EmployeeViewModel empVM = new EmployeeViewModel
            {
                Departments = ctx.Departments.ToList()
            };
            return View("EmployeeForm", empVM);
        }

        [HttpPost]
        public ActionResult AddAjax(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ctx.Employees.Add(employee);
                ctx.SaveChanges();
                return PartialView("_EmployeePartial", employee);
            }

            return Json(ModelState);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee emp = ctx.Employees.Find(id);
            if (emp != null)
            {
                ViewBag.Action = "Edit";
                EmployeeViewModel empVM = new EmployeeViewModel
                {
                    Departments = ctx.Departments.ToList(),
                    Employee = emp
                };
                return View("EmployeeForm", empVM);
            }

            return HttpNotFound("Emloyee Not Found");
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ctx.Employees.Attach(employee);
                ctx.Entry(employee).State = EntityState.Modified;
                ctx.SaveChanges();
                TempData["Message"] = "Employee Edited Successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "Edit";
            EmployeeViewModel empVM = new EmployeeViewModel
            {
                Departments = ctx.Departments.ToList(),
                Employee = employee
            };
            return View("EmployeeForm", empVM);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee emp = ctx.Employees.Find(id);
            if (emp != null)
            {
                ctx.Employees.Remove(emp);
                ctx.SaveChanges();
                return Json(true);
            }

            return HttpNotFound("Emloyee Not Found");
        }
    }
}