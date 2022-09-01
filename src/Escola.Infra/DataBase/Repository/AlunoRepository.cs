using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Models;

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
    }
}