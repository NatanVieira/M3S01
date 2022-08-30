using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase {
        
        [HttpGet]
        public IActionResult Health () {
            return Ok("Health");
        }
    }
}