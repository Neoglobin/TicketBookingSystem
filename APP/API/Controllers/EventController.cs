using API.Requests;
using APP.Core.Models;
using APP.Core.Services;
using DB;
using DB.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api[controller]")]
public class EventController(AppDbContext dbContext) : ControllerBase
{
    [Authorize]
    [HttpGet("events")]
    public async Task<ActionResult<List<Event>>> GetAllAsync()
    {
        try
        {
            return Ok(await dbContext.Event.AsNoTracking().ToListAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("{id:guid}/event")]
    public async Task<ActionResult<Event>> Get(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Incorrect or empty id was given");
        }

        try
        {
            return Ok(await dbContext.Event.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpPost("add")]
    public async Task<ActionResult<bool>> AddAsync(AddEventRequest request)
    {
        try
        {
            var entity = new Event();
            var seatService = new SeatService(dbContext);
            
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.StartDate = request.StartDate;
            entity.Location = request.Location;
            
            await entity.SaveAsync(dbContext);
            return Ok(await seatService.GenerateEventSeats(entity));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpPut("update")]
    public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] UpdateEventRequest request)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Incorrect or default id was given");
        }
        
        try
        {
            var entity = await dbContext.FindAsync<Event>(id) 
                         ?? throw new Exception();
            
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.StartDate = request.StartDate;
            entity.Location = request.Location;

            return Ok(await entity.SaveAsync(dbContext));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpDelete("delete")]
    public async Task<ActionResult<bool>> DeleteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Incorrect or default id was given");
        }

        try
        {
            return Ok((await dbContext.Event.AsNoTracking().Where(x => x.Id == id).ExecuteDeleteAsync()) > 0);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}