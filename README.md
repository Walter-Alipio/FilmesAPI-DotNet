# Operações essenciais com verbos HTTP

## Catalogo de filmes

![Badge em desenvolvimento](https://img.shields.io/badge/Status-Em%20Desenvolvimento-green)

## 🔨 Objetivo do projeto

O projeto tem como objetivo a criação de uma API no padrão REST que oferece acesso a uma biblioteca de filmes, onde é possível cadastrar, listar, alterar ou deletar um filme através da utilização dos verbos PUT,GET,PUT,DELETE

## 🔨 Evoluindo o projeto

Novas entidades foram criadas com suas respectivas rotas. Agora o projeto conta com as entidades Cinemas, Endereços, Gerentes e Sessões. Para as consultas, é possível pesquisar filmes por seu id ou pela classificação etária, assim como na rota de cinema onde, além de pesquisar por id, é possível pesquisar o cinema pelo nome do filme.<br>
Foram trabalhados relacionamentos 1:1, 1:n e n:n através do Entyti Framework.

## ✔️ Técnicas e tecnologias utilizadas

- `MVC`
- `.NET 6`
- `EntityFrameworkCore`
- `MySQL 8`
- `DTOs (Data Transfer Objects)`
- `AutoMapper`
- `Query Parameters`

## 🛠️ Abrir e rodar o projeto

Altere o arquivo appsettings.json incluindo o código:

` "ConnectionStrings": { "FilmeConnection": //string de conexão }`
