

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
            Materia materia = this.ObterPorId(id);
            _context.Remove(materia);
            _context.SaveChanges();
        }

        public void InserirMateria(Materia materia)
        {
            _context.Materias.Add(materia);
            _context.SaveChanges();
        }

        public Materia ObterPorId(int id)
        {
            return _context.Materias.FirstOrDefault(x => x.Id == id);
        }

        public List<Materia> ObterPorNome(string name)
        {
            return _context.Materias.Where(x => x.Nome.ToUpper() == name.ToUpper()).ToList();
        }

        public List<Materia> ObterTodos(Paginacao paginacao)
        {
            return _context.Materias
                           .Skip(paginacao.Skip)
                           .Take(paginacao.Take)
                           .ToList();
        }

        public void Atualizar(int id, Materia materia){
            Materia materiaAlterada = this.ObterPorId(id);
            _context.Update(materiaAlterada);
        }

        public int ObterTotal(){
            return _context.Materias.Count();
        }
    }
}