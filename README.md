# Api with dotnet-6.0

## Api de Filmes utilizando .NET 6, Entity Framework, Identity e banco de dados mysql rodando em docker.

### Instalação

OBS: O projeto foi realizado usando somente dotnet CLI, mas pode ser usando tranquilamente dentro do Visual Studio.

#### Build
Para realizar o build do projeto basta entrar na pasta API-Dotnet e rodar o comando: `dotnet build`.

#### Migrations
Para executar as migrations primeiro precisamos estar com bando de dados executando

1. Para subir o banco de dados usando docker basta entrar na pasta database-docker e executar o comando: `docker-compose up -d`

2. Execute o comando para instalar o dotnet ef tools: `dotnet tool install --global dotnet-ef`

3. Em seguida execute o comando de criação de migration: `dotnet ef migrations add FilmeMigration`, caso queira execurar de fora da para do projeto é so usar `dotnet ef migrations add FilmeMigration --project FIlmesApi` o mesmo serve para o projeto UsuariosApi, é so executar o mesmo comando substituindo o projeto FilmesAPi por UsuariosApi.

4. Agora Aplique as mudanças no banco de dados: `dotnet ef database update`

#### Run
Para subir os projetos localmente é so executar os comando abaixo:

1. rodar o projeto FilmesApi: `dotnet run --project FilmesApi`

2. rodar o projeto UsuariosApi: `dotnet run --project UsuariosApi`
