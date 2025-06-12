# Online-Pet-Store

## About OPS

### Tech Stack
<details>
  <summary>.NET 9.0</summary>
  <li>
    API
    <ul>
      <li>FastEndpoints</li>
      <li>Ardalis</li>
      <li>MediatR</li>
    </ul>
  </li>
</details>

## Getting Started

### Migration
dotnet ef migrations add InitialCreate --context DataContext --output-dir MSSQL/Migrations <br>
dotnet ef database update --context DataContext

### Redis

