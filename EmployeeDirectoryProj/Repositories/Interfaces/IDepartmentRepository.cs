using EmployeeDirectoryProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Repositories.Interfaces
{
    public interface IDepartmentRepository: IRepository<Department>
    {
        Task GetDepartmentName();
    }
}
