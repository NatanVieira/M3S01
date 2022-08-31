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
            try{
                _alunoService.InserirAluno(aluno);
            }
            catch{
                return StatusCode(500);
            }
            return Ok();
        }
    }
}