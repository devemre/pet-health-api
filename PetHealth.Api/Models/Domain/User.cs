﻿namespace PetHealth.Api.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role {  get; set; }
        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
