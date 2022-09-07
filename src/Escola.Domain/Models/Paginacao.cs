
namespace Escola.Domain.Models {

    public class Paginacao {

        public int Skip { get; set; }
        public int Take { get; set; }

        public Paginacao(int skip, int take){
            Skip = skip;
            Take = take;
        }
    }
}