

using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repository {

    public interface INotasMateriasRepository {

        public NotasMaterias ObterPorId(int id);
        public void Inserir(NotasMaterias notasMaterias);
        public void Excluir(NotasMaterias notasMaterias);
        public void Atualizar(NotasMaterias notas);
    }
}