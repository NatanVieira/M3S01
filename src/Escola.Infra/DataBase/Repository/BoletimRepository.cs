

using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Models;

namespace Escola.Infra.Database.Repository {

    public class BoletimRepository : IBoletimRepository
    {
        private readonly EscolaDbContexto _context;

        public BoletimRepository(EscolaDbContexto context){
            _context = context;
        }

        public void ExcluirBoletim(int id)
        {
            throw new NotImplementedException();
        }

        public void InserirBoletim(Boletim boletim)
        {
            _context.Add(boletim);
        }

        public Boletim ObterPorId(int id)
        {
            return _context.Boletins.FirstOrDefault(b => b.Id == id);
        }

        public List<Boletim> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}