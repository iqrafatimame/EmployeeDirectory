using EmployeeDirectoryProj.Data;
using EmployeeDirectoryProj.Models;
using EmployeeDirectoryProj.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Repositories
{
    public class DepartmentRepository: Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public  DepartmentRepository(ApplicationDbContext context) : base (context)
        {
            _context = context;
        }

        public Task GetDepartmentName()
        {
            throw new NotImplementedException();
        }
    }
}
