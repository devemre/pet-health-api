using System.ComponentModel.DataAnnotations.Schema;

namespace PetHealth.Api.Models.Domain
{
    public class Visit
    {
        public Guid Id { get; set; }
        [ForeignKey("Veterinarian")]
        public Guid VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }
        [ForeignKey("Pet")]
        public Guid PetId { get; set; }
        public Pet Pet { get; set; }
        public DateTime VisitDate { get; set; } = DateTime.UtcNow;
    }
}
