using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("System")]
    public class SystemController : ControllerBase
    {
        SystemLogic systemLogic;
        public SystemController(SystemLogic systemLogic)
        {
            this.systemLogic = systemLogic;
        }

        [HttpGet("{id}")]
        public ActionResult<Models.System> GetSystem(string id)
        {
            try
            {
                var system = systemLogic.GetSystem(id);
                return Ok(system);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex}");
            }
        }


        [HttpPost]
        public IActionResult AddSystem([FromBody] Models.System system)
        {
            try
            {
                systemLogic.AddSystem(system);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Models.System>> GetAllSystem()
        {
            try
            {
                var systems = systemLogic.GetAllSystem();
                return Ok(systems);
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

                systemLogic.DeleteSystem(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStar(string id,[FromBody] Models.System system)
        {
            try
            {

                systemLogic.UpdateSystem(id, system);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }
    }
}
