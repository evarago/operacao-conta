
using GraphQL;
using GraphQL.Types;
using OperacaoCaixa.Api.Helpers;
using OperacaoCaixa.Core.Data;
using System;

namespace OperacaoCaixa.Api.Models
{
    public class OperacaoCaixaQuery : ObjectGraphType
    {
        public OperacaoCaixaQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<DecimalGraphType>(
                "saldo",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "conta" }),
                resolve: context =>
                {
                    var contaSaldo = contextServiceLocator.ContaSaldoRepository.Get(context.GetArgument<Int64>("conta"));

                    if (contaSaldo == null || contaSaldo.Conta.NumeroConta <= 0)
                        throw new ExecutionError("Conta inválida.");

                    return contaSaldo.SaldoAtual;
                }
                );
        }
    }
}