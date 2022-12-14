
using Escola.Domain.DTO;
namespace Escola.Domain.Interfaces.Services {

    public interface IBoletimService {

        BoletimDTO ObterPorId(int id);
        void InserirBoletim(BoletimDTO boletimDTO);
        void ExcluirBoletim(int id);
        void Atualizar(int id, BoletimDTO boletim);
    }
}