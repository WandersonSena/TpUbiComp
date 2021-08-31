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

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult SignUp()
        {
            return View();

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

        [HttpPost]
        public string Login(string email, string password)
        {
            var user = _userContext.User.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                TempData["userId"] = user.Id;
                HttpContext.Session.SetInt32("userId", user.Id);
                return "/private";
            }
            return "/";
        }

        [HttpPost]
        public string CreateUser(DTONewUser newUser)
        {
            _userContext.User.Add(new User()
            {
                FirstName = newUser.Name,
                Email = newUser.Email,
                Password = newUser.Password
            });
            _userContext.SaveChanges();

            return "/";
        }
    }
}
