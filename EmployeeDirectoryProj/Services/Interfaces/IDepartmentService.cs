using EmployeeDirectoryProj.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task AddAsync(DepartmentViewModel todo);
        Task RemoveAsync(int id);
        Task UpdateAsync(DepartmentViewModel todo);
    }
}
