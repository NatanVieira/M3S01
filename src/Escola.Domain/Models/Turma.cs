
using Escola.Domain.DTO;

namespace Escola.Domain.Models {

    public class Turma {

        public int Id { get; set; }
        public string Curso { get; set; }

        public virtual List<Aluno> Alunos {get; set;}

        public Turma(){}
        public Turma(TurmaDTO turmaDTO){
            Id = turmaDTO.Id;
            Curso = turmaDTO.Curso;
        }
    }
}