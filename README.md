# TaskManager API

## 📜 Descrição

O projeto **TaskManager API** é uma API RESTful para um sistema de gerenciamento de usuários e tarefas, construído com .NET e C#. O objetivo é criar um sistema que permita cadastrar usuários e tarefas, relacionando-os e persistindo os dados em um banco de dados, aplicando conceitos de Orientação a Objetos, LINQ e boas práticas de desenvolvimento.

---

## ✨ Funcionalidades Principais

- **Gerenciamento de Usuários:** API completa com operações de Criar, Listar, Atualizar e Excluir usuários (CRUD).
- **Gerenciamento de Tarefas:** API completa com operações de Criar, Listar, Atualizar e Excluir tarefas (CRUD).
- **Consultas Avançadas com LINQ:**
    - Listar tarefas de um usuário específico.
    - Filtrar tarefas por status (pendente, concluída, etc.).
    - Buscar tarefas por período (data inicial e final).
- **Documentação Interativa:** A API é totalmente documentada e testável via Swagger (OpenAPI).

---

## 🚀 Tecnologias Utilizadas

- **.NET 8**
- **C#**
- **Entity Framework Core:** ORM para interação com o banco de dados.
- **MySQL:** Sistema de gerenciamento de banco de dados relacional.
- **Swagger (Swashbuckle):** Para documentação da API.

---

## ⚙️ Como Executar a Aplicação

**Pré-requisitos:**
- .NET 8 SDK
- Um servidor de banco de dados MySQL
- Git

**Passos:**

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/Joaopedrotavaress/TaskManager.git](https://github.com/Joaopedrotavaress/TaskManager.git)
    ```

2.  **Navegue até o diretório do projeto:**
    ```bash
    cd TaskManager
    ```

3.  **Configure a string de conexão:**
    - Abra o arquivo `appsettings.json`.
    - Altere a `AppDbConnectionString` com as credenciais do seu banco de dados MySQL.

4.  **Aplique as migrations do Entity Framework para criar o banco de dados:**
    ```bash
    dotnet ef database update
    ```

5.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```

6.  **Acesse a documentação Swagger no seu navegador para testar:**
    - **URL:** [http://localhost:5000/swagger](http://localhost:5000/swagger) (ou a porta indicada no terminal).

---

## 📁 Estrutura do Projeto (Simplificada)
- TaskManager/
  - Controllers/
    - UsuariosController.cs
    - TarefasController.cs
  - Data/
    - AppDbContext.cs
  - Models/
    - Usuario.cs
    - Tarefa.cs
  - Migrations/
  - appsettings.json
  - Program.cs
  - TaskManager.csproj
---

## 🔧 Componentes e Tecnologias

### Entity Framework Core (EF Core)
O EF Core é um mapeador objeto-relacional (ORM) moderno e multiplataforma. Neste projeto, ele é utilizado na abordagem *Code-First*, onde os modelos C# (`Usuario.cs`, `Tarefa.cs`) são usados para gerar a estrutura do banco de dados MySQL. Ele simplifica as operações de acesso a dados e permite o uso de LINQ para consultas complexas.

### Swagger (OpenAPI)
A API utiliza Swagger, implementado através da biblioteca `Swashbuckle.AspNetCore`. Ele gera uma interface de usuário rica e interativa que permite a qualquer pessoa visualizar e interagir com os recursos da API sem ter acesso ao código-fonte. Cada endpoint é documentado, mostrando os parâmetros esperados, corpos de requisição e respostas possíveis.

### LINQ (Language-Integrated Query)
O LINQ é um componente poderoso da linguagem C# que adiciona capacidades de consulta de dados de forma nativa. No projeto, ele é amplamente utilizado para filtrar e buscar informações no banco de dados de maneira expressiva e legível, como na busca de tarefas por status ou por período.

---

## 🔗 Endpoints da Aplicação

A API está organizada em dois recursos principais: `Usuarios` e `Tarefa`.

### Recurso: `/api/Usuarios`
- `POST /api/Usuarios` - Cria um novo usuário.
- `GET /api/Usuarios` - Retorna uma lista de todos os usuários.
- `GET /api/Usuarios/{id}` - Busca um usuário específico pelo seu ID.
- `PUT /api/Usuarios/{id}` - Atualiza os dados de um usuário existente.
- `DELETE /api/Usuarios/{id}` - Exclui um usuário.

### Recurso: `/api/Tarefa`
- `POST /api/Tarefa` - Cria uma nova tarefa.
- `GET /api/Tarefa` - Retorna uma lista de todas as tarefas.
- `GET /api/Tarefa/por-id/{id}` - Busca uma tarefa específica pelo seu ID.
- `GET /api/Tarefa/por-status/{status}` - Filtra tarefas por um status específico.
- `GET /api/Tarefa/por-periodo` - Busca tarefas dentro de um intervalo de datas.
- `PUT /api/Tarefa/{id}` - Atualiza os dados de uma tarefa existente.
- `DELETE /api/Tarefa/{id}` - Exclui uma tarefa.

---

## 📦 Dependências (NuGet Packages)

As principais dependências do projeto, configuradas no arquivo `.csproj`, incluem:

- **`Microsoft.EntityFrameworkCore`**: Framework principal do EF Core.
- **`Pomelo.EntityFrameworkCore.MySql`**: Provedor do EF Core para MySQL.
- **`Microsoft.EntityFrameworkCore.Tools`**: Ferramentas de linha de comando para EF Core (ex: migrations).
- **`Swashbuckle.AspNetCore`**: Implementação do Swagger para documentação da API.

---

## 🛠️ Detalhes da Arquitetura

- **Controllers (`UsuariosController`, `TarefasController`):** Responsáveis por receber as requisições HTTP, processar as entradas e retornar as respostas. Eles orquestram a lógica de negócio, interagindo com o `DbContext`.
- **Models (`Usuario`, `Tarefa`):** Classes que representam as entidades do domínio. O EF Core as utiliza para mapear as tabelas no banco de dados.
- **DbContext (`AppDbContext`):** Representa a sessão com o banco de dados, permitindo consultar e salvar instâncias das entidades. É o principal ponto de interação com o EF Core.
