using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Domain.Models;

namespace Escola.Domain.DTO {
    public class AlunoDTO {

        public Guid Id { get; set; } = Guid.NewGuid();
        public int Matricula{ get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public AlunoDTO(){}
        public AlunoDTO(Aluno aluno){
            Id = aluno.Id;
            Matricula = aluno.Matricula;
            Nome = aluno.Nome;
            Sobrenome = aluno.Sobrenome;
            Email = aluno.Email;
            DataNascimento = aluno.DataNascimento;
        }
    }
}