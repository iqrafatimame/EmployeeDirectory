using EmployeeDirectoryProj.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAllAsync();
        Task<EmployeeViewModel> GetByIdAsync(int id);
        Task AddAsync(EmployeeViewModel todo);
        Task RemoveAsync(int id);
        Task UpdateAsync(EmployeeViewModel todo);
    }
}
