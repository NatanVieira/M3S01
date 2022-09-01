

using Escola.Domain.DTO;

namespace Escola.Domain.Interfaces.Services {

    public interface INotasMateriasService {

        List<NotasMateriasDTO> ObterTodos();
        NotasMateriasDTO ObterPorId(int id);
        void InserirNotasMaterias(NotasMateriasDTO notasMateriasDTO);
        void ExcluirNotasMaterias(int id);
    }
}