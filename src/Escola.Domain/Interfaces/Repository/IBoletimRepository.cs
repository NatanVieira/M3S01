
using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repository {

    public interface IBoletimRepository {

        public List<Boletim> ObterTodos();
        public Boletim ObterPorId(int id);
        public void InserirBoletim(Boletim boletim);
        public void ExcluirBoletim(int id);

        public void Atualizar(int id, Boletim boletim);
    }
}