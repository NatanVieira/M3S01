
namespace Escola.Domain.Models {

    public class Materia {

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual List<NotasMaterias> NotasMaterias {get; set;}
    }
}