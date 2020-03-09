
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Data.Repositories
{
    public class ContaOperacaoRepository : IContaOperacaoRepository
    {
        private readonly OperacaoCaixaContext _db;

        public ContaOperacaoRepository(OperacaoCaixaContext db)
        {
            _db = db;
        }

        public List<ContaOperacao> Get(Int64 numeroConta)
        {
            try
            {
                return _db.ContaOperacao.Include(ss => ss.Cliente).Include(ss => ss.Conta).Where(ss => ss.Conta.NumeroConta == numeroConta).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<List<ContaOperacao>> GetAsync(Int64 numeroConta)
        {
            try
            {
                return await _db.ContaOperacao.Include(ss => ss.Cliente).Include(ss => ss.Conta).Where(ss => ss.Conta.NumeroConta == numeroConta).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<List<ContaOperacao>> All()
        {
            try
            {
                return await _db.ContaOperacao.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public ContaOperacao Add(ContaOperacao contaOperacao)
        {
            try
            {
                _db.ContaOperacao.Add(contaOperacao);
                _db.SaveChanges();
                return contaOperacao;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<ContaOperacao> AddAsync(ContaOperacao contaOperacao)
        {
            try
            {
                await _db.ContaOperacao.AddAsync(contaOperacao);
                await _db.SaveChangesAsync();
                return contaOperacao;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}