using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class EmployeeViewModel
    {
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
    }
}