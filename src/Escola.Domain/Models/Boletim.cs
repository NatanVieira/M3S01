
namespace Escola.Domain.Models {

    public class Boletim {

        public int Id { get; set; }
        public Guid AlunoId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Aluno Aluno {get; set;}
        public virtual List<NotasMaterias> NotasMaterias {get; set;}
    }
}