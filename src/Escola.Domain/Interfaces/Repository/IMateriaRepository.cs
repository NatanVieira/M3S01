

using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repository {

    public interface IMateriaRepository {

        public IList<Materia> ObterTodos(Paginacao paginacao);
        public Materia ObterPorId(int id);
        public void Inserir(Materia materia);
        public void Excluir(Materia materia);

        public IList<Materia> ObterPorNome(string name);

        public void Atualizar(Materia materia);
        public int ObterTotal();
    }
}