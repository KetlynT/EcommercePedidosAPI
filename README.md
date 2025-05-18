
# 🛒 API de E-commerce - Controle de Pedidos com Padrões de Projeto

Este projeto é uma API RESTful desenvolvida com ASP.NET Core e C#, cujo objetivo é controlar pedidos de um sistema de e-commerce. Os pedidos podem mudar de status conforme seu progresso (pagamento, envio, etc.) e o sistema calcula o valor do frete dinamicamente.

Para promover um código limpo, escalável e de fácil manutenção, foram aplicados os princípios SOLID e os padrões de projeto **State**, **Strategy** e **Template Method**.

---

## 📌 Objetivos do Projeto

- Gerenciar o ciclo de vida de um pedido de forma robusta e segura.
- Calcular o frete com flexibilidade, suportando diferentes estratégias.
- Aplicar boas práticas de design de software com SOLID e padrões de projeto.

---

## 🧠 Padrões de Projeto Utilizados

### 🔄 **State** – Controle de Status dos Pedidos

Permite encapsular os diferentes estados de um pedido (AguardandoPagamento, Pago, Enviado, Cancelado) em classes separadas. Cada estado define quais transições são válidas, evitando grandes blocos condicionais no código.

**Benefícios:**
- Código organizado por responsabilidade.
- Redução de lógica condicional complexa.
- Permite adicionar novos estados sem modificar lógica existente.

### 🚚 **Strategy + Template Method** – Cálculo de Frete

Define diferentes formas de calcular o frete (terrestre ou aéreo) como estratégias intercambiáveis. O **Template Method** é usado para centralizar etapas comuns do cálculo.

**Benefícios:**
- Novos tipos de frete podem ser adicionados facilmente.
- Reutilização de lógica comum com o Template Method.
- Flexível para expansão conforme regras do negócio.

---

## 📜 Princípios SOLID Aplicados

### 🔹 **S – Single Responsibility Principle (SRP)**
Cada classe tem uma única responsabilidade:
- `Pedido` representa dados do pedido.
- `PedidoService` contém as regras de negócio.
- `FreteAereo`, `FreteTerrestre` calculam o frete.

### 🔹 **O – Open/Closed Principle (OCP)**
As classes estão abertas para extensão, mas fechadas para modificação. Por exemplo, novos tipos de frete podem ser adicionados implementando `IFreteStrategy` sem alterar o código já existente.

### 🔹 **L – Liskov Substitution Principle (LSP)**
As classes que implementam `IFreteStrategy` ou `IState` podem substituir suas interfaces sem afetar o funcionamento do sistema.

### 🔹 **I – Interface Segregation Principle (ISP)**
Interfaces como `IFreteStrategy` e `IState` são específicas e contêm apenas o que cada grupo de classes realmente precisa implementar.

### 🔹 **D – Dependency Inversion Principle (DIP)**
O `PedidoService` depende de abstrações (interfaces) como `IFreteStrategy` e `IState`, e não de implementações concretas.

**💡 Como validar o uso de SOLID?**
- Verifique a separação clara de responsabilidades por classe.
- Observe o uso de interfaces e injeção de dependência.
- A adição de uma nova funcionalidade (novo status ou frete) deve ser feita sem modificar o código existente.

---

## 🧱 Estrutura do Projeto

```
EcommercePedidosAPI/
├── Controllers/
│   └── PedidosController.cs
├── Enums/
│   └── Enums.cs
├── Models/
│   ├── Pedido.cs
│   ├── EstadoPedido/
│   │   ├── IState.cs, AguardandoPagamento.cs, Pago.cs, etc.
│   └── Frete/
│       ├── IFreteStrategy.cs, FreteTemplate.cs, FreteAereo.cs, FreteTerrestre.cs, FreteFactory.cs
├── Services/
│   └── PedidoService.cs
```

---

## 🔧 Funcionalidades Principais

### ✅ Criar Pedido
- Define status inicial como `AguardandoPagamento`
- Calcula o valor do frete com base no tipo
- Persiste no banco

### 🔄 Atualizar Pedido
- Permitido apenas se o status for `AguardandoPagamento`
- Recalcula o frete

### 💳 Pagar Pedido
- Transição de estado para `Pago` via classe `AguardandoPagamento.cs`

### 📦 Enviar Pedido
- Disponível apenas se o pedido estiver `Pago`

### ❌ Cancelar Pedido
- Possível em qualquer estado, dependendo da lógica definida

---

## 🧩 Diagramas de Classe

### 📌 Models

(https://github.com/KetlynT/EcommercePedidosAPI/blob/main/Class%20Diagram%20Ketlyn-%20Model.png)

### 📌 Service

(https://github.com/KetlynT/EcommercePedidosAPI/blob/main/Class%20Diagram%20Ketlyn-%20Service.png)
---

## 🔌 Tecnologias Utilizadas

- ASP.NET Core (.NET 6)
- C#
- Entity Framework Core
- API RESTful
- Padrões de Projeto (State, Strategy, Template Method)

---

## 🚀 Como Rodar o Projeto

1. Clone este repositório
2. Configure a connection string no `appsettings.json`
3. Execute as migrations (caso necessário)
4. Rode a aplicação com `dotnet run`

---

## ✍️ Autor

Projeto desenvolvido como prática de aplicação de padrões de projeto e princípios de arquitetura limpa, por @KetlynT.

