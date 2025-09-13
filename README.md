# TaskManager API

Este projeto é uma API RESTful para um sistema de gerenciamento de usuários e tarefas, construído com .NET e C#.

> ### 🎯 Objetivo
> Criar um sistema que permita cadastrar usuários e tarefas, relacionando-os. O sistema deve armazenar os dados em um banco de dados, aplicar conceitos de C#/.NET e OOP, além de usar LINQ e boas práticas de desenvolvimento.

---

## 🚀 Tecnologias Utilizadas

* **.NET 8**
* **C#**
* **Entity Framework Core**
* **MySQL**
* **Swagger (OpenAPI)** para documentação da API

---

## 🔹 Funcionalidades

### Funcionalidades Implementadas
- [x] **Cadastro de Usuários:** API completa com rotas para Criar, Listar, Atualizar e Excluir usuários (CRUD).

### Funcionalidades Pendentes
- [ ] **Cadastro de Tarefas:** Implementar o CRUD completo para tarefas.
- [ ] **Consultas com LINQ:**
    - [ ] Listar tarefas de um usuário específico.
    - [ ] Filtrar tarefas por status (pendente, concluída, etc.).
    - [ ] Buscar tarefas por período.
- [ ] **Validações e Exceções:**
    - [ ] Impedir cadastro de usuário com e-mail duplicado.
    - [ ] Impedir criação de tarefa sem título.

---

## Endpoints da API

A documentação completa e interativa da API está disponível via Swagger em `/swagger` quando a aplicação está em execução.

### Recurso: `/api/Usuarios`

#### `POST /api/Usuarios`
Cria um novo usuário.

* **Corpo da Requisição (Request Body):**
    ```json
    {
      "nome": "string",
      "email": "user@example.com"
    }
    ```
* **Resposta de Sucesso (200 OK):**
    ```json
    {
      "nome": "string",
      "email": "string",
      "id": 0,
      "tarefas": []
    }
    ```
---
#### `GET /api/Usuarios`
Retorna uma lista de todos os usuários.

* **Resposta de Sucesso (200 OK):**
    ```json
    [
      {
        "nome": "string",
        "email": "string",
        "id": 0,
        "tarefas": [
          {
            "id": 0,
            "titulo": "string",
            "descricao": "string",
            "status": "string",
            "dataCriacao": "2025-09-13T02:26:01.035Z",
            "usuarioId": 0
          }
        ]
      }
    ]
    ```
---
#### `GET /api/Usuarios/{id}`
Busca um usuário específico pelo seu `id`.

* **Resposta de Sucesso (200 OK):**
    ```json
    {
      "nome": "string",
      "email": "string",
      "id": 0,
      "tarefas": []
    }
    ```
---
#### `PUT /api/Usuarios/{id}`
Atualiza os dados de um usuário existente.

* **Corpo da Requisição (Request Body):**
    ```json
    {
      "nome": "Novo Nome",
      "email": "novoemail@example.com"
    }
    ```
---
#### `DELETE /api/Usuarios/{id}`
Exclui um usuário específico pelo seu `id`.

* **Resposta de Sucesso (200 OK):** Retorna os dados do usuário que foi excluído.

---
## Como Executar o Projeto Localmente

1.  **Pré-requisitos:**
    * [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
    * Um servidor de banco de dados MySQL
    * Git

2.  **Passos:**
    ```bash
    # 1. Clone o repositório
    git clone [https://github.com/Joaopedrotavaress/TaskManager.git](https://github.com/Joaopedrotavaress/TaskManager.git)

    # 2. Navegue até a pasta do projeto
    cd TaskManager

    # 3. Configure a string de conexão com o banco de dados
    #    Abra o arquivo `appsettings.json` e altere a "AppDbConnectionString"
    #    com suas credenciais do MySQL.

    # 4. Aplique as migrations para criar as tabelas no banco de dados
    dotnet ef database update

    # 5. Execute a aplicação
    dotnet run

    # 6. Acesse a documentação Swagger no seu navegador
    #    http://localhost:5000/swagger (ou a porta que for indicada no terminal)
    ```

---

## Autor

* **João Pedro Tavares** - [GitHub](https://github.com/Joaopedrotavaress)
