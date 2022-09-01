
using Escola.Domain.DTO;

namespace Escola.Domain.Interfaces.Services {

    public interface IAlunoService {

        IList<AlunoDTO> ObterTodos();

        void InserirAluno(AlunoDTO aluno);

        void ExcluirAluno(Guid id);

        AlunoDTO ObterPorId(Guid id);

        void AlterarAluno(AlunoDTO alunoDTO);
    }
}