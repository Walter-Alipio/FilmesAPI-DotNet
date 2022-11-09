# Operações essenciais com verbos HTTP

## Catalogo de filmes

## 🔨 Objetivo do projeto

O projeto tem como objetivo a criação de uma API no padrão REST que oferece acesso a uma biblioteca de filmes, onde é possível cadastrar, listar, alterar ou deletar um filme através da utilização dos verbos PUT, GET, PUT, DELETE.

## Evoluindo o projeto

Novas entidades foram criadas com suas respectivas rotas. Agora o projeto conta com as entidades Cinemas, Endereços, Gerentes e Sessões. Para as consultas, é possível pesquisar filmes por seu id ou pela classificação etária, assim como na rota de cinema onde, além de pesquisar por id, é possível pesquisar o cinema pelo nome do filme.<br>
Foram trabalhados relacionamentos 1:1, 1:n e n:n através do Entyti Framework.

## ✔️ Técnicas e tecnologias utilizadas

- `MVC`, `DTOs (Data Transfer Objects)`, `Query Parameters` , `jwt baerer`
  <br>

- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) , [EntityFrameworkCore 6.0.10](https://learn.microsoft.com/en-us/ef/) , [AutoMapper 12.0.0](https://automapper.org/) , [FluentResults 3.14.0](https://github.com/altmann/FluentResults) , [MySQL 8](https://dev.mysql.com/doc/relnotes/mysql/8.0/en/) , [Pomelo.EntityFrameworkCore](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
