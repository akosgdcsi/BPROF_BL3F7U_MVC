using Logic;
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

        [HttpGet("/GetPlanet/{id}")]
        public ActionResult<Planet> GetPlanet(string id)
        {
            try
            {
                var planet = planetLogic.GetPlanet(id);
                return Ok(planet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex}");
            }
        }


        [HttpPost("/AddPlanet")]
        public IActionResult AddPlanet([FromBody] Planet planet)
        {
            try
            {
                planetLogic.AddPlanet(planet);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpGet("/GetAllPlanets")]
        public ActionResult<IEnumerable<Planet>> GetAllPlanet()
        {
            try
            {
                var planets = planetLogic.GetAllPlanet();
                return Ok(planets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpDelete("/DeletePlanet/{id}")]
        public IActionResult DeletePlanet(string id)
        {
            try
            {

                planetLogic.DeletePlanet(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }
        
        [HttpPost("/UpdatePlanet")]
        public IActionResult UpdatePlanet([FromBody] Planet planet)
        {
            try
            {
                
                planetLogic.UpdatePlanet(planet.PlanetID,planet);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

    }
}
