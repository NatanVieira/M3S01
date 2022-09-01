
using Escola.Domain.DTO;
namespace Escola.Domain.Interfaces.Services {

    public interface IBoletimService {

        List<BoletimDTO> ObterTodos();
        BoletimDTO ObterPorId(int id);
        void InserirBoletim(BoletimDTO boletimDTO);
        void ExcluirBoletim(int id);
    }
}