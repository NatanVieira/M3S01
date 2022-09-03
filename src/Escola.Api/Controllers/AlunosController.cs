using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;

namespace Escola.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase {
        
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService){
            _alunoService = alunoService;
        }
        [HttpPost("inserir")]
        public IActionResult Inserir ([FromBody] AlunoDTO aluno){
            _alunoService.InserirAluno(aluno);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public IActionResult Get(){
            IList<AlunoDTO> alunos;
            try {
                alunos = _alunoService.ObterTodos();
            }
            catch{
                return StatusCode(500);
            }
            return Ok(alunos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id){
            AlunoDTO aluno;
            try {
                aluno = _alunoService.ObterPorId(id);
            }
            catch{ return StatusCode(500);}
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id){
            try {
                _alunoService.ExcluirAluno(id);
            }
            catch { return StatusCode(500);}
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id,
                                 [FromBody] AlunoDTO aluno){
            aluno.Id = id;
            try{
            _alunoService.AlterarAluno(aluno); 
            }
            catch{
                return StatusCode(500);
            }                       
            return NoContent();
        }
    }
}