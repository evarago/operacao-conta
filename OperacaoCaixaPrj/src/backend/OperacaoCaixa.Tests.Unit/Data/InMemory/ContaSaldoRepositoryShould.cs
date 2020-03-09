using OperacaoCaixa.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OperacaoCaixa.Tests.Unit.Data.InMemory
{
    public class ContaSaldoRepositoryShould
    {
        private readonly ContaSaldoRepository _contaSaldoRepository;
        public ContaSaldoRepositoryShould()
        {
            // Given
            _contaSaldoRepository = new ContaSaldoRepository();
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