

using Escola.Domain.DTO;

namespace Escola.Domain.Interfaces.Services {

    public interface INotasMateriasService {
        NotasMateriasDTO ObterPorId(int id);
        void InserirNotasMaterias(NotasMateriasDTO notasMateriasDTO);
        void ExcluirNotasMaterias(int id);
        void Atualizar(int id, NotasMateriasDTO notas);
    }
}