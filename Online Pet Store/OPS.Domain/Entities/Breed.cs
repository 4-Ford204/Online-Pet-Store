namespace OPS.Domain.Entities
{
    public class Breed
    {
        public int BreedID { get; set; }
        public required string Name { get; set; }
        public int? SpeciesID { get; set; }

        public Species? Species { get; set; }
        public ICollection<Pet> Pets { get; set; } = [];
    }
}
