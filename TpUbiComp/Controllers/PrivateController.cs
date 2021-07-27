using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpUbiComp.Controllers
{
    public class PrivateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
