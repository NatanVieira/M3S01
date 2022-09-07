

using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repository {

    public interface INotasMateriasRepository {

        public NotasMaterias ObterPorId(int id);
        public void InserirNotasMaterias(NotasMaterias notasMaterias);
        public void ExcluirNotasMaterias(int id);
        public void Atualizar(int id, NotasMaterias notas);
    }
}