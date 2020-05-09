using MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Models
{

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(130)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [Range(2000, 10000)]
        public int Salary { get; set; }

        public Gender? Gender { get; set; }
    }
}