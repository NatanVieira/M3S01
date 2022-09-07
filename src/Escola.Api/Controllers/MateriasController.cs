

using Escola.Domain.DTO;
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
            return Ok(_materiaService.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            return Ok(_materiaService.ObterPorId(id));
        }

        [HttpGet]
        public IActionResult GetByName([FromQuery] string name){
            return Ok(_materiaService.ObterPorNome(name));
        }

        [HttpPost]
        public IActionResult Post([FromBody] MateriaDTO materia){
            _materiaService.InserirMateria(materia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id){
            _materiaService.ExcluirMateria(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,
                                 [FromBody] MateriaDTO materia){
            _materiaService.Atualizar(id, materia);
            return NoContent();
        }
    }
}