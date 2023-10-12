# Use a imagem oficial do ASP.NET Core 7
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use a imagem oficial do SDK do .NET 7 para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["to-do-api.csproj", "."]
RUN dotnet restore "./to-do-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "to-do-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "to-do-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use a imagem oficial do SQL Server
FROM mcr.microsoft.com/mssql/server:2019-latest AS db

# Configuração do SQL Server (ajuste conforme suas necessidades)
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=JggbykP1a94K
ENV MSSQL_PID=Developer
ENV MSSQL_COLLATION=SQL_Latin1_General_CP1_CI_AS

# Defina a pasta de trabalho para a pasta do aplicativo
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "to-do-api.dll"]
