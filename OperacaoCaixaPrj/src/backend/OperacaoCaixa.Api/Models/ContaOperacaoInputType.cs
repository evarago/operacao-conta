 
 
 using GraphQL.Types;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Api.Models
{
    public class ContaOperacaoInputType : InputObjectGraphType
    {
        public ContaOperacaoInputType()
        {
            Name = "ContaOperacaoInput";
            Field<IntGraphType>("conta");
            Field<DecimalGraphType>("valor");
        }
    }
}