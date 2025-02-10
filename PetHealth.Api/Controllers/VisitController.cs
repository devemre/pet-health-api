using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHealth.Api.Services.Interfaces;

namespace PetHealth.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService visitService;

        public VisitController(IVisitService visitService)
        {
            this.visitService = visitService;
        }

        [HttpPost("{veterinarianId}")]
        public async Task<IActionResult> CreateVisit([FromRoute] Guid veterinarianId, [FromBody] List<Guid> petIds)
        {
            if (petIds == null || !petIds.Any())
            {
                return BadRequest("Pet list cannot be empty");
            }

            try
            {
                await visitService.CreateVisitAsync(veterinarianId, petIds);
                return Ok("Visits created successfully");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occured.");
            }
        }
    }
}
