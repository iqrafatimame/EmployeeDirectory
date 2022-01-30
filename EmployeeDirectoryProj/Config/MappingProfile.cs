using EmployeeDirectoryProj.Models;
using EmployeeDirectoryProj.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Config
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
        }
    }
}
