

namespace Escola.Domain.DTO {

    public class BaseDTO<TEntity> where TEntity : class {

        public TEntity Data {get; set;}
        public IList<HateoasDTO> Links { get; set; }
    }
}