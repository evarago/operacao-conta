using ClienteCaixa.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperacaoCaixa.Core.Models;
using OperacaoCaixa.Data;
using OperacaoCaixa.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace OperacaoCaixa.Tests.Unit.Data.Repository
{
    public class ContaSaldoRepositoryShould
    {
        private readonly ContaSaldoRepository _contaSaldoRepository;
        private readonly OperacaoCaixaContext _operacaoCaixaContext;

        private DbContextOptions<OperacaoCaixaContext> _options;

        public ContaSaldoRepositoryShould()
        {
            // Given
            _options = new DbContextOptionsBuilder<OperacaoCaixaContext>()
                .UseMySql("Server=s-east-1.rds.amazonaws.com;Database=operacao;Uid=n;Pwd=dvL7V;CharSet=utf8;")
                .Options;

            _operacaoCaixaContext = new OperacaoCaixaContext(_options);
            _contaSaldoRepository = new ContaSaldoRepository(_operacaoCaixaContext);
        }

        [Fact]
        public async void RetornaSaldoQuandoConta9188827893()
        {
            var conta = 9188827893;

            // When
            var contaSaldo = await _contaSaldoRepository.GetAsync(conta);

            // Then
            Assert.NotNull(contaSaldo);
        }

        [Fact]
        public async void SaldoPositivoConta9188827893()
        {
            var conta = 9188827893;

            // When
            var contaSaldo = await _contaSaldoRepository.GetAsync(conta);

            Assert.NotNull(contaSaldo);

            Assert.False(contaSaldo.SaldoAtual < 0);
        }

    }
}