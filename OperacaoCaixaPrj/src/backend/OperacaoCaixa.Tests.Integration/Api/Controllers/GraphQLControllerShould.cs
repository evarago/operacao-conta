using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using OperacaoCaixa.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace OperacaoCaixa.Tests.Integration.Api.Controllers
{
    public class GraphQLControllerShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public GraphQLControllerShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
            );

            _client = _server.CreateClient();
        }

        [Fact]
        public async void RetonaSaldoMaiorOuIgualA0()
        {
            // Given
            var query = @"{
                ""query"": ""query { saldo(conta: 9188827893) { saldo } }""
            }";

            var content = new StringContent(query, Encoding.UTF8, "application/json");

            // When
            var response = await _client.PostAsync("/graphql", content);

            // Then
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            double valor = -1;
            Assert.True(double.TryParse(responseString, out valor));
            Assert.True(valor >= 0);
        }
    }
}