namespace OPS.Domain.Entities
{
    public class Species
    {
        public int SpeciesID { get; set; }
        public required string Name { get; set; }

        public ICollection<Breed> Breeds { get; set; } = [];
    }
}
