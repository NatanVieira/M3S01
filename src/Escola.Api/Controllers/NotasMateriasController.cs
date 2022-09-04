

using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers {


    [ApiController]
    [Route("api/notas")]
    public class NotasMateriasController : ControllerBase {

        private readonly INotasMateriasService _notasService;
        
        [HttpGet("{id}")]
        public ActionResult<NotasMateriasDTO> Get([FromRoute] int id){
            try{
                return Ok(_notasService.ObterPorId(id));
            }catch{ return StatusCode(500);}

        }
    }
}