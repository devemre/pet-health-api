using Microsoft.EntityFrameworkCore;
using PetHealth.Api.Data;
using PetHealth.Api.Models.Domain;
using PetHealth.Api.Services.Interfaces;

namespace PetHealth.Api.Services
{
    public class VisitService : IVisitService
    {
        private readonly AppDbContext dbContext;

        public VisitService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateVisitAsync(Guid veterinarianId, List<Guid> petIds)
        {
            if (!await dbContext.Veterinarians.AnyAsync(v => v.Id == veterinarianId))
            {
                throw new Exception("Invalid veterinarian ID");
            }

            var visits = petIds.Select(petId => new Visit
            {
                VeterinarianId = veterinarianId,
                PetId = petId
            }).ToList();

            await dbContext.Visits.AddRangeAsync(visits);
            await dbContext.SaveChangesAsync();
        }
    }
}
