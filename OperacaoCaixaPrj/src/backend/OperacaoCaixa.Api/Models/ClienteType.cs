
using GraphQL.Types;
using OperacaoCaixa.Api.Helpers;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Api.Models
{
    public class ClienteType : ObjectGraphType<Pessoa>
    {
        public ClienteType(ContextServiceLocator contextServiceLocator)
        {
            Name = "Cliente";
            Field(x => x.Id, false);
            Field(x => x.Nome, false);
            Field(x => x.Identidade, false);
        }
    }
}