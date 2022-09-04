using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Database.Repository {

    public class AlunoRepository : IAlunoRepository
    {
        private readonly EscolaDbContexto _context ;

        public AlunoRepository(EscolaDbContexto context){
            _context = context;
        }
        public void ExcluirAluno(Guid id)
        {
            Aluno aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);
                _context.Alunos.Remove(aluno);
                _context.SaveChanges();
        }

        public void InserirAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public Aluno ObterPorId(Guid id)
        {
            Aluno aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);
            return aluno;
        }

        public IList<Aluno> ObterTodos()
        {
            return _context.Alunos.ToList();
        }

        public void AlterarAluno(Aluno aluno){
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }

        public bool ExisteMatricula(int matricula){
            return _context.Alunos.Any(x => x.Matricula == matricula);
        }

        public List<Boletim> GetBoletims(Guid id){
            return _context.Boletins.Where(b => b.AlunoId == id).ToList();
        }

        public List<NotasMaterias> GetNotas(Guid id, int idBoletim)
        {
            return _context.NotasMaterias
                           .Include(n => n.Boletim)
                           .Where(n => n.BoletimId == idBoletim && n.Boletim.AlunoId == id).ToList();
        }
    }
}