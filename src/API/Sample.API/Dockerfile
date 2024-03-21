# Define a imagem base para os estágios de construção e publicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5211

# Define a variável de ambiente para configurar a porta HTTP
ENV ASPNETCORE_HTTP_PORTS=5211
#ENV ASPNETCORE_URLS=http://+:5211

# Define o usuário padrão para execução do contêiner
USER app

# Define a imagem base para o estágio de compilação
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release

# Define o diretório de trabalho e copia o arquivo de projeto para o contêiner
WORKDIR /projects
COPY ["src/API/Sample.API/Sample.API.csproj", "src/API/Sample.API/"]

# Restaura as dependências do projeto
RUN dotnet restore "src/API/Sample.API/Sample.API.csproj"
COPY . .

# Copia o script de inicialização e define permissões de execução
COPY ["src/API/Sample.API/wait-for-db-and-migrate.sh", "."]
# Definindo permissões de execução para o script
# RUN chmod +x "wait-for-db-and-migrate.sh"

# Exibe explicitamente o conteúdo do diretório /projects
RUN ls -la /projects

# Define o diretório de trabalho para a compilação do projeto
WORKDIR "/projects/src/API/Sample.API"

# Compila o projeto
RUN dotnet build "Sample.API.csproj" -c $configuration -o /app/build

# Define a imagem base para o estágio de publicação
FROM build AS publish
ARG configuration=Release

# Publica o projeto
RUN dotnet publish "Sample.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Define a imagem final a ser usada para execução do contêiner
FROM base AS final
WORKDIR /app



# Copia os arquivos publicados e o script de inicialização para o diretório de trabalho final
COPY --from=publish /app/publish .

# Copia o script de inicialização do diretório de construção para o diretório de trabalho final
COPY --from=build  /projects/wait-for-db-and-migrate.sh .
# Define permissões de execução para o script
# RUN chmod +x "wait-for-db-and-migrate.sh"

# Define o comando de entrada para iniciar a aplicação
ENTRYPOINT ["dotnet", "Sample.API.dll"]


# docker container run -d --name 'test-dev' -p5211:5211  --env 'ASPNETCORE_ENVIRONMENT=Development' sample/cadastro:test
