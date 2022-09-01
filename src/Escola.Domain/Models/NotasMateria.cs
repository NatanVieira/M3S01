
using Escola.Domain.DTO;

namespace Escola.Domain.Models{

    public class NotasMaterias {

        public int Id { get; set; }
        public int BoletimId { get; set; }
        public int MateriaId { get; set; }

        public int Nota { get; set; }

        public virtual Materia Materia {get; set;}
        public virtual Boletim Boletim {get; set;}

        public NotasMaterias(){}
        public NotasMaterias(NotasMateriasDTO notasMateriasDTO){
            Id = notasMateriasDTO.Id;
            BoletimId = notasMateriasDTO.BoletimId;
            MateriaId = notasMateriasDTO.MateriaId;
        }
    }
}