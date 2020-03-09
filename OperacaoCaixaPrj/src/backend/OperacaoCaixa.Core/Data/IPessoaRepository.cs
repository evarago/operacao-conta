
using System.Collections.Generic;
using System.Threading.Tasks;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Core.Data
{
    public interface IPessoaRepository
    {
        Pessoa Get(string identidade);
        Task<Pessoa> GetAsync(string identidade);
        Task<List<Pessoa>> All();
    }
}