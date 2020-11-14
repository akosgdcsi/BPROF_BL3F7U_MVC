using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;

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
    }
}
