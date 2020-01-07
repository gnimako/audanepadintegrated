using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.ViewModels;
using AUDANEPAD_Integrated.Interfaces;


namespace AUDANEPAD_Integrated.Controllers
{
    public class AccountController: Controller
    {

		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext context;
        public AccountController(UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager, AppDbContext context,
            IEmployeeRepository employeeRepository)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
            this.context = context;
            this._employeeRepository = employeeRepository;
        }

        private readonly IEmployeeRepository _employeeRepository;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login2(string redirectid)
        {
            AppSelectViewModel model = new AppSelectViewModel
            {
                requestlogin=redirectid
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel
            {
                requestlogin="AUDA-NEPAD Annual Planning and Reporting"
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            model.requestlogin="AUDA-NEPAD Annual Planning and Reporting";
            model.RememberMe=true;

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email,
                    model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    //*****************Auditing******************//
                    var usr = await userManager.FindByNameAsync(model.Email);
                    Employee emp = _employeeRepository.GetEmployee(usr.Employee_Id);
                    string remoteIpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                    if (Request.Headers.ContainsKey("X-Forwarded-For"))
                        remoteIpAddress = Request.Headers["X-Forwarded-For"];


                    //*****************Auditing******************//var user = await userManager.FindByNameAsync(model.Email);


                    var user = await userManager.FindByNameAsync(model.Email);
                    if (user.Admin_Generated)
                    {
                        return RedirectToAction("resetpassword", "account");
                    }
                    else if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        if (await userManager.IsInRoleAsync(user, "Admin"))
                            return RedirectToAction("index", "admin");
                        else
                            return RedirectToAction("Login", "Account");

                    }
                    else
                    {
                        if (await userManager.IsInRoleAsync(user, "Admin"))
                            return RedirectToAction("index", "admin");
                        else
                            return RedirectToAction("Login", "Account");

                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);

        }

        [AllowAnonymous]
        public IActionResult LoginAssessment()
        {
            LoginViewModel model = new LoginViewModel
            {
                requestlogin="Impact Oriented Assessment"
            };
            return View(model);
        }
        // public IActionResult Login()
        // {

        //     return View();
        // }
        
    }

}