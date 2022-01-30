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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAll();
            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }

        public async Task<EmployeeViewModel> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
                return null;
            return _mapper.Map<EmployeeViewModel>(employee);
        }

        public async Task RemoveAsync(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            _employeeRepository.Remove(employee);
            await _employeeRepository.SaveChangingAsync();
        }

        public async Task AddAsync(EmployeeViewModel employee)
        {
            var dbEmployee = _mapper.Map<Employee>(employee);
            _employeeRepository.Add(dbEmployee);
            await _employeeRepository.SaveChangingAsync();
        }
        public async Task UpdateAsync(EmployeeViewModel employee)
        {
            var dbEmployee = _mapper.Map<Employee>(employee);
            _employeeRepository.Update(dbEmployee);
            await _employeeRepository.SaveChangingAsync();
        }
    }
       
}
