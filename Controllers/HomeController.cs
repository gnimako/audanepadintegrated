using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
       // [Route("/{redirecttext}")]
        [AllowAnonymous]
        public IActionResult Index()
        {


            return RedirectToAction("Login", "Account");
          
        }

/*         public IActionResult Index(string redirecttext)
        {
            return RedirectToAction("Login", "Account", new { redirectid = redirecttext });
        } */

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
