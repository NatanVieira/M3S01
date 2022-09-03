
using Escola.Domain.DTO;
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
            if(this.ObterPorId(id) == null){
                _materiaRepository.ExcluirMateria(id);
            }
            else
                throw new Exception("Id de materia não encontrado.");
        }

        public void InserirMateria(MateriaDTO materiaDTO)
        {
            if (this.ObterPorNome(materiaDTO.Nome) == null)
                _materiaRepository.InserirMateria(new Materia(materiaDTO));
            else
                throw new Exception("Materia já cadastrada");
        }

        public MateriaDTO ObterPorId(int id)
        {
            return new MateriaDTO(_materiaRepository.ObterPorId(id));
        }

        public List<MateriaDTO> ObterTodos()
        {
            return _materiaRepository.ObterTodos().Select(x => new MateriaDTO(x)).ToList();
        }

        public List<MateriaDTO> ObterPorNome(string name){
            return _materiaRepository.ObterPorNome(name).Select(x => new MateriaDTO(x)).ToList();
        }
    }
}