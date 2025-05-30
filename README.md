# Online-Pet-Store

## Migration
dotnet ef migrations add InitialCreate --context DataContext --output-dir MSSQL/Migrations
dotnet ef database update --context DataContext

