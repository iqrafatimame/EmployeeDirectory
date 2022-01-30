using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Name is Require.")]
        [MinLength(3, ErrorMessage = "Minimum 3 characters are allowed.")]
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
