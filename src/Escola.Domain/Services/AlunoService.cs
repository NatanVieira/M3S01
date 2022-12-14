using Escola.Domain.DTO;
using Escola.Domain.Exceptions;
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
            if(_alunoRepository.ExisteMatricula(aluno.Matricula))
                throw new DuplicadoException("Matrícula já existente");
            if(new Aluno(aluno).DevolveIdade() < 18)
                throw new IdadeException("Idade precisa ser maior ou igual a 18 anos.");
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

        public List<BoletimDTO> GetBoletims(Guid id){
            List<BoletimDTO> boletins = _alunoRepository.GetBoletims(id).Select(x => new BoletimDTO(x)).ToList();
            if (!boletins.Any())
                throw new EntidadeNaoEncontradaException("Boletins não encontrados.");
            return boletins;
        }

        public List<NotasMateriasDTO> GetNotas(Guid id, int idBoletim)
        {
            List<NotasMateriasDTO> notas = _alunoRepository.GetNotas(id, idBoletim).Select(x => new NotasMateriasDTO(x)).ToList();
            if(notas.Count != 0)
                return notas;
            else
                throw new Exception("Não existem notas para o aluno/boletim.");
        }
    }
}