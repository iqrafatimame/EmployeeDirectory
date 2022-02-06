using EmployeeDirectoryProj.Data;
using EmployeeDirectoryProj.Models;
using EmployeeDirectoryProj.Services.Interfaces;
using EmployeeDirectoryProj.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Controllers
{
    
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        public DepartmentController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllAsync();
            return View(departments);
        }

        // GET: Todos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _departmentService.GetByIdAsync(id.GetValueOrDefault());
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Create Action to add Info to our database
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Add department
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel dep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.AddAsync(dep);
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong{ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, $"Something went wrong invalid model");
            return View(dep);
        }


        // GET: Edit department
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var exist = await _departmentService.GetByIdAsync(id.GetValueOrDefault());
            if (exist == null)
            {
                return NotFound();
            }
            return View(exist);
        }


        // POST: Edit department
        [HttpPost]
        public async Task<IActionResult> Edit(int id, DepartmentViewModel dep)
        {
            if (id != dep.DepartmentID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.UpdateAsync(dep);
                }
                catch (Exception ex)
                {
                    if (await _departmentService.GetByIdAsync(dep.DepartmentID) == null)
                    {
                        ModelState.AddModelError(string.Empty, $"Something went wrong{ex.Message}");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("index");
            }
            ModelState.AddModelError(string.Empty, $"Something went wrong invalid model");
            return View(dep);
        }

        // GET: Delete a department
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var exist = await _departmentService.GetByIdAsync(id.GetValueOrDefault());
            if(exist == null)
            {
                return NotFound();
            }
            return View(exist);
        }


        // POST: Delete a department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.RemoveAsync(id);
            return RedirectToAction("index");
        }
    }
}
