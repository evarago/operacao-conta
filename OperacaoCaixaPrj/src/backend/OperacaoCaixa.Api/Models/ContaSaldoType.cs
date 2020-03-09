 

using GraphQL.Types;
using OperacaoCaixa.Api.Helpers;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Api.Models
{
    public class ContaSaldoType : ObjectGraphType<ContaSaldo>
    {
        public ContaSaldoType(ContextServiceLocator contextServiceLocator)
        {
            //Name = "ContaSaldo";
            Field(x => x.SaldoAtual, true).Name("saldo");
        }
    }
}