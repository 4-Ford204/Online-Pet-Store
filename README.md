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
  
</details>

## 🚀 Getting Started

### 🛠️ Prerequisites

- .NET 9.0 SDK
- EF Core CLI
- Microsoft SQL Server
- Redis

### 🗃️ Migration

```
dotnet ef migrations add InitialCreate --context DataContext --output-dir MSSQL/Migrations
dotnet ef database update --context DataContext
```
