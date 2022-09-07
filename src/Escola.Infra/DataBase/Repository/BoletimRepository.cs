

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
            Boletim boletim = this.ObterPorId(id);
            _context.Remove(boletim);
            _context.SaveChanges();
        }

        public void InserirBoletim(Boletim boletim)
        {
            _context.Add(boletim);
            _context.SaveChanges();
        }

        public Boletim ObterPorId(int id)
        {
            return _context.Boletins.FirstOrDefault(b => b.Id == id);
        }

        public void Atualizar(int id, Boletim boletim){
            _context.Boletins.Update(boletim);
            _context.SaveChanges();
        }
    }
}