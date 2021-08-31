using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TpUbiComp.Data;
using TpUbiComp.Models;
using TpUbiComp.Models.View_Models;

namespace TpUbiComp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _userContext;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userContext = new UserContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            return View("Privacy");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult SignUp()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CreateUser(DTONewUser newUser)
        {
            _userContext.Add(new { FistName = newUser.Name, Email = newUser.Eamil, Password = newUser.Password });
            _userContext.SaveChanges();
            return View("Index");
        }

        public IActionResult ForgotPassword()
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
