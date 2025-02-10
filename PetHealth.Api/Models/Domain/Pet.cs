using System.ComponentModel.DataAnnotations.Schema;

namespace PetHealth.Api.Models.Domain
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
