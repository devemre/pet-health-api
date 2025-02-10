namespace PetHealth.Api.Services.Interfaces
{
    public interface IVisitService
    {
        Task CreateVisitAsync(Guid veterinarianId, List<Guid> petIds);
    }
}
