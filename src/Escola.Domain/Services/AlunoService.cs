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
        public void ExcluirAluno(Guid id)
        {
            _alunoRepository.ExcluirAluno(id);
        }

        public void InserirAluno(AlunoDTO aluno)
        {
            //TODO: Validar se ja consta matricula
            _alunoRepository.InserirAluno(new Aluno(aluno));
        }

        public AlunoDTO ObterPorId(Guid id)
        {
            return new AlunoDTO(_alunoRepository.ObterPorId(id));
        }

        public IList<AlunoDTO> ObterTodos()
        {
            // List<AlunoDTO> alunos = new List<AlunoDTO>;
            // _alunoRepository.ObterTodos().ToList().ForEach(x => {
            //     alunos.Add(new AlunoDTO(x));
            // });
            return _alunoRepository.ObterTodos().Select(x => new AlunoDTO(x)).ToList();
        }

        public void AlterarAluno(AlunoDTO aluno){
            var alunoDb = _alunoRepository.ObterPorId(aluno.Id);
            alunoDb.Update(new Aluno(aluno));
            _alunoRepository.AlterarAluno(alunoDb);
        }
    }
}