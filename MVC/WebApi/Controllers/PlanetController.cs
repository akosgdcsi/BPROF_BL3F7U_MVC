﻿using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Planet")]
    public class PlanetController : ControllerBase
    {
        PlanetLogic planetLogic;
        public PlanetController(PlanetLogic planetLogic)
        {
            this.planetLogic = planetLogic;
        }

        [HttpPost("/AddPlanet")]
        public IActionResult AddPlanet([FromBody] Planet planet)
        {
            try
            {
                planet.PlanetID = Guid.NewGuid().ToString();
                planetLogic.AddPlanet(planet);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }
    }
}
