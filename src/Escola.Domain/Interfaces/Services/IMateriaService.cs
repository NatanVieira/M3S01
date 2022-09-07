
using Escola.Domain.Models;
using Escola.Domain.DTO;

namespace Escola.Domain.Interfaces.Services {

    public interface IMateriaService {

        List<MateriaDTO> ObterTodos(Paginacao paginacao);
        MateriaDTO ObterPorId(int id);
        void InserirMateria(MateriaDTO materiaDTO);
        void ExcluirMateria(int id);

        List<MateriaDTO> ObterPorNome(string name);

        void Atualizar(int id, MateriaDTO materia);
        public int ObterTotal();
    }
}