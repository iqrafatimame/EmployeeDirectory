using EmployeeDirectoryProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Repositories.Interfaces
{
    public interface IEmployeeRepository :IRepository<Employee>
    {
        Task GetEmployeeName();
    }
}
