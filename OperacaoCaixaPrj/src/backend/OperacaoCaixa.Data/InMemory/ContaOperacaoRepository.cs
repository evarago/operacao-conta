
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Data.InMemory
{
    public class ContaOperacaoRepository : IContaOperacaoRepository
    {
        private readonly List<ContaOperacao> _ContaOperacao = new List<ContaOperacao> {
            new ContaOperacao() {
                IdConta = "za60f4f6d123446dbcb109b78b3bc860",
                IdCliente = "ca60f4f6d123446dbcb109b78b3bc861",
                Valor = 5,
                DataOperacao = DateTime.Now,
                Conta = new ContaCliente {
                    Id="za60f4f6d123446dbcb109b78b3bc860",
                    IdCliente="ca60f4f6d123446dbcb109b78b3bc861",
                    CodigoAgencia="0899",
                    NumeroConta=9188827893,
                    TipoConta="CC"
                }
            }
        };

        public List<ContaOperacao> Get(Int64 numeroConta)
        {
            return _ContaOperacao.Where(p => p.Conta.NumeroConta == numeroConta).ToList();
        }
        public Task<List<ContaOperacao>> GetAsync(Int64 numeroConta)
        {
            return Task.FromResult(_ContaOperacao.Where(p => p.Conta.NumeroConta == numeroConta).ToList());
        }
        public Task<List<ContaOperacao>> All()
        {
            throw new System.NotImplementedException();
        }

        public ContaOperacao Add(ContaOperacao contaOperacao)
        {
            _ContaOperacao[0].Valor = _ContaOperacao[0].Valor + contaOperacao.Valor;
            return _ContaOperacao[0];
        }
        public Task<ContaOperacao> AddAsync(ContaOperacao contaOperacao)
        {
            _ContaOperacao[0].Valor = _ContaOperacao[0].Valor + contaOperacao.Valor;
            return Task.FromResult(_ContaOperacao[0]);
        }
    }
}