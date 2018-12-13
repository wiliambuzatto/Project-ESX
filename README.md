Aplicação Web Api 2 utilizando o framework .NET 4.6

Para utilizar a aplicação pelo Visual Studio, configure o projeto "ESX.WebApi" para ser o projeto de inicialização.
Para realizar os requests na web api utilizei o programa PostMan (https://www.getpostman.com)

Foi criado 2 Controllers para realizar as requisições "MarcaController" e "PatrimonioController", dentro de delas existem a chamadas desenvolvidas cada uma com seu endereço definido e o tipo de request também.

A solução foi desenvolvida em DDD e padrão Repositório com o ORM NHibernate, para ajudar na configuração do ORM e os mapeamentos das entidades utilizei o FluentNHibernate.
Foi utilizado também o AutoMapper para facilitar o mapeamento dos objetos entidades da base de dados para as models do Web API, e também realizei a inversão de controle e injeção de dependência (Ninject) para não deixar o projeto acoplado.

Dentro da pasta "ESX.Arquivos" estão o schema do DataBase (ESX.schema.sql) e também o arquivo para importar as chamadas que criei no postman (ESX.postman.json).
