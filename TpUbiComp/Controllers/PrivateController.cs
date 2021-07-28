using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpUbiComp.Models.View_Models;

namespace TpUbiComp.Controllers
{
    public class PrivateController : Controller
    {
        public IActionResult Index()
        {
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
                avaliableApps.Add(new ApplicationModel() { ApplicationName = "CityMapper", ApplicationUrl = "https://citymapper.com/directions?startcoord=-23.550377%2C-46.633962&endcoord=-23.550377%2C-46.633962&startname=Pra%C3%A7a+da+S%C3%A9&endname=Pra%C3%A7a+da+S%C3%A9&startaddress=Pra%C3%A7a+da+S%C3%A9%2C+S%C3%A3o+Paulo&endaddress=Pra%C3%A7a+da+S%C3%A9%2C+S%C3%A3o+Paulo" });
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
            ViewData["Model"] = new CityModel();
            return View();
        }
    }
}
