using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Interfaces.Services;

namespace Escola.Domain.Services ;

public class BoletimService : IBoletimService
{   
    private readonly IBoletimRepository _boletimRespository;

    public BoletimService (IBoletimRepository boletim){
        _boletimRespository = boletim;
    }

    public void ExcluirBoletim(int id)
    {
        throw new NotImplementedException();
    }

    public void InserirBoletim(BoletimDTO boletimDTO)
    {
        throw new NotImplementedException();
    }

    public BoletimDTO ObterPorId(int id)
    {
        BoletimDTO boletim = new BoletimDTO(_boletimRespository.ObterPorId(id));
        if(boletim != null)
            return boletim;
        else
            throw new Exception("Id de boletim não encontrado.");
    }

    public List<BoletimDTO> ObterTodos()
    {
        throw new NotImplementedException();
    }
}