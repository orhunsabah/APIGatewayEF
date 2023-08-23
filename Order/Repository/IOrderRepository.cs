using System;
using Microsoft.EntityFrameworkCore;

public interface IOrderRepository
{
    Task<Order1> GetOrderByIdAsync(int id);
    Task AddOrderAsync(Order1 order);
}

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order1> GetOrderByIdAsync(int id)
    {
        return await _dbContext.Orders.FindAsync(id);
    }

    public async Task AddOrderAsync(Order1 order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
    }
}

