

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
            NotasMaterias notas = this.ObterPorId(id);
            _context.NotasMaterias.Remove(notas);
            _context.SaveChanges();
        }

        public void InserirNotasMaterias(NotasMaterias notasMaterias)
        {
            _context.NotasMaterias.Add(notasMaterias);
        }

        public NotasMaterias ObterPorId(int id)
        {
            return _context.NotasMaterias.FirstOrDefault(x => x.Id == id);
        }
        public void Atualizar(int id, NotasMaterias notas){
            _context.NotasMaterias.Update(notas);
        }
    }
}