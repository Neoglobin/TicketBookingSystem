using DB;
using DB.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api[controller]")]
public class SeatController(AppDbContext dbContext) : ControllerBase
{
    [Authorize]
    [HttpPost("GetAvailable")]
    public async Task<ActionResult<List<Seat>>> GetAvailableSeats(Guid eventId)
    {
        if (eventId == Guid.Empty)
        {
            return BadRequest("Empty id was given");
        }

        try
        {
            return Ok(await dbContext.Seat.AsNoTracking().Where(x => x.EventId == eventId).ToListAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }        
}