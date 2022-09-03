

namespace Escola.Domain.Exceptions {

    public class DuplicadoException : Exception {

        public DuplicadoException(string nome) : base(nome){
            
        }
    }
}