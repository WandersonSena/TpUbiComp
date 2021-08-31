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

        public PrivateController()
        {
            _userContext = new UserContext();
        }

        public IActionResult Index()
        {
            var cities = _userContext.Locale.ToList();
            ViewData["Model"] = cities;
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public IActionResult City(int idCity)
        {
            var model = new CityModel();            
            var locale = _userContext.Locale.Where(l => l.Id == idCity).FirstOrDefault();
            var aplicationLocale = _userContext.ApplicationLocale
                .Where(a => a.Locale == locale)
                .Join(
                    _userContext.Application,
                    appLocale => appLocale.Application,
                    application => application,
                    (appLocale, application) => new
                    {
                        ApplicationName = application.Name,
                        ApplicationUrl = appLocale.Url,
                        Locale = appLocale.Locale
                    }
                ).ToList();
            var avaliableApps = new List<ApplicationModel>();
            foreach (var app in aplicationLocale)
                avaliableApps.Add(new ApplicationModel (){ ApplicationName = app.ApplicationName, ApplicationUrl = app.ApplicationUrl });

            model.CityName = locale.City;
            model.ApplicationList = avaliableApps;
            ViewData["Model"] = model;
            return View();            
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult BuyCredits()
        {
            return View();
        }
    }
}
