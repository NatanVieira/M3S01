

namespace Escola.Domain.Exceptions {

    public class EntidadeJaCadastradaException : Exception {

        public EntidadeJaCadastradaException (string nome ) : base(nome){
            
        }
    }
}