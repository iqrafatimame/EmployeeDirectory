using EmployeeDirectoryProj.Data;
using EmployeeDirectoryProj.Models;
using EmployeeDirectoryProj.Services.Interfaces;
using EmployeeDirectoryProj.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Controllers
{
    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _context;

        public EmployeeController(IEmployeeService employeeService, ApplicationDbContext context)
        {
            _employeeService = employeeService;
            _context = context;
        }
        
       
        public async Task<IActionResult> Index()
        {
            var emp = await _employeeService.GetAllAsync();
            return View(emp);
        }
        
        // GET: Todos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _employeeService.GetByIdAsync(id.GetValueOrDefault());
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
            ViewBag.DepartmentID = _context.Departments.Select(x => new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.DepartmentID.ToString()
            }).ToList();
            return View();
        }

        // POST: Add employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel emp)
        {
            
            ViewBag.DepartmentID = _context.Departments.Select(x => new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.DepartmentID.ToString()
            }).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.AddAsync(emp);
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong{ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, $"Something went wrong invalid model");
            return View(emp);
        }


        // GET: Edit department
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.DepartmentID = _context.Departments.Select(x => new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.DepartmentID.ToString()
            }).ToList();

            if (id == null)
            {
                return NotFound();
            }
            var exist = await _employeeService.GetByIdAsync(id.GetValueOrDefault());
            if (exist == null)
            {
                return NotFound();
            }
            return View(exist);
        }


        // POST: Edit department
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel dep)
        {
            if (id != dep.DepartmentID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.UpdateAsync(dep);
                }
                catch (Exception ex)
                {
                    if (await _employeeService.GetByIdAsync(dep.DepartmentID) == null)
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
            var exist = await _employeeService.GetByIdAsync(id.GetValueOrDefault());
            if (exist == null)
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
            await _employeeService.RemoveAsync(id);
            return RedirectToAction("index");
        }
    }
}
