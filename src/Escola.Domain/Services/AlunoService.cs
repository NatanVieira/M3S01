using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;

namespace Escola.Domain.Services {

    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoService (IAlunoRepository alunoRepository){
            _alunoRepository = alunoRepository;
        }
        public void ExcluirAluno(AlunoDTO aluno)
        {
            throw new NotImplementedException();
        }

        public void InserirAluno(AlunoDTO aluno)
        {
            //TODO: Validar se ja consta matricula

            _alunoRepository.InserirAluno(new Aluno(aluno));
        }

        public AlunoDTO ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<AlunoDTO> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}