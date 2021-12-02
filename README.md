# Demo TDC Future 2021 - Arquitetura .NET

[![.NET Core 6](https://github.com/juniorporfirio/TDCFuture21-NET6-MinimalApis/actions/workflows/net6.yml/badge.svg?branch=main)](https://github.com/juniorporfirio/TDCFuture21-NET6-MinimalApis/actions/workflows/net6.yml)

Demo utilizada na live realizada no TDC Future 2021 no dia 02/12, abordando o MinimalApis do .NET6, algumas possibilidades de organização do projeto, validações e testes unitários e integrados.

- Link dos slides:
    - https://github.com/juniorporfirio/TDCFuture21-NET6-MinimalApis/raw/main/Apresentacao.pdf

# Pré-requisitos

- .NET CORE 6 LTS - , Download a partir do link https://dotnet.microsoft.com/download/dotnet/6.0
- Visual Studio 2022 / Visual Studio Code

# Pacotes utilizados

## Aplicações
- FluentValidation.AspNetCore
    - https://github.com/FluentValidation/FluentValidation
- MinimalApis.Extensions
    - https://github.com/DamianEdwards/MinimalApis.Extensions
- MinimalApis.Validator 
    - https://github.com/juniorporfirio/MinimalApis.Validators
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
    - https://github.com/DamianEdwards/MinimalApis.Extensions

# Demos
- TDCFutureTalks -  Exemplo contexto palestras utilizando MinimalApis e Swagger.
- TDCFutureTalks.Strutured  - Exemplo estruturado utilizando ExtensionsMethods.
- TDCFutureTalks.Strutured2 - Exemplo estruturado utilizando classes e DI.
- TDCFutureTalks.Reflection - Exemplo estruturado com uso de Reflection e AssemblyScan.
- TDCFutureTalks.Mediator - Exemplo estruturado com uso do MediatR.









