# Projeto Fullstack: Cadastro de Produtos

Este projeto é um sistema simples de **cadastro de produtos**, construído com **Angular 20** no frontend e **.NET 9** no backend.  
Possui funcionalidades de **listagem, criação, edição e exclusão** de produtos e integração com **Swagger** para teste da API.

---

## Tecnologias Utilizadas

- **Frontend:** Angular 20  
- **Backend:** .NET 9 (ASP.NET Core Web API)  
- **Banco de Dados:** Em memória (SQLite em memoria)  
- **Documentação da API:** Swagger  
- **Controle de versão:** Git  

---

## Funcionalidades

- Listar todos os produtos cadastrados  
- Criar novos produtos  
- Editar produtos existentes
- Excluir produtos  
- API documentada e testável via Swagger  

---

## Estrutura do Projeto
### Frontend

- Componentes:
  - ListaProdutos: exibe a lista de produtos
  - Formulario: formulário para criar produtos
  - Serviço: ProdutoService para consumir a API .NET  
  - Reatividade para atualizar a lista em tempo real  

### Backend

- Controllers: ProdutosController com endpoints CRUD  
- Model: ProdutoModel  
- Swagger configurado para testar endpoints  
- Banco de dados em memória

---

## Como Rodar o Projeto

### Backend (.NET 9)
Swagger em https://localhost:44362/index.html


Frontend Angular 20
http://localhost:4200/


