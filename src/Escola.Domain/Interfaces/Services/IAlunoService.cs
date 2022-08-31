
using Escola.Domain.DTO;

namespace Escola.Domain.Interfaces.Services {

    public interface IAlunoService {

        IList<AlunoDTO> ObterTodos();

        void InserirAluno(AlunoDTO aluno);

        void ExcluirAluno(AlunoDTO aluno);

        AlunoDTO ObterPorId(Guid id);
    }
}