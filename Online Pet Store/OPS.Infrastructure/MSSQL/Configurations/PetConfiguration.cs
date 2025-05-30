using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OPS.Domain.Entities;

namespace OPS.Infrastructure.MSSQL.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pets");

            builder.HasKey(p => p.PetID);

            builder.Property(p => p.PetID).ValueGeneratedOnAdd();
            builder.Property(p => p.BreedID).IsRequired(false);
            builder.Property(p => p.Age).IsRequired(false);
            builder.Property(p => p.Gender).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Image).IsRequired();

            builder.HasOne(p => p.Breed)
                .WithMany(b => b.Pets)
                .HasForeignKey(p => p.BreedID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
