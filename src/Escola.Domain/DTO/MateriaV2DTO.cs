
using Escola.Domain.Models;

namespace Escola.Domain.DTO {

    public class MateriaV2DTO {
        public string Disciplina { get; set; }
        public MateriaV2DTO() {}

        public MateriaV2DTO(Materia materia){
            Disciplina = materia.Nome;
        }  
    }
}