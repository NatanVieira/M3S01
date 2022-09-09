

using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Models;

namespace Escola.Infra.Database.Repository {

    public class BoletimRepository : BaseRepository<Boletim,int>, IBoletimRepository
    {
        public BoletimRepository(EscolaDbContexto context) : base(context){}
    }
}