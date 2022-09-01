
using Escola.Domain.DTO;

namespace Escola.Domain.Models {

    public class Materia {

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual List<NotasMaterias> NotasMaterias {get; set;}

        public Materia() {}

        public Materia(MateriaDTO materiaDTO){
            
            Id = materiaDTO.Id;
            Nome = materiaDTO.Nome;
        }
    }
}