

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
                var uri = $"{Request.Scheme}://{Request.Host}";
                var materias = new BaseDTO<IList<MateriaDTO>>(){
                    Data = _materiaService.ObterTodos(paginacao),
                    Links = this.GetHateoasForAll(uri, take, skip, totalRegistros)
                };

                foreach(var materia in materias.Data){
                    materia.Links = GetHateoas(materia, uri);
                }
                return Ok(materias);
            }
            catch{
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            //return Ok(_materiaService.ObterPorId(id));
            MateriaDTO materia;
            var uri = $"{Request.Scheme}://{Request.Host}";

            if(!_cache.TryGetValue($"{id}",out materia)){
                materia = _materiaService.ObterPorId(id);
                _cache.Set(id.ToString(),materia);
                materia.Links = GetHateoas(materia, uri);
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

        private List<HateoasDTO> GetHateoas(MateriaDTO materia, string baseUri){
            var hateoas =  new List<HateoasDTO>() {
                new HateoasDTO(){
                    Rel = "self",
                    Type = "GET", 
                    Uri = $"{baseUri}/api/materias/{materia.Id}" 
                }, 
                new HateoasDTO(){
                    Rel = "materia",
                    Type = "PUT", 
                    Uri = $"{baseUri}/api/materias/{materia.Id}" 
                },
                new HateoasDTO(){
                    Rel = "materia",
                    Type = "DELETE", 
                    Uri = $"{baseUri}/api/materias/{materia.Id}" 
                },
                new HateoasDTO(){
                    Rel = "materia",
                    Type = "POST", 
                    Uri = $"{baseUri}/api/materias/" 
                },
                new HateoasDTO(){
                    Rel = "materia",
                    Type = "GET", 
                    Uri = $"{baseUri}/api/materias?name={materia.Nome}" 
                }
            };

            return hateoas;
        }

        private List<HateoasDTO> GetHateoasForAll(string baseUri, int take, int skip, int ultimo){
            var hateoas = new List<HateoasDTO>(){
                new HateoasDTO(){
                    Rel = "self",
                    Type = "GET",
                    Uri = $"{baseUri}/api/materias?skip={skip}&take={take}"
                },
                new HateoasDTO(){
                    Rel = "materia",
                    Type = "POST",
                    Uri = $"{baseUri}/api/materias"
                }
            };
            
            var razao = take - skip;
            if(skip != 0){
                var newSkip = skip - razao;
                if(newSkip < 0)
                    newSkip = 0;

                hateoas.Add(new HateoasDTO(){
                    Rel = "Prev",
                    Type = "GET",
                    Uri = $"{baseUri}/api/materias?skip={newSkip}&take={take - razao}"
                });
            }

            if (take < ultimo){
                hateoas.Add(new HateoasDTO(){
                    Rel = "Next",
                    Type = "GET",
                    Uri = $"{baseUri}/api/materias?skip={skip+razao}&take={take+razao}"
                });
            }

            return hateoas;
        }
    }
}