
using Escola.Domain.Models;

namespace Escola.Domain.DTO {

    public class MateriaDTO : BaseHateoasDTO{

        public int Id { get; set; }
        public string Nome { get; set; }

        public string Notas { get {return $"http://localhost:5216/api/materias/{Id}/notas";} private set{} }
        public MateriaDTO() {}

        public MateriaDTO(Materia materia){
            Nome = materia.Nome;
        }  

        public MateriaDTO(MateriaV2DTO materia){
            Nome = materia.Disciplina;
        }
    }
}