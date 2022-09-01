

using Escola.Domain.Models;

namespace Escola.Domain.DTO {

    public class BoletimDTO {
        public int Id { get; set; }
        public Guid AlunoId { get; set; }
        public DateTime OrderDate { get; set; }
        public BoletimDTO(){}

        public BoletimDTO(Boletim boletim){
            Id = boletim.Id;
            AlunoId = boletim.AlunoId;
            OrderDate = boletim.OrderDate;
        }
    }
}