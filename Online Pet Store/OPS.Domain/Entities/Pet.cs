namespace OPS.Domain.Entities
{
    public class Pet
    {
        public int PetID { get; set; }
        public int? BreedID { get; set; }
        public int? Age { get; set; }
        public required bool Gender { get; set; }
        public required int Price { get; set; }
        public required string Image { get; set; }

        public Breed? Breed { get; set; }
    }
}
