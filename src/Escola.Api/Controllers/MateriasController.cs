

using Escola.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase {
        
        private readonly MateriaService _materiaService;
        
        public MateriasController (MateriaService materiaService){
            _materiaService = materiaService;
        }
        [HttpGet]
        public IActionResult Get(){
            try {
                return Ok(_materiaService.ObterTodos().ToList());
            }
            catch{ return StatusCode(500);}
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            try{
                return Ok(_materiaService.ObterPorId(id));
            }
            catch{ return StatusCode(500);}
        }
        [HttpGet]
        public IActionResult GetByName([FromQuery] string name){
            try{
                return Ok(_materiaService.ObterPorNome(name));
            }
            catch{ return StatusCode(500);}
        }
    }
}