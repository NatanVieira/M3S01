

using Escola.Domain.DTO;

namespace Escola.Domain.Interfaces.Services {

    public interface IMateriaService {

        List<MateriaDTO> ObterTodos();
        MateriaDTO ObterPorId(int id);
        void InserirMateria(MateriaDTO materiaDTO);
        void ExcluirMateria(int id);

        List<MateriaDTO> ObterPorNome(string name);

        void Atualizar(int id, MateriaDTO materia);
    }
}