using EmployeeDirectoryProj.Data;
using EmployeeDirectoryProj.Models;
using EmployeeDirectoryProj.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Repositories
{
    public class EmployeeRepository: Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task GetEmployeeName()
        {
            throw new NotImplementedException();
        }


    }
}
