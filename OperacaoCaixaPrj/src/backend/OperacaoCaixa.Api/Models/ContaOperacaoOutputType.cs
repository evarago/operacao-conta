 
 
 using GraphQL.Types;
using OperacaoCaixa.Api.Helpers;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Api.Models
{
    public class ContaOperacaoOutputType : ObjectGraphType<ContaOperacao>
    {
        public ContaOperacaoOutputType(ContextServiceLocator contextServiceLocator)
        {
            //Name = "ContaOperacao";
            Field(x => x.Cliente.Nome, true).Name("cliente");
            Field(x => x.Conta.NumeroConta, true).Name("conta");
            Field(x => x.Valor, true).Name("saldo");
            
        }
    }
}