

using Escola.Domain.DTO;
using Escola.Domain.Exceptions;
using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;

namespace Escola.Domain.Services {

    public class NotasMateriasService : INotasMateriasService
    {
        private readonly INotasMateriasRepository _notasRepository;

        public NotasMateriasService(INotasMateriasRepository notasRepository){
            _notasRepository = notasRepository;
        }
        public void ExcluirNotasMaterias(int id)
        {
            NotasMateriasDTO notasExcluir = this.ObterPorId(id);
            if(notasExcluir == null)
                throw new EntidadeNaoEncontradaException("Nota não encontrada.");
            _notasRepository.Excluir(new NotasMaterias(notasExcluir));
        }

        public void InserirNotasMaterias(NotasMateriasDTO notasMateriasDTO)
        {
            _notasRepository.Inserir(new NotasMaterias(notasMateriasDTO));
        }

        public NotasMateriasDTO ObterPorId(int id)
        {
            if(_notasRepository.ObterPorId(id) == null)
                throw new EntidadeNaoEncontradaException("Nota não encontrada.");
            return new NotasMateriasDTO(_notasRepository.ObterPorId(id));
        }

        public void Atualizar(int id, NotasMateriasDTO notas){
            NotasMateriasDTO notasAtualizar = this.ObterPorId(id);
            if(notasAtualizar == null)
                throw new EntidadeNaoEncontradaException("Nota não encontrada.");
            _notasRepository.Atualizar(new NotasMaterias(notas));
        }
        
    }
}