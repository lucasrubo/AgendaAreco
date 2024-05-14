# Use a imagem do SDK do .NET Core para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
WORKDIR /app

# Copie o arquivo do projeto e restaure as dependências
COPY *.csproj .
RUN dotnet restore

# Copie todos os arquivos do projeto e compile o aplicativo
COPY . .
RUN dotnet publish -c Release -o out

# Crie uma imagem de runtime para executar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Agenda.dll"]
