
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Data.InMemory
{
    public class ContaSaldoRepository : IContaSaldoRepository
    {
        private readonly List<ContaSaldo> _ContaSaldo = new List<ContaSaldo> {
            new ContaSaldo() {
                IdConta = "za60f4f6d123446dbcb109b78b3bc860",
                IdCliente = "ca60f4f6d123446dbcb109b78b3bc861",
                DataAtualizacao = DateTime.Now,
                SaldoAnterior = 10,
                SaldoAtual = 95,
                Conta = new ContaCliente {
                    Id="za60f4f6d123446dbcb109b78b3bc860",
                    IdCliente="ca60f4f6d123446dbcb109b78b3bc861",
                    CodigoAgencia="0899",
                    NumeroConta=9188827893,
                    TipoConta="CC"
                }
            }
        };
        public ContaSaldo Get(Int64 numeroConta)
        {
            return _ContaSaldo.FirstOrDefault(p => p.Conta.NumeroConta == numeroConta);
        }
        public Task<ContaSaldo> GetAsync(Int64 numeroConta)
        {
            return Task.FromResult(_ContaSaldo.FirstOrDefault(p => p.Conta.NumeroConta == numeroConta));
        }
        public Task<List<ContaSaldo>> All()
        {
            throw new System.NotImplementedException();
        }
        public ContaSaldo Update(ContaSaldo contaSaldo)
        {
            _ContaSaldo.Add(contaSaldo);
            return contaSaldo;
        }
    }
}