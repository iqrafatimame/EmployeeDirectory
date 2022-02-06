using EmployeeDirectoryProj.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryProj.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: REgister User
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register User
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                try
                {
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "Employee").Wait();
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            return View(model);
        }

        // GET: Login User
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // POST : Login User
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                try {
                    var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                    if (result.Succeeded)
                    {
                        var findUser = await _userManager.FindByEmailAsync(user.Email);
                        var roles = await _userManager.GetRolesAsync(findUser);
                        string role = roles.FirstOrDefault();
                        if (role.Equals("Admin")) 
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if(role.Equals("Employee"))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return NotFound();
                        } 
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                } 
            }
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
