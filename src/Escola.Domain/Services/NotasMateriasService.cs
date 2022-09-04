

using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Interfaces.Services;

namespace Escola.Domain.Services {

    public class NotasMateriasService : INotasMateriasService
    {
        private readonly INotasMateriasRepository _notasRepository;

        public NotasMateriasService(INotasMateriasRepository notasRepository){
            _notasRepository = notasRepository;
        }
        public void ExcluirNotasMaterias(int id)
        {
            throw new NotImplementedException();
        }

        public void InserirNotasMaterias(NotasMateriasDTO notasMateriasDTO)
        {
            throw new NotImplementedException();
        }

        public NotasMateriasDTO ObterPorId(int id)
        {
            if(_notasRepository.ObterPorId(id) != null){
                return new NotasMateriasDTO(_notasRepository.ObterPorId(id));
            }
            else
                throw new Exception("Nota Inexistente");
        }

        public List<NotasMateriasDTO> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}