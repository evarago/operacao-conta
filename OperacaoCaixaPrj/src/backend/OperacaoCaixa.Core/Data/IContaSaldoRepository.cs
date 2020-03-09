
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Core.Data
{
    public interface IContaSaldoRepository
    {
        ContaSaldo Get(Int64 numeroConta);
        Task<ContaSaldo> GetAsync(Int64 numeroConta);
        ContaSaldo Update(ContaSaldo contaSaldo);
        Task<List<ContaSaldo>> All();
    }
}