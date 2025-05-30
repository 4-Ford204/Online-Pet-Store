using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OPS.Domain.Entities;

namespace OPS.Infrastructure.MSSQL.Configurations
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("Breeds");

            builder.HasKey(b => b.BreedID);

            builder.Property(b => b.BreedID).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.SpeciesID).IsRequired(false);

            builder.HasOne(b => b.Species)
                .WithMany(s => s.Breeds)
                .HasForeignKey(b => b.SpeciesID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
