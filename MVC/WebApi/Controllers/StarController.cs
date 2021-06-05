using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("Star")]
    [ApiController]
    public class StarController : ControllerBase
    {
        StarLogic starlogic;
        public StarController(StarLogic starlogic)
        {
            this.starlogic = starlogic;
        }

        [HttpGet("/GetStar/{id}")]
        public ActionResult<Star> GetStar(string id)
        {
            try
            {
                var star = starlogic.GetStar(id);
                return Ok(star);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex}");
            }
        }


        [HttpPost("/AddStar")]
        public IActionResult AddStar([FromBody] Star star)
        {
            try
            {
                starlogic.AddStar(star);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpGet("/GetAllStars")]
        public ActionResult<IEnumerable<Planet>> GetAllStar()
        {
            try
            {
                var star = starlogic.GetAllStar();
                return Ok(star);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpDelete("/DeleteStar/{id}")]
        public IActionResult DeleteStar(string id)
        {
            try
            {

                starlogic.DeleteStar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpPost("/UpdateStar")]
        public IActionResult UpdateStar([FromBody] Star star)
        {
            try
            {

                starlogic.UpdateStar(star.StarID, star);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }
    }
}
