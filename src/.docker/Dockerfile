# Utiliza a imagem oficial do SDK do .NET 6 para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as dependências
COPY ../.. .

# Restaura as dependências e compila a aplicação
RUN dotnet restore "Backend/PostAppApi.Api/PostAppApi.Api.csproj"
RUN dotnet build "Backend/PostAppApi.Api/PostAppApi.Api.csproj" -c Release -o /app/build

# Publica a aplicação
RUN dotnet publish "Backend/PostAppApi.Api/PostAppApi.Api.csproj" -c Release -o /app/publish

# Cria uma imagem de tempo de execução leve para a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta 80 para acesso à API
EXPOSE 80

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "PostAppApi.Api.dll"]
