
using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Escola.Api.Config {

    public class CacheService<TEntity> {

        private readonly IMemoryCache _cache;
        private string _baseKey;
        private TimeSpan _expiracao;
        
        public CacheService(IMemoryCache cache){
            _cache = cache;
        }

        public void Config(string baseKey, TimeSpan expiracao){
            _baseKey = baseKey;
            _expiracao = expiracao;
        }

        public TEntity Set(string parametro, TEntity entity){
            return _cache.Set<TEntity>(MontarChave(parametro), entity, _expiracao);
        }

        public bool TryGetValue(string parametro, out TEntity entity){
            return _cache.TryGetValue<TEntity>(MontarChave(parametro), out entity);
        }

        public void Remove(string parametro){
            _cache.Remove(MontarChave(parametro));
        }

        private string MontarChave(string parametro){
            return $"{_baseKey}:{parametro}";
        }
    }
}
