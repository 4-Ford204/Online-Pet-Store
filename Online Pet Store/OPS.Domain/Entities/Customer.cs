﻿namespace OPS.Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public ICollection<Pet> Pets { get; set; } = [];
    }
}
