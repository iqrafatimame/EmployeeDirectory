using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

    }
}
