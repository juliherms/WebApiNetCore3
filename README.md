
Aplicação construída com Web API ASPNet Core 3


### Requisitos


### Instalação
```bash
$ docker pull microsoft/mssql-server-linux
$ docker run --name testesqlserver2017 -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=DockerSql2017!" -p 11433:1433 -d microsoft/mssql-server-linux:2017-latest
$ dotnet add package Microsoft.EntityFrameworkCore.SqlServer
$ dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

### Para executar a API
```bash
$ dotnet run
$ dotnet watch run
```



