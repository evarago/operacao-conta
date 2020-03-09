# API GraphQL ASPNetCore 

Principais abordagens

 GraphQL - Linguagem de consulta criada pelo Facebook em 2012, alternativa para arquiteturas REST
 
 GraphQL queries
 
 GraphQL mutations
 
 3-Camadas (Api, Core, Data) architecture
 
 DDD (Domain Driven Design) hexagonal architecture
 
 Dependency Inversion (padrão ASP.NET Core IoC container)
 
 In Memory Repository
 
 Entity Framework Repository
 
 EF Migrations
 
 TDD (Unit Tests)
 
 Visual Studio 2017
 
 Integration Tests
 
 Logs
 
 Docker


## Ambiente de Desenvolvimento

- .NET Core 2.2 SDK
- Visual Studio Code v1.42.1 (Ou VS2017)
- MySql 5.6 (Nesse cenário foi o Aurora RDS)
 
## Setup do projeto

O projeto está configurado para uso do ambiente "Development" com o Entityframework em memória para executar testes pelo VS code ou VS2012.
Simplesmente inicie o depurador a partir do IDE ou execute-o diretamente usando o comando CLI dotnet run a partir da raiz da pasta \OperacaoCaixa.Api.
Para uso do MySql será necessário direcionar para uma instância criada previamente, os scripts disponíveis na pasta "OperacaoCaixa.Data\Migrations\scripts\" do projeto podem ser executados para criar as tabelas e inserir os dados iniciais.

Ainda não está disponível o "migration"  para criar o banco de dados e inserir os dados iniciais na primeira execução do aplicativo.

A API está configurada para executar na porta 5000, se isso entrar em conflito com algum outro serviço no seu computador, você poderá alterá-la no arquivo de xxx.

Para executar no docker, ajustar o arquivo Dockerfile conforme a necessidade.

## Contato

everton.varago@gmail.com