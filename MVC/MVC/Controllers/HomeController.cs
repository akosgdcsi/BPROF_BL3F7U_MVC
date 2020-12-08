using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        PlanetLogic planetLogic;
        StarLogic starLogic;
        SystemLogic systemLogic;

        public HomeController(PlanetLogic planetLogic, StarLogic starLogic, SystemLogic systemLogic)
        {
            this.planetLogic = planetLogic;
            this.starLogic = starLogic;
            this.systemLogic = systemLogic;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //System 
        public IActionResult AddSystem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSystem(Models.System s)
        {
            s.SystemID = Guid.NewGuid().ToString();
            
            systemLogic.AddSystem(s);
            return RedirectToAction(nameof(ListSystem));
        }
        [HttpGet]
        public IActionResult ListSystem()
        {

            return View(systemLogic.GetAllSystem());
        }

        [HttpGet]
        public IActionResult UpdateSystem(string id)
        {

            return View(nameof(UpdateSystem), systemLogic.GetSystem(id));
        }

        [HttpPost]

        public IActionResult UpdateSystem(Models.System s)
        {
            systemLogic.UpdateSystem(s.SystemID, s);

            return View(nameof(ListSystem), systemLogic.GetAllSystem());
        }
        //Star
        [HttpGet]
        public IActionResult AddStar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStar(Star s)
        {
            s.StarID = Guid.NewGuid().ToString();

            starLogic.AddStar(s);
            return RedirectToAction(nameof(ListStar));
        }
        [HttpGet]
        public IActionResult ListStar()
        {

            return View(starLogic.GetAllStar());
        }
        [HttpGet]
        public IActionResult UpdateStar(string id)
        {

            return View(nameof(UpdateStar), starLogic.GetStar(id));
        }

        [HttpPost]

        public IActionResult UpdateStar(Star s)
        {
            starLogic.UpdateStar(s.StarID, s);

            return View(nameof(ListStar), starLogic.StarToSystem(s.SystemID));
        }
        //Planet
        public IActionResult AddPlanet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPlanet(Planet p)
        {
            p.PlanetID = Guid.NewGuid().ToString();

            planetLogic.AddPlanet(p);
            return RedirectToAction(nameof(ListPlanet));
        }
        [HttpGet]
        public IActionResult ListPlanet()
        {

            return View(starLogic.GetAllStar());
        }
        
        [HttpGet]
        public IActionResult UpdatePlanet(string id)
        {

            return View(nameof(UpdatePlanet), planetLogic.GetPlanet(id));
        }

        [HttpPost]

        public IActionResult UpdatePlanet(Planet p)
        {
            planetLogic.UpdatePlanet(p.PlanetID, p);

            return View(nameof(ListPlanet), planetLogic.PlanetToStar(p.StarID));
        }
    }
}
