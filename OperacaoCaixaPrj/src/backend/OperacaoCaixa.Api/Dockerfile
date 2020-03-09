FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["OperacaoCaixa.Api/OperacaoCaixa.Api.csproj", "OperacaoCaixa.Api/"]
COPY ["OperacaoCaixa.Data/OperacaoCaixa.Data.csproj", "OperacaoCaixa.Data/"]
COPY ["OperacaoCaixa.Core/OperacaoCaixa.Core.csproj", "OperacaoCaixa.Core/"]
RUN dotnet restore "OperacaoCaixa.Api/OperacaoCaixa.Api.csproj"
COPY . .
WORKDIR "/src/OperacaoCaixa.Api"
RUN dotnet build "OperacaoCaixa.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OperacaoCaixa.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OperacaoCaixa.Api.dll"]