﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OPS.Infrastructure.MSSQL;
using OPS.UseCases.Interfaces.InternalServices.Species;
using OPS.UseCases.Species;

namespace OPS.Infrastructure.Implementations.InternalServices.Species
{
    [Service(ServiceLifetime.Scoped)]
    public class GetSpeciesService : IGetSpecies
    {
        private readonly DataContext dbContext;

        public GetSpeciesService(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<GetSpeciesResponse>> Execute()
        {
            var species = await dbContext.Species.Include(s => s.Breeds).ToListAsync();
            var result = species
                .Select(s => new GetSpeciesResponse
                {
                    Name = s.Name,
                    Breeds = s.Breeds.Select(b => b.Name)
                })
                .ToList();

            return result;
        }
    }
}
