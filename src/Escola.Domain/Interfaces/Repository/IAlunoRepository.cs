using Escola.Domain.Models;
using System.Collections.Generic;
using System;
namespace Escola.Domain.Interfaces.Repository {

    public interface IAlunoRepository {

        IList<Aluno> ObterTodos();

        void InserirAluno(Aluno aluno);

        void ExcluirAluno(Aluno aluno);

        Aluno ObterPorId(Guid id);

    }
}