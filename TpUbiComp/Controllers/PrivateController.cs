using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpUbiComp.Data;
using TpUbiComp.Models.View_Models;

namespace TpUbiComp.Controllers
{
    public class PrivateController : Controller
    {
        private readonly UserContext _userContext;

        public PrivateController(/*UserContext userContext*/)
        {
            _userContext = new UserContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            //var user = _userContext.User.Where(u => u.Email == "" && u.Password == "").FirstOrDefault();
            return View();
        }

        public IActionResult City(int idCity)
        {
            var model = new CityModel();
            if (idCity == 1)
            {
                model.CityName = "Belo Horizonte";
                var avaliableApps = new List<ApplicationModel>();
                avaliableApps.Add(new ApplicationModel (){ ApplicationName = "Moovit", ApplicationUrl = "https://moovitapp.com/belo_horizonte-843/poi/en" });
                model.ApplicationList = avaliableApps;
                ViewData["Model"] = model;
                return View();
            }
            else if (idCity == 2)
            {
                model.CityName = "São Paulo";
                var avaliableApps = new List<ApplicationModel>();
                avaliableApps.Add(new ApplicationModel() { ApplicationName = "Moovit", ApplicationUrl = "https://moovitapp.com/sao_paulo-242/poi/en" });
                avaliableApps.Add(new ApplicationModel() { ApplicationName = "Trafi", ApplicationUrl = "https://web.trafi.com/br/saopaulo" });
                avaliableApps.Add(new ApplicationModel() { ApplicationName = "CityMapper", ApplicationUrl = "https://citymapper.com/sao-paulo" });
                model.ApplicationList = avaliableApps;
                ViewData["Model"] = model;
                return View();
            }
            else if (idCity == 3)
            {
                model.CityName = "Rio de Janeiro";
                var avaliableApps = new List<ApplicationModel>();
                avaliableApps.Add(new ApplicationModel() { ApplicationName = "Moovit", ApplicationUrl = "https://moovitapp.com/rio_de_janeiro-322/poi/en" });
                avaliableApps.Add(new ApplicationModel() { ApplicationName = "Trafi", ApplicationUrl = "https://web.trafi.com/br/rio" });
                model.ApplicationList = avaliableApps;
                ViewData["Model"] = model;
                return View();
            }
            else if (idCity == 4)
            {
                model.CityName = "Paris";
                var avaliableApps = new List<ApplicationModel>();
                avaliableApps.Add(new ApplicationModel() { ApplicationName = "Moovit", ApplicationUrl = "https://moovitapp.com/paris-662/poi/en" });
                avaliableApps.Add(new ApplicationModel() { ApplicationName = "CityMapper", ApplicationUrl = "https://citymapper.com/paris?set_region=fr-paris" });
                avaliableApps.Add(new ApplicationModel() { ApplicationName = "Vélib", ApplicationUrl = "https://www.velib-metropole.fr/pt/map#/" });
                model.ApplicationList = avaliableApps;
                ViewData["Model"] = model;
                return View();
            }
            ViewData["Model"] = new CityModel();
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
