using Microsoft.EntityFrameworkCore;
using OPS.Domain.Entities;
using System.Text.Json;

namespace OPS.Infrastructure.MSSQL.DataSeeding
{
    public static class Seeding
    {
        public static async Task InitializeAsync(DataContext dbContext)
        {
            var tables = new List<object>()
            {
                new SeedingConfiguration<Customer>
                {
                    DbSet = dbContext.Customers,
                    FileName = "customers.json"
                },
                new SeedingConfiguration<Species>
                {
                    DbSet = dbContext.Species,
                    FileName = "species.json"
                },
                new SeedingConfiguration<Breed>
                {
                    DbSet = dbContext.Breeds,
                    FileName = "breeds.json"
                },
                new SeedingConfiguration<Pet>
                {
                    DbSet = dbContext.Pets,
                    FileName = "pets.json"
                }
            };
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            foreach (var table in tables.Cast<ISeedingConfiguration>())
            {
                await table.PopulateAsync(jsonSerializerOptions);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    public interface ISeedingConfiguration
    {
        Type Type { get; }
        Task PopulateAsync(JsonSerializerOptions jsonSerializerOptions);
    }

    public class SeedingConfiguration<T> : ISeedingConfiguration where T : class
    {
        public required DbSet<T> DbSet { get; set; }
        public required string FileName { get; set; }

        public Type Type => typeof(T);

        public async Task PopulateAsync(JsonSerializerOptions jsonSerializerOptions)
        {
            if (await DbSet.AnyAsync()) return;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "OPS.Infrastructure", "MSSQL", "DataSeeding", FileName);

            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            var json = await File.ReadAllTextAsync(filePath);
            var entities = JsonSerializer.Deserialize<List<T>>(json, jsonSerializerOptions);

            if (entities != null)
            {
                await DbSet.AddRangeAsync(entities);
            }

        }
    }
}
