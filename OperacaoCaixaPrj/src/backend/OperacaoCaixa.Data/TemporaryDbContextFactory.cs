 
 
 
using Microsoft.EntityFrameworkCore;
 

namespace OperacaoCaixa.Data
{
    public class TemporaryDbContextFactory : DesignTimeDbContextFactoryBase<OperacaoCaixaContext>
    {
        protected override OperacaoCaixaContext CreateNewInstance(
            DbContextOptions<OperacaoCaixaContext> options)
        {
            return new OperacaoCaixaContext(options);
        }
    }
}
