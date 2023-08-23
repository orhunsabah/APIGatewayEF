using System;
using Microsoft.EntityFrameworkCore;

public interface IProductRepository
{
    Task<Product1> GetProductByIdAsync(int id);
    Task AddProductAsync(Product1 product);
}

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product1> GetProductByIdAsync(int id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task AddProductAsync(Product1 product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }
}

