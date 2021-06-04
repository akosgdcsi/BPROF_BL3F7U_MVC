using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("System")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        SystemLogic systemLogic;
        public SystemController(SystemLogic systemLogic)
        {
            this.systemLogic = systemLogic;
        }

        [HttpGet("/GetSystem/{id}")]
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


        [HttpPost("/AddSystem")]
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

        [HttpGet("/GetAllSystems")]
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

        [HttpDelete("/DeleteSystem")]
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

        [HttpPost("/UpdateSystem")]
        public IActionResult UpdateStar([FromBody] Models.System system)
        {
            try
            {

                systemLogic.UpdateSystem(system.SystemID, system);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }
    }
}
