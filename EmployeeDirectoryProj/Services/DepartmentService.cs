using AutoMapper;
using EmployeeDirectoryProj.Models;
using EmployeeDirectoryProj.Repositories.Interfaces;
using EmployeeDirectoryProj.Services.Interfaces;
using EmployeeDirectoryProj.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository todoRepository, IMapper mapper)
        {
            _departmentRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            var todos = await _departmentRepository.GetAll();
            return _mapper.Map<List<DepartmentViewModel>>(todos);
        }

        public async Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            var todo = await _departmentRepository.GetById(id);
            if (todo == null)
                return null;
            return _mapper.Map<DepartmentViewModel>(todo);
        }

        public async Task RemoveAsync(int id)
        {
            var todo = await _departmentRepository.GetById(id);
            _departmentRepository.Remove(todo);
            await _departmentRepository.SaveChangingAsync();
        }

        public async Task AddAsync(DepartmentViewModel todo)
        {
            var dbTodo = _mapper.Map<Department>(todo);
            _departmentRepository.Add(dbTodo);
            await _departmentRepository.SaveChangingAsync();
        }
        public async Task UpdateAsync(DepartmentViewModel todo)
        {
            var dbTodo = _mapper.Map<Department>(todo);
            _departmentRepository.Update(dbTodo);
            await _departmentRepository.SaveChangingAsync();
        }
        
    }
}
