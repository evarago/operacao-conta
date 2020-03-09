
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Core.Models;

namespace ClienteCaixa.Data.InMemory
{
    public class ContaClienteRepository : IContaClienteRepository
    {
        private readonly List<ContaCliente> _ContaCliente = new List<ContaCliente> {
            new ContaCliente() {
                    Id="za60f4f6d123446dbcb109b78b3bc860",
                    IdCliente="ca60f4f6d123446dbcb109b78b3bc861",
                    CodigoAgencia="0899",
                    NumeroConta=9188827893,
                    TipoConta="CC",
                    Cliente = new Pessoa {
                        Id = "ca60f4f6d123446dbcb109b78b3bc861",
                        Identidade = "33322211100",
                        Nome = "Everton"
                    }
                }
        };

        public List<ContaCliente> Get(Int64 numeroConta)
        {
            return _ContaCliente.Where(p => p.NumeroConta == numeroConta).ToList();
        }
        public Task<List<ContaCliente>> GetAsync(Int64 numeroConta)
        {
            return Task.FromResult(_ContaCliente.Where(p => p.NumeroConta == numeroConta).ToList());
        }

        public Task<List<ContaCliente>> All()
        {
            throw new System.NotImplementedException();
        }

        public ContaCliente Add(ContaCliente contaCliente)
        {
            return contaCliente;
        }
        public Task<ContaCliente> AddAsync(ContaCliente contaCliente)
        {
            return Task.FromResult(contaCliente);
        }
    }
}