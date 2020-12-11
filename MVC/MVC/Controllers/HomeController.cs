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
        static bool filled = true;
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
        public IActionResult DeleteSystem(string id)
        {
            systemLogic.DeleteSystem(id);
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
        public IActionResult DeleteStar(string id)
        {
            starLogic.DeleteStar(id);
            return View(nameof(ListStar), starLogic.GetAllStar());
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

            return View(planetLogic.GetAllPlanet());
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
        public IActionResult DeletePlanet(string id)
        {
            planetLogic.DeletePlanet(id);
            return View(nameof(ListPlanet), planetLogic.GetAllPlanet());
        }
        //data filler
        [HttpGet]
        public IActionResult FillWithData()
        {
            if (filled)
            {
                //1. system

                Models.System sys1 = new Models.System() { SystemID = Guid.NewGuid().ToString(), Name = "Illinium", SectorName = "B-123" };
                systemLogic.AddSystem(sys1);
                
                // 1. star 
                Star s1 = new Star() { StarID = Guid.NewGuid().ToString(), Name = "Galo", Age = 1000000, StarType = StarType.Red_Dwarfs, SystemID = sys1.SystemID };
                starLogic.AddStar(s1);
                
                Planet p1 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Kepler-6543B2", Habitable = true, PlanetType = PlanetType.Terran, Population = 10, StarID = s1.StarID };
                planetLogic.AddPlanet(p1);
                Planet p2 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Branco", Habitable = false, PlanetType = PlanetType.Superterran, Population = 0, StarID = s1.StarID };
                planetLogic.AddPlanet(p2);
                Planet p3 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Elizabeth", Habitable = false, PlanetType = PlanetType.Jovian, Population = 0, StarID = s1.StarID };
                planetLogic.AddPlanet(p3);
                Planet p4 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Gemini-65422A", Habitable = false, PlanetType = PlanetType.Superterran, Population = 0, StarID = s1.StarID };
                planetLogic.AddPlanet(p4);
                Planet p5 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Pisces-493294", Habitable = false, PlanetType = PlanetType.Jovian, Population = 0, StarID = s1.StarID };
                planetLogic.AddPlanet(p5);

                //2. star 
                Star s2 = new Star() { StarID = Guid.NewGuid().ToString(), Name = "Re", Age = 1000000000, StarType = StarType.Yellow_Dwarfs, SystemID = sys1.SystemID };
                starLogic.AddStar(s2);
                Planet p6 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Kepler-6543B2", Habitable = true, PlanetType = PlanetType.Terran, Population = 0, StarID = s2.StarID };
                planetLogic.AddPlanet(p6);
                Planet p7 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Branco", Habitable = false, PlanetType = PlanetType.Superterran, Population = 0, StarID = s2.StarID };
                planetLogic.AddPlanet(p7);
                Planet p8 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Elizabeth", Habitable = false, PlanetType = PlanetType.Jovian, Population = 0, StarID = s2.StarID };
                planetLogic.AddPlanet(p8);
                Planet p9 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Gemini-65422A", Habitable = false, PlanetType = PlanetType.Superterran, Population = 0, StarID = s2.StarID };
                planetLogic.AddPlanet(p9);
                Planet p10 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Pisces-493294", Habitable = false, PlanetType = PlanetType.Jovian, Population = 0, StarID = s2.StarID };
                planetLogic.AddPlanet(p10);

                //3. star

                Star s3 = new Star() { StarID = Guid.NewGuid().ToString(), Name = "Draco", Age = 56500000, StarType = StarType.Orange_Dwarfs, SystemID = sys1.SystemID };
                starLogic.AddStar(s3);

                Planet p11 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Kepler-6543B2", Habitable = true, PlanetType = PlanetType.Terran, Population = 0, StarID = s3.StarID };
                planetLogic.AddPlanet(p11);
                Planet p12 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Branco", Habitable = false, PlanetType = PlanetType.Superterran, Population = 0, StarID = s3.StarID };
                planetLogic.AddPlanet(p12);
                Planet p13 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Elizabeth", Habitable = false, PlanetType = PlanetType.Jovian, Population = 0, StarID = s3.StarID };
                planetLogic.AddPlanet(p13);
                Planet p14 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Gemini-65422A", Habitable = false, PlanetType = PlanetType.Superterran, Population = 0, StarID = s3.StarID };
                planetLogic.AddPlanet(p14);
                Planet p15 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Pisces-493294", Habitable = false, PlanetType = PlanetType.Jovian, Population = 0, StarID = s3.StarID };
                planetLogic.AddPlanet(p15);

                //2. system
                Models.System sys2 = new Models.System() { SystemID = Guid.NewGuid().ToString(), Name = "Scorpius", SectorName = "B-125" };
                systemLogic.AddSystem(sys2);
                ;
                //4. star sys 2
                Star s4 = new Star() { StarID = Guid.NewGuid().ToString(), Name = "Leo", Age = 1000000, StarType = StarType.Red_Dwarfs, SystemID = sys2.SystemID };
                starLogic.AddStar(s4);
                Planet p17 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Branco", Habitable = false, PlanetType = PlanetType.Superterran, Population = 0, StarID = s4.StarID };
                planetLogic.AddPlanet(p17);
                Planet p18 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Elizabeth", Habitable = false, PlanetType = PlanetType.Jovian, Population = 0, StarID = s4.StarID };
                planetLogic.AddPlanet(p18);
                Planet p19 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Gemini-65422A", Habitable = false, PlanetType = PlanetType.Superterran, Population = 0, StarID = s4.StarID };
                planetLogic.AddPlanet(p19);
                Planet p20 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Pisces-493294", Habitable = false, PlanetType = PlanetType.Jovian, Population = 0, StarID = s4.StarID };
                planetLogic.AddPlanet(p20);

                //5. star sys 2

                Star s5 = new Star() { StarID = Guid.NewGuid().ToString(), Name = "Pegasus", Age = 1000000000, StarType = StarType.Yellow_Dwarfs, SystemID = sys2.SystemID };
                starLogic.AddStar(s5);
                Planet p21 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Kepler-6543B2", Habitable = true, PlanetType = PlanetType.Terran, Population = 0, StarID = s5.StarID };
                planetLogic.AddPlanet(p21);
                Planet p22 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Branco", Habitable = false, PlanetType = PlanetType.Superterran, Population = 0, StarID = s5.StarID };
                planetLogic.AddPlanet(p22);
                Planet p23 = new Planet() { PlanetID = Guid.NewGuid().ToString(), Name = "Elizabeth", Habitable = false, PlanetType = PlanetType.Jovian, Population = 0, StarID = s5.StarID };
                planetLogic.AddPlanet(p23);

                filled = false;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
