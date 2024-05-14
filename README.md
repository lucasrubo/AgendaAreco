# Agenda
Neste projeto me aventurei um pouco com C# usando fullcalendar para listar as tarefas na tela de início. 

# Como instalar
 - Baixe o arquivo.
 - Verifique se tenha instalado tudo do [Requirements](https://github.com/lucasrubo/AgendaAreco/README.md#agenda).
 - Abra a solução ```Agenda.sln```.
 - Altere a ```linha 18``` do ```Program.cs``` com os dados do seu banco de dados.
 - Após alterar esse dados rode os códigos abaixo para criação de banco de dados:
    ```bash
    dotnet build
    ```
    ```bash
    dotnet ef migrations add Inicial
    ```
    ```bash
    dotnet ef database update
    ```
    Caso você não consiga executar os códigos acima rode o abaixo primeiro e repita os outros dois:
    ```bash
     dotnet tool install --global dotnet-ef
    ```
 - Pronto! Agora é só dar um RUN na aplicação ou rodar ```dotnet run```
   
# Gerando um Docker
 ## Construa a imagem Docker:
  1. Abra um terminal na raiz do seu projeto e execute o seguinte comando para construir a imagem Docker:
     ```
      docker build -t nome-da-sua-imagem 
     ```
      Substitua "nome-da-sua-imagem" pelo nome que deseja dar à sua imagem Docker.

  2. Execute o contêiner Docker:
  Depois que a imagem for construída com sucesso, você pode executar um contêiner Docker com o seguinte comando:
     ```
      docker run -d -p 8080:80 --name meu-container nome-da-sua-imagem
     ```
      Isso executará o contêiner em segundo plano (-d), mapeará a porta 8080 do host para a porta 80 do contêiner (-p 8080:80), e dará um nome ao contêiner (--name meu-container).

  3. Verifique se o contêiner está em execução:
  Você pode verificar se o contêiner está em execução com o comando:
     ```
      docker ps
     ```
      Isso listará todos os contêineres em execução no seu sistema.

# Requirements
 - .NET 8.
 - Visual Studio ou semelhante.
 - Mysql.
