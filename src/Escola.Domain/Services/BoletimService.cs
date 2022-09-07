using Escola.Domain.DTO;
using Escola.Domain.Exceptions;
using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;

namespace Escola.Domain.Services ;

public class BoletimService : IBoletimService
{   
    private readonly IBoletimRepository _boletimRespository;

    public BoletimService (IBoletimRepository boletim){
        _boletimRespository = boletim;
    }

    public void ExcluirBoletim(int id)
    {
        if(this.ObterPorId(id) == null)
            throw new EntidadeNaoEncontradaException("Boletim não encontrado.");
        _boletimRespository.ExcluirBoletim(id);
    }

    public void InserirBoletim(BoletimDTO boletimDTO)
    {
        _boletimRespository.InserirBoletim(new Boletim(boletimDTO));
    }

    public BoletimDTO ObterPorId(int id)
    {
        BoletimDTO boletim = new BoletimDTO(_boletimRespository.ObterPorId(id));
        if(boletim == null)
            throw new EntidadeNaoEncontradaException("Boletim não encontrado.");
        return boletim;
    }

    public void Atualizar(int id, BoletimDTO boletim){
        if(this.ObterPorId(id) == null)
            throw new EntidadeNaoEncontradaException("Boletim não encontrado.");
        _boletimRespository.Atualizar(id, new Boletim(boletim));
    }
}