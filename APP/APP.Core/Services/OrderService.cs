using APP.Core.Models;
using DB;
using DB.Entities;

namespace APP.Core.Services;

public class OrderService : BaseService<Order>
{
    public OrderService(AppDbContext dbContext) : base(dbContext)
        {}
    
    public async Task<List<Order>> GetAllAsync()
    {
        return await SelectAllAsync();
    }
}