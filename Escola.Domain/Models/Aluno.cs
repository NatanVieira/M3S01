using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Domain.Models {

    public class Aluno {

        public Guid Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string  Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}