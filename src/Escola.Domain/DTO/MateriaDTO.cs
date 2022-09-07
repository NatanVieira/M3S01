
using Escola.Domain.Models;

namespace Escola.Domain.DTO {

    public class MateriaDTO {
        public string Nome { get; set; }
        public MateriaDTO() {}

        public MateriaDTO(Materia materia){
            Nome = materia.Nome;
        }  

        public MateriaDTO(MateriaV2DTO materia){
            Nome = materia.Disciplina;
        }
    }
}