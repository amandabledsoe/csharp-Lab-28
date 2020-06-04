using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab28_SWapi.Models;

namespace Lab28_SWapi.Controllers
{
    public class HomeController : Controller
    {
        //remove logger info and add context to your data access layers
        private readonly PersonDal PD = new PersonDal();
        private readonly PlanetDal PL = new PlanetDal();
        //now go add the forms onto the index page.
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetPersonById(int id)
        {
            Person person = PD.GetPerson("people", id);
            return View(person);
        }

        [HttpPost]
        public IActionResult GetPlanetById(int id)
        {
            Planet planet = PL.GetPlanet("planets", id);
            return View(planet);
        }

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
