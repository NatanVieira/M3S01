using Escola.Domain.Models;
using System.Collections.Generic;
using System;
namespace Escola.Domain.Interfaces.Repository {

    public interface IAlunoRepository {

        IList<Aluno> ObterTodos();

        void InserirAluno(Aluno aluno);

        void ExcluirAluno(Guid id);

        Aluno ObterPorId(Guid id);

        void AlterarAluno(Aluno aluno);

    }
}