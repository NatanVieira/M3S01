
using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repository {

    public interface IBoletimRepository {

        public Boletim ObterPorId(int id);
        public void Inserir(Boletim boletim);
        public void Excluir(Boletim boletim);

        public void Atualizar(Boletim boletim);
    }
}