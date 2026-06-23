using APP.Core.Services;
using DB;
using DB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(AppDbContext appDbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAll()
    {
        var service = new OrderService(appDbContext);
        try
        {
            return Ok(await service.GetAllAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}

