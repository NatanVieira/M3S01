

namespace Escola.Domain.Exceptions {

    public class EntidadeNaoEncontradaException : Exception {
        
        public EntidadeNaoEncontradaException(string nome) : base (nome){

        }
    }
}