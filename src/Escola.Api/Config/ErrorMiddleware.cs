

using System.Net;
using Escola.Domain.DTO;
using Escola.Domain.Exceptions;

namespace Escola.Api.Config {

    public class ErrorMiddleware {

        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next){
            _next = next;
        }

        public async Task InvokeAsync (HttpContext context){
            try{
                await _next(context);
            }
            catch (Exception ex){
                await TratamentoExcecao(context, ex);
            }
        }

        private Task TratamentoExcecao(HttpContext context, Exception ex){

            HttpStatusCode status;
            string message;
            
            switch(ex){
                case DuplicadoException:
                    status = HttpStatusCode.NotAcceptable;
                    message = ex.Message;                    
                    break;
                case IdadeException:
                    status = HttpStatusCode.NotAcceptable;
                    message = ex.Message;
                    break;
                case EntidadeJaCadastradaException:
                    status = HttpStatusCode.NotAcceptable;
                    message = ex.Message;
                    break;
                case EntidadeNaoEncontradaException:
                    status = HttpStatusCode.NotAcceptable;
                    message = ex.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Ocorreu um erro favor contactar a TI."; 
                    break;                   
            }

            var response = new ErrorDTO(message);

            context.Response.StatusCode = (int) status;
            return context.Response.WriteAsJsonAsync(response);
            
        }
    }
}