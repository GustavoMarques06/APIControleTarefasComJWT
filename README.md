# 🔐 API Controle de Tarefas com JWT

API REST desenvolvida em **ASP.NET Core** utilizando **autenticação
JWT**, arquitetura em camadas e boas práticas de separação de
responsabilidades.

O objetivo do projeto é estudar e implementar autenticação segura
baseada em **JSON Web Token (JWT)** juntamente com gerenciamento de
tarefas (ToDo).

------------------------------------------------------------------------

## 🚀 Tecnologias Utilizadas

-   .NET / ASP.NET Core
-   Entity Framework Core
-   SQL Server
-   JWT (JSON Web Token)
-   Swagger / OpenAPI
-   Dependency Injection
-   Arquitetura em Camadas
-   Repository Pattern
-   Service Layer

------------------------------------------------------------------------

## 📁 Arquitetura do Projeto

O projeto segue separação por responsabilidades:

    API
    │
    ├── API              → Controllers (entrada HTTP)
    ├── Application      → Services, DTOs e Interfaces
    ├── Domain           → Entidades e contratos
    └── Infrastructure   → Banco de dados, JWT e Repositories

### ✔ Camadas

✅ **API** - Recebe requisições HTTP - Retorna respostas - Contém
Controllers

✅ **Application** - Regras de negócio - Services - DTOs

✅ **Domain** - Entidades principais - Interfaces dos repositórios

✅ **Infrastructure** - EF Core - JWT - Implementação dos repositories

------------------------------------------------------------------------

## 🔑 Autenticação JWT

A API utiliza autenticação baseada em **Bearer Token**.

Fluxo:

1.  Usuário realiza cadastro
2.  Usuário faz login
3.  API gera um JWT
4.  Token é enviado no Header:

Authorization: Bearer {token}

5.  Rotas protegidas validam o usuário automaticamente

------------------------------------------------------------------------

## 📌 Endpoints

### 🔐 Auth

  Método   Rota             Descrição
  -------- ---------------- --------------------------
  POST     /auth/register   Registrar usuário
  POST     /auth/login      Login e geração do token

------------------------------------------------------------------------

### ✅ ToDo (Protegido)

  Método   Rota          Descrição
  -------- ------------- ---------------------------
  GET      /tasks        Listar tarefas do usuário
  POST     /tasks        Criar tarefa
  PUT      /tasks/{id}   Atualizar tarefa
  DELETE   /tasks/{id}   Remover tarefa

⚠️ Necessário Token JWT.

------------------------------------------------------------------------

## 🧪 Testando com Swagger

1.  Execute o projeto:

``` bash
dotnet run
```

2.  Acesse:

https://localhost:{porta}/swagger

3.  Faça login em `/auth/login`
4.  Copie o token retornado
5.  Clique em **Authorize**
6.  Informe:

Bearer SEU_TOKEN

Agora as rotas protegidas estarão liberadas ✅

------------------------------------------------------------------------

## 🗄️ Banco de Dados

O banco é criado via **Entity Framework Core**.

Executar migrations:

``` bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

------------------------------------------------------------------------

## 🔒 Segurança

-   Senhas armazenadas com hash (`PasswordHasher`)
-   JWT assinado com chave secreta
-   Rotas protegidas com `[Authorize]`
-   Identificação do usuário via Claims

------------------------------------------------------------------------

## 🎯 Objetivo do Projeto

Este projeto foi desenvolvido para aprendizado de:

-   Autenticação moderna com JWT
-   Arquitetura limpa
-   Boas práticas em APIs REST
-   Segurança em aplicações backend

------------------------------------------------------------------------

## 👨‍💻 Autor

**Gustavo Marques**

GitHub: 👉 https://github.com/GustavoMarques06

------------------------------------------------------------------------

## ⭐ Melhorias Futuras

-   Refresh Token
-   Roles e Permissions
-   Paginação de tarefas
-   Docker
-   Testes Unitários
