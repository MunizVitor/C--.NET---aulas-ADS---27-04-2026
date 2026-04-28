# Projeto DESIGN PATTERN - API REST com Produto

## Autor
- Vitor Hugo Da Silva Muniz

## Descrição
Este projeto é uma aplicação **API REST** desenvolvida em **C# com ASP.NET Core** e **Entity Framework Core**.  
O objetivo é demonstrar o uso de **Design Patterns** (Factory Method, Repository, Service Layer) em uma arquitetura organizada.

## Estrutura do Projeto
projeto_DESIGN_PATTTERN/
├── Controllers/
│    └── ProdutoController.cs
├── Models/
│    ├── Produto.cs
│    ├── ProdutoDigital.cs
│    ├── ProdutoFisico.cs
│    └── ProdutoCriar.cs
├── Repository/
│    ├── IProdutoRepository.cs
│    └── ProdutoRepository.cs
├── Service/
│    ├── IProdutoService.cs
│    └── ProdutoService.cs
├── Data/
│    └── Context/
│         └── AppDbContext.cs
└── Program.cs

Código

## Padrões Utilizados
- **Factory Method** → Criação de objetos `ProdutoDigital` ou `ProdutoFisico` através da classe `ProdutoCriar`.
- **Repository Pattern** → Encapsula o acesso ao banco de dados (`ProdutoRepository`).
- **Service Layer** → Centraliza regras de negócio (`ProdutoService`).
- **Dependency Injection** → Configurado no `Program.cs` para injetar serviços e repositórios nos controladores.

## Como Executar
1. Configure a connection string no `appsettings.json`.
2. Instale os pacotes necessários:
   - `Microsoft.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.SqlServer`
   - `Microsoft.EntityFrameworkCore.Tools`
3. Crie a migration:
   ```powershell
   Add-Migration InitialCreate
   Update-Database
Execute a aplicação:

powershell
dotnet run
Acesse o Swagger em:

Código
https://localhost:5001/swagger
Endpoints Principais
POST /api/produto/{tipo} → Cria um produto (tipo = digital ou fisico).

GET /api/produto/all → Lista todos os produtos.

Projeto simples e estruturado para demonstrar API REST com Design Patterns em C#.
