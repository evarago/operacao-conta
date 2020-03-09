
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Core.Models;
using OperacaoCaixa.Data;

namespace ClienteCaixa.Data.Repositories
{
    public class ContaClienteRepository : IContaClienteRepository
    {
        private readonly OperacaoCaixaContext _db;

        public ContaClienteRepository(OperacaoCaixaContext db)
        {
            _db = db;
        }

        public List<ContaCliente> Get(Int64 numeroConta)
        {
            try
            {
                return _db.ContaCliente.Include(ss => ss.Cliente).Where(ss => ss.NumeroConta == numeroConta).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<List<ContaCliente>> GetAsync(Int64 numeroConta)
        {
            try
            {
                return await _db.ContaCliente.Include(ss => ss.Cliente).Where(ss => ss.NumeroConta == numeroConta).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<List<ContaCliente>> All()
        {
            try
            {
                return await _db.ContaCliente.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public ContaCliente Add(ContaCliente contaCliente)
        {
            try
            {
                _db.ContaCliente.Add(contaCliente);
                _db.SaveChanges();
                return contaCliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<ContaCliente> AddAsync(ContaCliente contaCliente)
        {
            try
            {
                await _db.ContaCliente.AddAsync(contaCliente);
                await _db.SaveChangesAsync();
                return contaCliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}