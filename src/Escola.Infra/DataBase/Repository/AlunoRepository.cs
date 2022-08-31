using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Models;

namespace Escola.Infra.Database.Repository {

    public class AlunoRepository : IAlunoRepository
    {
        private readonly EscolaDbContexto _context ;

        public AlunoRepository(EscolaDbContexto context){
            _context = context;
        }
        public void ExcluirAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public void InserirAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public Aluno ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}