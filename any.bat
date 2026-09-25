dotnet new sln -o ShortLi
cd ShortLi

dotnet new web -o src/ShortLi.Api
dotnet new classlib -o src/ShortLi.Application
dotnet new classlib -o src\ShortLi.Contracts
dotnet new classlib -o src/ShortLi.Domain
dotnet new classlib -o src/ShortLi.Infrastructure

dotnet sln add src/ShortLi.Api/ShortLi.Api.csproj
dotnet sln add src/ShortLi.Application/ShortLi.Application.csproj
dotnet sln add src/ShortLi.Contracts/ShortLi.Contracts.csproj
dotnet sln add src/ShortLi.Domain/ShortLi.Domain.csproj
dotnet sln add src/ShortLi.Infrastructure/ShortLi.Infrastructure.csproj

dotnet new xunit -o tests/ShortLi.UnitTests
dotnet new xunit -o tests/ShortLi.IntegrationTests
dotnet new xunit -o tests/ShortLi.ArchitectureTests

dotnet sln add tests/ShortLi.UnitTests
dotnet sln add tests/ShortLi.IntegrationTests
dotnet sln add tests/ShortLi.ArchitectureTests

dotnet add src/ShortLi.Api reference src/ShortLi.Application
dotnet add src/ShortLi.Api reference src/ShortLi.Infrastructure
dotnet add src/ShortLi.Api reference src/ShortLi.Contracts

dotnet add src/ShortLi.Infrastructure reference src/ShortLi.Application
dotnet add src/ShortLi.Infrastructure reference src/ShortLi.Domain
dotnet add src/ShortLi.Application reference src/ShortLi.Domain

dotnet new packagesprops 