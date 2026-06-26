using API.Requests;
using APP.Core.Constants;
using APP.Core.Helpers;
using DB;
using DB.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api[controller]")]
public class OrderController(AppDbContext dbContext) : ControllerBase
{
    [Authorize]
    [HttpPost("Add")]
    public async Task<ActionResult<bool>> Add(AddOrderRequest request)
    {
        try
        {
            var currentUserId = AuthHelper.GetCurrentUserId(HttpContext);
            var order = new Order();

            if (currentUserId == Guid.Empty)
            {
                return BadRequest("Cannot create an order by unknown user");
            }
            
            order.UserId = currentUserId;
            order.EventId = request.EventId;
            order.SeatId = request.SeatId;
            order.StatusId = OrderStatusConstants.Active;

            return Ok(await order.SaveAsync(dbContext));

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpPut("Update")]
    public async Task<ActionResult<bool>> Update(Guid orderId, UpdateOrderRequest request)
    {
        try
        {
            var order = await dbContext.FindAsync<Order>(orderId)
                ?? throw new Exception();
            
            order.EventId = request.EventId;
            order.SeatId = request.SeatId;
            order.StatusId = request.StatusId;

            return Ok(await order.SaveAsync(dbContext));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpPut("Cancel")]
    public async Task<ActionResult<bool>> Cancel(Guid orderId)
    {
        try
        {
            var order = await dbContext.FindAsync<Order>(orderId)
                        ?? throw new Exception();
            
            order.StatusId = OrderStatusConstants.Cancelled;
            return Ok(await order.SaveAsync(dbContext));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("GetUserOrders")]
    public async Task<ActionResult<List<Order>>> GetUserOrders()
    {
        try
        {
            var currentUserId = AuthHelper.GetCurrentUserId(HttpContext);

            if (currentUserId == Guid.Empty)
            {
                return BadRequest("Cannot create an order by unknown user");
            }

            return Ok(await dbContext.Order.AsNoTracking().Where(x => x.UserId == currentUserId).ToListAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}