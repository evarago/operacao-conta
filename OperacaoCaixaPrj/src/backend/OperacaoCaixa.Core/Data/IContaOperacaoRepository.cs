
using System.Threading.Tasks;
using System.Collections.Generic;
using OperacaoCaixa.Core.Models;
using System;

namespace OperacaoCaixa.Core.Data
{
    public interface IContaOperacaoRepository
    {
        List<ContaOperacao> Get(Int64 numeroConta);
        Task<List<ContaOperacao>> GetAsync(Int64 numeroConta);
        Task<List<ContaOperacao>> All();
        ContaOperacao Add(ContaOperacao contaOperacao);
        Task<ContaOperacao> AddAsync(ContaOperacao contaOperacao);
    }
}