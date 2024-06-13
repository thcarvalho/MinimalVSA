using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MinimalVSA.Features.Product.DTOs;
using MinimalVSA.Features.Product.Interfaces;
using MinimalVSA.Features.Product.Mapper;
using MinimalVSA.Infrastructure.Database;

namespace MinimalVSA.Features.Product.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddProductAsync(AddProductRequest request)
    {
        await _context.Products.AddAsync(request.MapToEntity());
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateProductAsync(UpdateProductRequest request)
    {
        var current = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (current is not null)
        {
            current.UpdateFields(request.Name, request.Price, request.CategoryId);
            _context.Products.Update(current);
        }
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var current = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (current is not null)
            _context.Products.Remove(current);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<GetProductResponse> GetProductByIdAsync(int id)
    {
        var response = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        return response.MapToDto();
    }

    public async Task<IEnumerable<GetProductResponse>> GetProductsAsync()
    {
        var response = await _context.Products.Include(x => x.Category).ToListAsync();
        return response.MapToDto();
    }
}