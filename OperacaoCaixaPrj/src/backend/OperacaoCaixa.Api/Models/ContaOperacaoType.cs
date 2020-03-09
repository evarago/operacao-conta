 
 
 using GraphQL.Types;
using OperacaoCaixa.Api.Helpers;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Api.Models
{
    public class ContaOperacaoType : ObjectGraphType<ContaOperacao>
    {
        public ContaOperacaoType(ContextServiceLocator contextServiceLocator)
        {
            Name = "ContaOperacao";
            Field(x => x.Cliente.Nome).Name("cliente");
            Field(x => x.Conta.NumeroConta).Name("conta");
            Field(x => x.TipoOperacao);
            Field(x => x.Valor);
            Field(x => x.DataOperacao);
        }
    }
}