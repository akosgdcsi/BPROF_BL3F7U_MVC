using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Star")]
    public class StarController : ControllerBase
    {
        StarLogic starlogic;
        public StarController(StarLogic starlogic)
        {
            this.starlogic = starlogic;
        }

        [HttpGet("{id}")]
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


        [HttpPost]
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

        [HttpGet]
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

        [HttpDelete("{id}")]
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

        [HttpPut("{id}")]
        public IActionResult UpdateStar(string id,[FromBody] Star star)
        {
            try
            {

                starlogic.UpdateStar(id, star);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }
    }
}
