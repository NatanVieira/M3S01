using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Domain.DTO;

namespace Escola.Domain.Models {

    public class Aluno {

        public Guid Id { get; set;} = Guid.NewGuid();
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string  Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public Aluno(){}
        public Aluno(AlunoDTO aluno){
            Id = aluno.Id;
            Matricula = aluno.Matricula;
            Nome = aluno.Nome;
            Sobrenome = aluno.Sobrenome;
            Email = aluno.Email;
            DataNascimento = aluno.DataNascimento;
        }
    }
}