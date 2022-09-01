

using Escola.Domain.Models;

namespace Escola.Domain.DTO {

    public class TurmaDTO {
        public int Id { get; set; }
        public string Curso { get; set; } 
        public TurmaDTO(){}
        public TurmaDTO(Turma turma){
            Id = turma.Id;
            Curso = turma.Curso;
        }
    }
}