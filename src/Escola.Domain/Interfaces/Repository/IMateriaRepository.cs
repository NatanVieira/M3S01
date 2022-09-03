

using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repository {

    public interface IMateriaRepository {

        public List<Materia> ObterTodos();
        public Materia ObterPorId(int id);
        public void InserirMateria(Materia materia);
        public void ExcluirMateria(int id);

        public List<Materia> ObterPorNome(string name);

        public void Atualizar(int id, Materia materia);
    }
}