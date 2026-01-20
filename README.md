# CQRS Consolidation

Projeto de consolidação do padrão arquitetural **CQRS (Command Query Responsibility Segregation)**, desenvolvido com base no curso do **Macoratti**, com foco em organização, clareza arquitetural e boas práticas em aplicações .NET.

## 📌 Objetivo do Projeto

Este projeto tem como objetivo consolidar os conceitos do padrão CQRS por meio da construção de uma **API REST simples**, implementando um **CRUD básico de uma entidade**, separando claramente as responsabilidades de **escrita** e **leitura**.

O foco não é complexidade de domínio, mas sim **arquitetura**, **organização do código** e **uso correto das ferramentas**.

## 🧠 Conceitos Aplicados

- Separação entre **Commands** (escrita) e **Queries** (leitura)
- Handlers específicos para cada operação
- Validações desacopladas da camada de aplicação
- Infraestrutura separada do domínio
- Código organizado para facilitar manutenção e evolução

## 🏗️ Arquitetura

O projeto segue os princípios do **CQRS**, com a seguinte abordagem:

- **Write Model**
  - Utiliza **Entity Framework Core**
  - Responsável por operações de criação, atualização e exclusão
- **Read Model**
  - Utiliza **Dapper**
  - Responsável exclusivamente por consultas
- **Validações**
  - Implementadas com **FluentValidation**
  - Aplicadas aos comandos

## 🛠️ Bibliiotecas Utilizadas

- **Entity Framework Core** (escrita)
- **Dapper** (leitura)
- **FluentValidation**
