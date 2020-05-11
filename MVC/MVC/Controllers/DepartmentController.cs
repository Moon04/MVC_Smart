using MVC.DAL;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DepartmentController : Controller
    {
        ModelContext ctx = new ModelContext();

        // GET: Department
        public ActionResult Index()
        {
            List<Department> departments = ctx.Departments.ToList();

            return View(departments);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("DepartmentForm");
        }

        [HttpPost]
        public ActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                ctx.Departments.Add(department);
                ctx.SaveChanges();
                TempData["Message"] = "Department Added Successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "Add";
            return View("DepartmentForm", department);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Department department = ctx.Departments.Find(id);
            if (department != null)
            {
                ViewBag.Action = "Edit";
                return View("DepartmentForm", department);
            }

            return HttpNotFound("Department Not Found");
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                ctx.Departments.Attach(department);
                ctx.Entry(department).State = EntityState.Modified;
                ctx.SaveChanges();
                TempData["Message"] = "Department Edited Successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "Edit";
            return View("DepartmentForm", department);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Department department = ctx.Departments.Find(id);
            if (department != null)
            {
                ctx.Departments.Remove(department);
                ctx.SaveChanges();
                return Json(true);
            }

            return HttpNotFound("Department Not Found");
        }
    }
}