

using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Models;

namespace Escola.Infra.Database.Repository {

    public class NotasMateriasRepository : INotasMateriasRepository
    {
        private readonly EscolaDbContexto _context;

        public NotasMateriasRepository(EscolaDbContexto context){
            _context = context;
        }
        public void ExcluirNotasMaterias(int id)
        {
            throw new NotImplementedException();
        }

        public void InserirNotasMaterias(NotasMaterias notasMaterias)
        {
            throw new NotImplementedException();
        }

        public NotasMaterias ObterPorId(int id)
        {
            return _context.NotasMaterias.FirstOrDefault(x => x.Id == id);
        }

        public List<NotasMaterias> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}