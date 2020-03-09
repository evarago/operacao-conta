using ClienteCaixa.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using OperacaoCaixa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace OperacaoCaixa.Tests.Unit.Data.Repository
{
    public class ContaClienteRepositoryShould
    {
        private readonly ContaClienteRepository _contaClienteRepository;
        private readonly OperacaoCaixaContext _operacaoCaixaContext;

        private DbContextOptions<OperacaoCaixaContext> _options;

        public ContaClienteRepositoryShould()
        {
            // Given
            _options = new DbContextOptionsBuilder<OperacaoCaixaContext>()
                .UseMySql("Server=digital-documento.cluster-c58ihsrye390.us-east-1.rds.amazonaws.com;Database=operacao;Uid=usradmin;Pwd=yo49r8HJ4qT8WsmdvL7V;CharSet=utf8;")
                .Options;

            _operacaoCaixaContext = new OperacaoCaixaContext(_options);
            _contaClienteRepository = new ContaClienteRepository(_operacaoCaixaContext);
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