 
using GraphQL;
using GraphQL.Types;

namespace OperacaoCaixa.Api.Models
{
    public class OperacaoCaixaSchema : Schema
    {
        public OperacaoCaixaSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<OperacaoCaixaQuery>();
            Mutation = resolver.Resolve<OperacaoCaixaMutation>();
        }
    }
}