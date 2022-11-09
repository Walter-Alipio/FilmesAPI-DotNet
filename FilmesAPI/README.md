## 🛠️ Abrir e rodar o projeto

Altere o arquivo appsettings.json incluindo o código:

` "ConnectionStrings": { "FilmeConnection": //string de conexão }`

Criar a base de dados:

`dotnet ef database update`

## Uso

A autenticação feita por Bearer Token é necessária para todas as rotas.
<br>
É necessário ter autorização "admin" para alterações e "regular" para visualização.

# **Filme**

### 1.1 Cadastra um novo filme

| Método | Autorização | Rota   | Descrição         | Body Params | Query Params |
| ------ | ----------- | ------ | ----------------- | ----------- | ------------ |
| POST   | admin       | /filme | Cadastra um filme | JSON        | -            |

#### Body Params exemplo:

```
{
    "titulo": "Pantera Negra",
    "diretor": "Ryan Coogler",
    "genero": "Ação",
    "duracao": 134,
    "classificacaoEtaria": 13
}
```

#

### 1.2 Retorna filmes

| Método | Autorização     | Rota   | Descrição                     | Body Params | Query Params                |
| ------ | --------------- | ------ | ----------------------------- | ----------- | --------------------------- |
| GET    | admin / regular | /filme | Retorna os filmes cadastrados | -           | classificacaoEtaria=`{int}` |

#

### 1.3 Retorna filme por Id

| Método | Autorização     | Rota          | Descrição        | Body Params | Query Params |
| ------ | --------------- | ------------- | ---------------- | ----------- | ------------ |
| GET    | admin / regular | /filme/`{id}` | Retorna um filme | -           | -            |

#

### 1.4 Alterar dados filme

| Método | Autorização | Rota          | Descrição                   | Body Params | Query Params |
| ------ | ----------- | ------------- | --------------------------- | ----------- | ------------ |
| PUT    | admin       | /filme/`{id}` | Altera os dados de um filme | JSON        | -            |

#### Body Params exemplo:

```
{
    "titulo": "Pantera Negra",
    "diretor": "Ryan Coogler",
    "genero": "Ação",
    "duracao": 134,
    "classificacaoEtaria": 13
}
```

#

### 1.5 Deleta filme

| Método | Autorização | Rota          | Descrição            | Body Params | Query Params |
| ------ | ----------- | ------------- | -------------------- | ----------- | ------------ |
| DELETE | admin       | /filme/`{id}` | Apaga um filme do BD | -           | -            |

<br><br><br>

# **Endereço**

### 2.1 Cadastra um novo endereço

| Método | Autorização | Rota      | Descrição            | Body Params | Query Params |
| ------ | ----------- | --------- | -------------------- | ----------- | ------------ |
| POST   | admin       | /endereco | Cadastra um endereço | JSON        | -            |

#### Body Params exemplo:

```
{
  "Logradouro": "Rua Augusta",
  "Bairro": " Consolação - SP",
  "Numero": 1475
}
```

#

### 2.2 Retorna endereços

| Método | Autorização     | Rota      | Descrição                        | Body Params | Query Params |
| ------ | --------------- | --------- | -------------------------------- | ----------- | ------------ |
| GET    | admin / regular | /endereco | Retorna os endereços cadastrados | -           | -            |

#

### 2.3 Retorna endereço por Id

| Método | Autorização     | Rota             | Descrição           | Body Params | Query Params |
| ------ | --------------- | ---------------- | ------------------- | ----------- | ------------ |
| GET    | admin / regular | /endereco/`{id}` | Retorna um endereco | -           | -            |

#

### 2.4 Alterar dados endereço

| Método | Autorização | Rota             | Descrição                      | Body Params | Query Params |
| ------ | ----------- | ---------------- | ------------------------------ | ----------- | ------------ |
| PUT    | admin       | /endereco/`{id}` | Altera os dados de um endereco | JSON        | -            |

#### Body Params exemplo:

```
{
  "Logradouro": "Rua Augusta",
  "Bairro": " Consolação - SP",
  "Numero": 1475
}
```

#

### 2.5 Deleta endereço

| Método | Autorização | Rota             | Descrição               | Body Params | Query Params |
| ------ | ----------- | ---------------- | ----------------------- | ----------- | ------------ |
| DELETE | admin       | /endereco/`{id}` | Apaga um endereço do BD | -           | -            |

