using ClienteCaixa.Data.InMemory;
using OperacaoCaixa.Core.Models;
using OperacaoCaixa.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace OperacaoCaixa.Tests.Unit.Data.InMemory
{
    public class ContaOperacaoRepositoryShould
    {
        private readonly ContaOperacaoRepository _contaOperacaoRepository;
        private readonly ContaSaldoRepository _contaSaldoRepository;

        public ContaOperacaoRepositoryShould()
        {
            // Given
            _contaOperacaoRepository = new ContaOperacaoRepository();
            _contaSaldoRepository = new ContaSaldoRepository();
        }

        [Fact]
        public async void Deposito10SomaSaldoConta9188827893()
        {
            var conta = 9188827893;
            var valorDeposito = 10;

            // When
            var contaSaldo = await _contaSaldoRepository.GetAsync(conta);

            Assert.NotNull(contaSaldo);

            var valorNovoSaldo = Math.Truncate(contaSaldo.SaldoAtual + valorDeposito);

            var objContaOperacao = new ContaOperacao
            {
                IdCliente = contaSaldo.IdCliente,
                IdConta = contaSaldo.IdConta,
                DataOperacao = DateTime.Now,
                TipoOperacao = "C",
                Valor = valorDeposito
            };

            var contaOperacao = await _contaOperacaoRepository.AddAsync(objContaOperacao);
            Assert.NotNull(contaOperacao);

            var objContaSaldo = contaSaldo;
            objContaSaldo.SaldoAnterior = objContaSaldo.SaldoAtual;
            objContaSaldo.SaldoAtual = valorNovoSaldo;

            _contaSaldoRepository.Update(objContaSaldo);

            var contaSaldoAtualizado = await _contaSaldoRepository.GetAsync(conta);
            Assert.NotNull(contaSaldoAtualizado);

            // Then
            Assert.Equal(valorNovoSaldo, contaSaldoAtualizado.SaldoAtual);
        }

        [Fact]
        public async void Saque10SubtraiSaldoConta9188827893()
        {
            var conta = 9188827893;
            var valorSaque = 95;

            // When
            var contaSaldo = await _contaSaldoRepository.GetAsync(conta);

            Assert.NotNull(contaSaldo);

            Assert.False(contaSaldo.SaldoAtual <= 0);
            Assert.False(contaSaldo.SaldoAtual - valorSaque < 0);

            var valorNovoSaldo = Math.Truncate(contaSaldo.SaldoAtual - valorSaque);

            var objContaOperacao = new ContaOperacao
            {
                IdCliente = contaSaldo.IdCliente,
                IdConta = contaSaldo.IdConta,
                DataOperacao = DateTime.Now,
                TipoOperacao = "D",
                Valor = valorSaque
            };

            var contaOperacao = await _contaOperacaoRepository.AddAsync(objContaOperacao);
            Assert.NotNull(contaOperacao);

            var objContaSaldo = contaSaldo;
            objContaSaldo.SaldoAnterior = objContaSaldo.SaldoAtual;
            objContaSaldo.SaldoAtual = valorNovoSaldo;

            _contaSaldoRepository.Update(objContaSaldo);

            var contaSaldoAtualizado = await _contaSaldoRepository.GetAsync(conta);
            Assert.NotNull(contaSaldoAtualizado);

            // Then
            Assert.Equal(valorNovoSaldo, contaSaldoAtualizado.SaldoAtual);
        }


    }
}