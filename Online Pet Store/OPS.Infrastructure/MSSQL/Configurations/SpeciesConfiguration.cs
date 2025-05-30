using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OPS.Domain.Entities;

namespace OPS.Infrastructure.MSSQL.Configurations
{
    class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("Species");

            builder.HasKey(s => s.SpeciesID);

            builder.Property(s => s.SpeciesID).ValueGeneratedOnAdd();
            builder.Property(s => s.Name).IsRequired();
        }
    }
}
