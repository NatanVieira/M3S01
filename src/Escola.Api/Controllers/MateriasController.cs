

using Escola.Api.Config;
using Escola.Domain.DTO;
using Escola.Domain.Models;
using Escola.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Escola.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase {
        
        private readonly MateriaService _materiaService;
        private readonly CacheService<MateriaDTO>  _cache;
        public MateriasController (MateriaService materiaService, CacheService<MateriaDTO> cache){
            _materiaService = materiaService;
            _cache = cache;
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
            //return Ok(_materiaService.ObterPorId(id));
            MateriaDTO materia;
            if(!_cache.TryGetValue($"{id}",out materia)){
                materia = _materiaService.ObterPorId(id);
                _cache.Set(id.ToString(),materia);
            }
            return Ok(materia);
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
            _cache.Remove($"{id}");
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,
                                 [FromBody] MateriaDTO materia){
            _materiaService.Atualizar(id, materia);
            _cache.Set($"{id}",materia);
            return NoContent();
        }
    }
}