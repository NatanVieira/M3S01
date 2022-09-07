

using Escola.Domain.DTO;
using Escola.Domain.Models;
using Escola.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers {

    [ApiController]
    [Route("api/v2/[controller]")]
    public class MateriasV2Controller : ControllerBase {
        
        private readonly MateriaService _materiaService;
        
        public MateriasV2Controller (MateriaService materiaService){
            _materiaService = materiaService;
        }
        [HttpGet]
        public IActionResult Get(int skip, int take){
            try{
                var paginacao = new Paginacao(skip, take);
                var totalRegistros = _materiaService.ObterTotal();

                Response.Headers.Add("X-Paginacao-TotalRegistros",totalRegistros.ToString());
                return Ok(_materiaService.ObterTodos(paginacao));
            }
            catch{
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
        public IActionResult Post([FromBody] MateriaV2DTO materia){
            _materiaService.InserirMateria(new MateriaDTO(materia));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id){
            _materiaService.ExcluirMateria(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,
                                 [FromBody] MateriaV2DTO materia){
            _materiaService.Atualizar(id, new MateriaDTO(materia));
            return NoContent();
        }
    }
}