

using Escola.Domain.Models;

namespace Escola.Domain.DTO {

    public class NotasMateriasDTO {
        public int Id { get; set; }
        public int BoletimId { get; set; }
        public int MateriaId { get; set; }

        public int Nota { get; set; }   
        public NotasMateriasDTO(){}
        public NotasMateriasDTO(NotasMaterias notasMaterias){
            Id = notasMaterias.Id;
            BoletimId = notasMaterias.BoletimId;
            MateriaId = notasMaterias.MateriaId;
        }
    }
}