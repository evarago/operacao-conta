 
using System;
using System.Collections.Generic;
using System.Linq;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Data
{
    public static class OperacaoCaixaSeedData
    {

        public static void EnsureSeedData(this OperacaoCaixaContext db)
        {
            if (!db.Pessoa.Any())
            {
                var Pessoa = new List<Pessoa>
                {
                   new Pessoa { Id = "aa60f4f6d123446dbcb109b78b3bc862", Identidade = "33322211101", Nome = "Anna" },
                   new Pessoa { Id = "ca60f4f6d123446dbcb109b78b3bc861", Identidade = "33322211100", Nome = "Everton" }
                };  

                db.Pessoa.AddRange(Pessoa);
                db.SaveChanges();
            }

            if (!db.ContaCliente.Any())
            {
                var contaCliente = new List<ContaCliente>
                {
                   new ContaCliente {
                       Id = "za60f4f6d123446dbcb109b78b3bc860",
                       IdCliente = "ca60f4f6d123446dbcb109b78b3bc861",
                       CodigoAgencia = "0899",
                       NumeroConta = 9188827893,
                       TipoConta = "CC" }
                };

                db.ContaCliente.AddRange(contaCliente);
                db.SaveChanges();
            }

            if (!db.ContaOperacao.Any())
            {
                var contaOperacao = new List<ContaOperacao>
                {
                   new ContaOperacao {
                       Id = "bb60f4f6d123446dbcb109b78b3bc890",
                       IdCliente = "ca60f4f6d123446dbcb109b78b3bc861",
                       IdConta = "za60f4f6d123446dbcb109b78b3bc860",
                       TipoOperacao = "C",
                       Valor = 86.00,
                       DataOperacao = DateTime.Now
                   }
                };

                db.ContaOperacao.AddRange(contaOperacao);
                db.SaveChanges();
            }

            if (!db.ContaSaldo.Any())
            {
                var contaSaldo = new List<ContaSaldo>
                {
                   new ContaSaldo {
                       IdCliente = "ca60f4f6d123446dbcb109b78b3bc861",
                       IdConta = "za60f4f6d123446dbcb109b78b3bc860",
                       SaldoAnterior = 11.00,
                       SaldoAtual = 97.00,
                       DataAtualizacao = DateTime.Now
                   }
                };

                db.ContaSaldo.AddRange(contaSaldo);
                db.SaveChanges();
            }
        }
    }
}
