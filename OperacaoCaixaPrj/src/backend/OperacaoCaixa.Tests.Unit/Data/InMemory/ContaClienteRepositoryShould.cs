using ClienteCaixa.Data.InMemory;
using OperacaoCaixa.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace OperacaoCaixa.Tests.Unit.Data.InMemory
{
    public class ContaClienteRepositoryShould
    {
        private readonly ContaClienteRepository _contaClienteRepository;
        public ContaClienteRepositoryShould()
        {
            // Given
            _contaClienteRepository = new ContaClienteRepository();
        }

        [Fact]
        public async void RetornaClienteEvertonQuandoConta9188827893()
        {
            // When
            var contaCliente = await _contaClienteRepository.GetAsync(9188827893);

            // Then
            Assert.NotNull(contaCliente.FirstOrDefault());
            Assert.Equal("Everton", contaCliente.FirstOrDefault().Cliente.Nome);
        }
    }
}