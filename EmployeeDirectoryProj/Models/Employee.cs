using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name is Required")]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
  
        public Department departments { get; set; }
    }
}