<br><br><br>

# **Gerente**

### 3.1 Cadastra um novo gerente

| Método | Autorização | Rota     | Descrição           | Body Params | Query Params |
| ------ | ----------- | -------- | ------------------- | ----------- | ------------ |
| POST   | admin       | /gerente | Cadastra um gerente | JSON        | -            |

#### Body Params exemplo:

```
{
  "Nome":"João da Silva"
}
```

#

### 3.2 Retorna gerente por Id

| Método | Autorização | Rota            | Descrição          | Body Params | Query Params |
| ------ | ----------- | --------------- | ------------------ | ----------- | ------------ |
| GET    | admin       | /gerente/`{id}` | Retorna um gerente | -           | -            |

<br><br><br>

# **Cinema**

### 4.1 Cadastra um novo cinema

| Método | Autorização | Rota    | Descrição          | Body Params | Query Params |
| ------ | ----------- | ------- | ------------------ | ----------- | ------------ |
| POST   | admin       | /cinema | Cadastra um cinema | JSON        | -            |

#### Body Params exemplo:

```
{
  "Nome":"Itaú Cinemas - Augusta",
  "EnderecoId": 3,
  "GerenteId": 1
}
```

#

### 4.2 Retorna cinemas

| Método | Autorização     | Rota    | Descrição                      | Body Params | Query Params            |
| ------ | --------------- | ------- | ------------------------------ | ----------- | ----------------------- |
| GET    | admin / regular | /cinema | Retorna os cinemas cadastrados | -           | ?nomeDoFilme=`{string}` |

#

### 4.3 Retorna cinema por Id

| Método | Autorização     | Rota           | Descrição         | Body Params | Query Params |
| ------ | --------------- | -------------- | ----------------- | ----------- | ------------ |
| GET    | admin / regular | /cinema/`{id}` | Retorna um cinema | -           | -            |

#

### 4.4 Alterar dados cinema

| Método | Autorização | Rota           | Descrição                    | Body Params | Query Params |
| ------ | ----------- | -------------- | ---------------------------- | ----------- | ------------ |
| PUT    | admin       | /cinema/`{id}` | Altera os dados de um cinema | JSON        | -            |

#### Body Params exemplo:

```
{
  "Nome":"Itaú Cinemas - Augusta",
  "EnderecoId": 3,
  "GerenteId": 1
}
```

#

### 4.5 Deleta cinema

| Método | Autorização | Rota           | Descrição             | Body Params | Query Params |
| ------ | ----------- | -------------- | --------------------- | ----------- | ------------ |
| DELETE | admin       | /cinema/`{id}` | Apaga um cinema do BD | -           | -            |

<br><br><br>

# **Sessão**

### 5.1 Cadastra um novo sessão

| Método | Autorização | Rota    | Descrição           | Body Params | Query Params |
| ------ | ----------- | ------- | ------------------- | ----------- | ------------ |
| POST   | admin       | /sessao | Cadastra uma sessão | JSON        | -            |

#### Body Params exemplo:

```
{
  "CinemaId": 11,
  "FilmeId": 8,
  "horarioDeEncerramentoDaSessao": "2002-01-01T21:00:00Z"
}
```

#

### 5.2 Retorna sessão por Id

| Método | Autorização | Rota           | Descrição          | Body Params | Query Params |
| ------ | ----------- | -------------- | ------------------ | ----------- | ------------ |
| GET    | admin       | /sessao/`{id}` | Retorna uma sessão | -           | -            |

## Retorno - JSON

```
{
  "id": 16,
  "cinema": {
    "id": 11,
    "nome": "Multiplex PlayArte Marabá",
    "endereco": {
      "id": 1,
      "logradouro": "Av. Ipiranga",
      "bairro": "Centro - SP",
      "numero": 757
    },
    "enderecoId": 1,
    "gernte": {
      "id": 1,
      "nome": "João da Silva"
    },
    "gerenteId": 1
  },
  "filme": {
    "id": 6,
    "titulo": "Star Wars - Uma nova esperança",
    "diretor": "George Lucas",
    "genero": "Aventura",
    "duracao": 180,
    "classificacaoEtaria": 0
  },
  "horarioDeEncerramentoDaSessao": "2002-01-01T21:00:00",
  "horarioDeInicio": "2002-01-01T18:00:00"
}
```

<br><br><br>
