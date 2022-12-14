
using Escola.Domain.DTO;
using Escola.Domain.Exceptions;
using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;

namespace Escola.Domain.Services {

    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _materiaRepository;

        public MateriaService(IMateriaRepository materiaRepository){
            _materiaRepository = materiaRepository;
        }

        public void ExcluirMateria(int id)
        {
            MateriaDTO materiaExcluir = this.ObterPorId(id);
            if(materiaExcluir == null)
                throw new EntidadeNaoEncontradaException("Matéria não encontrada.");
            _materiaRepository.Excluir(new Materia(materiaExcluir));
        }

        public void InserirMateria(MateriaDTO materiaDTO)
        {
            if(this.ObterPorNome(materiaDTO.Nome) != null)
                throw new EntidadeJaCadastradaException("Matéria já cadastrada.");
            _materiaRepository.Inserir(new Materia(materiaDTO));
        }

        public MateriaDTO ObterPorId(int id)
        {
            MateriaDTO materia = new MateriaDTO(_materiaRepository.ObterPorId(id));
            if(materia == null)
                throw new EntidadeNaoEncontradaException("Matéria não encontrada.");
            return materia;
        }

        public List<MateriaDTO> ObterTodos(Paginacao paginacao)
        {
            List<MateriaDTO> materias = _materiaRepository.ObterTodos(paginacao).Select(m => new MateriaDTO(m)).ToList();
            if(!materias.Any())
                throw new EntidadeNaoEncontradaException("Nenhuma matéria encontrada.");
            return materias;
        }

        public List<MateriaDTO> ObterPorNome(string name){
            List<MateriaDTO> materias = _materiaRepository.ObterPorNome(name).Select(m => new MateriaDTO(m)).ToList();
            if(!materias.Any())
                throw new EntidadeNaoEncontradaException("Nenhuma matéria encontrada.");
            return  materias;
        }

        public void Atualizar(int id, MateriaDTO materia){
            MateriaDTO materiaAtualizar = this.ObterPorId(id);
            if(materiaAtualizar == null)
                throw new EntidadeNaoEncontradaException("Matéria não encontrada.");
            _materiaRepository.Atualizar(new Materia(materiaAtualizar));
        }

        public int ObterTotal(){
            return _materiaRepository.ObterTotal();
        }
    }
}