using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Connecting.To.Database.Models
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    };

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }
        public int Salary { get; set; }
        public Gender Gender { get; set; }
    }
}