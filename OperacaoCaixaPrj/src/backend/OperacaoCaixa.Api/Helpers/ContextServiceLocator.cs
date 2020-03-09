using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OperacaoCaixa.Core.Data;


namespace OperacaoCaixa.Api.Helpers
{
    // https://github.com/graphql-dotnet/graphql-dotnet/issues/648#issuecomment-431489339
    public class ContextServiceLocator
    {
        public IContaClienteRepository ContaClienteRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IContaClienteRepository>();
        public IContaSaldoRepository ContaSaldoRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IContaSaldoRepository>();
        public IContaOperacaoRepository ContaOperacaoRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IContaOperacaoRepository>();

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}