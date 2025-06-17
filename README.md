# 🐾 Online-Pet-Store (OPS)

This is an online pet store built with .NET 9.0 that applies clean architecture.

---

## 📌 Tech Stack
<details>
  <summary><strong>.NET 9.0</strong></summary>
  
  - **API:**
    - FastEnpoints
    - Ardalis
    - MediatR
  - **Database:** Microsoft SQL Server  
  - **Distributed Cache:** Redis
  - **Message Broker:** RabbitMQ
  
</details>

## 🚀 Getting Started

### 🛠️ Prerequisites

<details>
  <summary>Installations</summary>
  
  - .NET 9.0 SDK
  - EF Core CLI
  - Microsoft SQL Server
  - Redis
  - RabbitMQ

</details>

### 🗃️ Migration

```
dotnet ef migrations add InitialCreate --context DataContext --output-dir MSSQL/Migrations
dotnet ef database update --context DataContext
```
