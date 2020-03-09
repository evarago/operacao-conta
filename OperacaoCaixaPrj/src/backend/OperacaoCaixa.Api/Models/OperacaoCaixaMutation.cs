

using GraphQL;
using GraphQL.Types;
using Newtonsoft.Json.Linq;
using OperacaoCaixa.Api.Helpers;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OperacaoCaixa.Api.Models
{
    public class OperacaoCaixaMutation : ObjectGraphType
    {
        public OperacaoCaixaMutation(ContextServiceLocator contextServiceLocator)
        {
            Field<ContaOperacaoOutputType>(
                "depositar",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
                    new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "valor" }
                ),
                resolve: context =>
                {
                    var dtOperacao = DateTime.Now;

                    var conta = context.GetArgument<Int64>("conta");
                    var valorDec = context.GetArgument<decimal>("valor");

                    var contaCliente = contextServiceLocator.ContaClienteRepository.Get(conta).FirstOrDefault();

                    if (contaCliente == null || contaCliente.NumeroConta <= 0)
                        throw new ExecutionError("Conta inválida.");

                    if (valorDec <= 0)
                        throw new ExecutionError("Valor inválido.");

                    var valor = double.Parse(valorDec.ToString());

                    var contaOperacao = new ContaOperacao
                    {
                        Id = ContaOperacao.GetNewId(),
                        IdCliente = contaCliente.IdCliente,
                        IdConta = contaCliente.Id,
                        TipoOperacao = "C", //Crédito
                        Valor = valor,
                        DataOperacao = dtOperacao,
                        Modificado = DateTime.Now,
                        StatusRow = "I", //Insert
                        IdUserInsert = -1 //Sistema
                    };

                    contextServiceLocator.ContaOperacaoRepository.Add(contaOperacao);

                    var contaSaldo = contextServiceLocator.ContaSaldoRepository.Get(conta);

                    contaSaldo.SaldoAnterior = contaSaldo.SaldoAtual;
                    contaSaldo.SaldoAtual = Math.Round(contaSaldo.SaldoAtual + valor, 2);

                    contextServiceLocator.ContaSaldoRepository.Update(contaSaldo);

                    return new ContaOperacao { Valor = contaSaldo.SaldoAtual, Conta = new ContaCliente { NumeroConta = conta } };

                });

            Field<ContaOperacaoOutputType>(
               "sacar",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
                   new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "valor" }
               ),
               resolve: context =>
               {
                   var dtOperacao = DateTime.Now;

                   var conta = context.GetArgument<Int64>("conta");
                   var valorDec = context.GetArgument<decimal>("valor");

                   var contaCliente = contextServiceLocator.ContaClienteRepository.Get(conta).FirstOrDefault();

                   if (contaCliente == null || contaCliente.NumeroConta <= 0)
                       throw new ExecutionError("Conta inválida.");

                   if (valorDec <= 0)
                       throw new ExecutionError("Valor inválido.");

                   var valor = double.Parse(valorDec.ToString());

                   var contaOperacao = new ContaOperacao
                   {
                       Id = ContaOperacao.GetNewId(),
                       IdCliente = contaCliente.IdCliente,
                       IdConta = contaCliente.Id,
                       TipoOperacao = "D", //Débito
                        Valor = valor,
                       DataOperacao = dtOperacao,
                       Modificado = DateTime.Now,
                       StatusRow = "I", //Insert
                        IdUserInsert = -1 //Sistema
                    };

                   var contaSaldo = contextServiceLocator.ContaSaldoRepository.Get(conta);

                   if (contaSaldo.SaldoAtual < valor)
                       throw new ExecutionError("Saldo insuficiente.");

                   contextServiceLocator.ContaOperacaoRepository.Add(contaOperacao);

                   contaSaldo.SaldoAnterior = contaSaldo.SaldoAtual;
                   contaSaldo.SaldoAtual = Math.Round(contaSaldo.SaldoAtual - valor, 2);

                   contextServiceLocator.ContaSaldoRepository.Update(contaSaldo);

                   return new ContaOperacao { Valor = contaSaldo.SaldoAtual, Conta = new ContaCliente { NumeroConta = conta } };

               });
        }
    }
}