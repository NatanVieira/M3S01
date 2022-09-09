
using Escola.Domain.Models;

namespace Escola.Infra.Database.Repository {

    public class BaseRepository<TEntity, Tkey> where TEntity : class {

        protected readonly EscolaDbContexto _context;

        public BaseRepository(EscolaDbContexto context){
            _context = context;
        }

        public virtual void Inserir(TEntity entity){
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Atualizar(TEntity entity){
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual TEntity ObterPorId(Tkey id){
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IList<TEntity> ObterTodos(Paginacao paginacao){
            return _context.Set<TEntity>()
                           .Take(paginacao.Take)
                           .Skip(paginacao.Skip)
                           .ToList();
        }

        public virtual void Excluir(TEntity entity){
            _context.Set<TEntity>().Remove(entity);
        }
    }

}