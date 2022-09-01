using Escola.Domain.DTO;

namespace Escola.Domain.Interfaces.Services {
    
    public interface ITurmaService {

        List<TurmaDTO> ObterTodos();
        TurmaDTO ObterPorId(int id);
        void InserirTurma(TurmaDTO turmaDTO);
        void ExcluirTurma(int id);
    }
}