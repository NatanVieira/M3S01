

using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Models;

namespace Escola.Infra.Database.Repository {

    public class MateriaRepository : BaseRepository<Materia,int>, IMateriaRepository
    {
        public MateriaRepository(EscolaDbContexto context) : base( context){}

        public int ObterTotal(){
            return _context.Materias.Count();
        }

        public IList<Materia> ObterPorNome(string nome){
            return _context.Materias.Where(m => m.Nome == nome).ToList();
        }

    }
}