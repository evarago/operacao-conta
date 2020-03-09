
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Data.Repositories
{
    public class ContaSaldoRepository : IContaSaldoRepository
    {
        private readonly OperacaoCaixaContext _db;

        public ContaSaldoRepository(OperacaoCaixaContext db)
        {
            _db = db;
        }

        public ContaSaldo Get(Int64 numeroConta)
        {
            try
            {
                return _db.ContaSaldo.Include(c => c.Conta).FirstOrDefault(p => p.Conta.NumeroConta == numeroConta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<ContaSaldo> GetAsync(Int64 numeroConta)
        {
            try
            {
                return await _db.ContaSaldo.Include(c => c.Conta).FirstOrDefaultAsync(p => p.Conta.NumeroConta == numeroConta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public ContaSaldo Update(ContaSaldo contaSaldo)
        {
            try
            {
                _db.ContaSaldo.Update(contaSaldo);
                _db.SaveChanges();

                return contaSaldo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<ContaSaldo>> All()
        {
            try
            {
                return await _db.ContaSaldo.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}