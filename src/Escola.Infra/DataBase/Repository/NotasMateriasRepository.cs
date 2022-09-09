

using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Models;

namespace Escola.Infra.Database.Repository {

    public class NotasMateriasRepository : BaseRepository<NotasMaterias,int>, INotasMateriasRepository
    {
        public NotasMateriasRepository(EscolaDbContexto context) : base(context){}
    }
}