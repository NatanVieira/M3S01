

using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Models;

namespace Escola.Infra.Database.Repository {

    public class MateriaRepository : IMateriaRepository
    {
        private readonly EscolaDbContexto _context;

        public MateriaRepository(EscolaDbContexto context) {
            _context = context;
        }
        public void ExcluirMateria(int id)
        {
            throw new NotImplementedException();
        }

        public void InserirMateria(Materia materia)
        {
            throw new NotImplementedException();
        }

        public Materia ObterPorId(int id)
        {
            return _context.Materias.FirstOrDefault(x => x.Id == id);
        }

        public List<Materia> ObterPorNome(string name)
        {
            return _context.Materias.Where(x => x.Nome.ToUpper() == name.ToUpper()).ToList();
        }

        public List<Materia> ObterTodos()
        {
            return _context.Materias.ToList();
        }
    }
}