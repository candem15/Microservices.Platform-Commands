using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Micro.CommandsService.Controllers
{
    [Route("api/cmd/[controller]")] //"cmd" refers to this is CommandsService's PlatformsController.
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {

        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST at Commands Service");

            return Ok("Inobund test of from Platforms Controller");
        }
    }
}