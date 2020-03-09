
using System.Threading.Tasks;
using System.Collections.Generic;
using OperacaoCaixa.Core.Models;
using System;

namespace OperacaoCaixa.Core.Data
{
    public interface IContaClienteRepository
    {
        Task<List<ContaCliente>> GetAsync(Int64 numeroConta);
        List<ContaCliente> Get(Int64 numeroConta);
        Task<List<ContaCliente>> All();
        ContaCliente Add(ContaCliente contaCliente);
        Task<ContaCliente> AddAsync(ContaCliente contaCliente);
    }
}