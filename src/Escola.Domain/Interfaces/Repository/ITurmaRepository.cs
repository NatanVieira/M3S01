

using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repository {

    public interface ITurmaRepository {

        public List<Turma> ObterTodos();
        public Turma ObterPorId(int id);
        public void InserirTurma(Turma turma);
        public void ExcluirTurma(int id);
    }
}