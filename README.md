# Demo TDC Future 2021 - Arquitetura .NET

Demo utilizada na live realizada no TDC Future 2021 no dia 02/12, abordando o MinimalApis do .NET6, algumas possibilidades de organização do projeto, validações e testes unitários e integrados.

# Pré-requisitos

- .NET CORE 6 LTS - , Download a partir do link https://dotnet.microsoft.com/download/dotnet/6.0
- Visual Studio 2022 / Visual Studio Code

# Pacotes utilizados

## Aplicações
- FluentValidation.AspNetCore
- MinimalApis.Extensions
- MinimalApis.Validator
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore


## Testes
- Xunit
- FluentAssertions
- NSubstitute
- Microsoft.AspNetCore.Mvc.Testing
- Microsoft.EntityFrameworkCore.InMemory
- MiminalApis.Extensions

# Demos
- TDCFutureTalks -  Exemplo de palestrantes utilizando MinimalApis e Swagger.
- TDCFutureTalks.Strutured  - Exemplo estruturado utilizando Extensions Methods.
- TDCFutureTalks.Strutured2 - Exemplo estruturado utilizando classes e DI.
- TDCFutureTalks.Reflection - Exemplo estruturado com uso de Reflection e AssemblyScan









