
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly OperacaoCaixaContext _db;

        public PessoaRepository(OperacaoCaixaContext db)
        {
            _db = db;
        }

        public Pessoa Get(string identidade)
        {
            try
            {
                return _db.Pessoa.FirstOrDefault(p => p.Identidade == identidade);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }
        public async Task<Pessoa> GetAsync(string identidade)
        {
            try
            {
                return await _db.Pessoa.FirstOrDefaultAsync(p => p.Identidade == identidade);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<List<Pessoa>> All()
        {
            try
            {
                return await _db.Pessoa.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}