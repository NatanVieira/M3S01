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
        BoletimDTO boletimExcluir = this.ObterPorId(id);
        if(boletimExcluir == null)
            throw new EntidadeNaoEncontradaException("Boletim não encontrado.");
        _boletimRespository.Excluir(new Boletim(boletimExcluir));
    }

    public void InserirBoletim(BoletimDTO boletimDTO)
    {
        _boletimRespository.Inserir(new Boletim(boletimDTO));
    }

    public BoletimDTO ObterPorId(int id)
    {
        BoletimDTO boletim = new BoletimDTO(_boletimRespository.ObterPorId(id));
        if(boletim == null)
            throw new EntidadeNaoEncontradaException("Boletim não encontrado.");
        return boletim;
    }

    public void Atualizar(int id, BoletimDTO boletim){
        BoletimDTO boletimAtualizar = this.ObterPorId(id);
        if(boletimAtualizar == null)
            throw new EntidadeNaoEncontradaException("Boletim não encontrado.");
        _boletimRespository.Atualizar(new Boletim(boletim));
    }
}