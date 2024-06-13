using Microsoft.EntityFrameworkCore;
using MinimalVSA.Features.Category.DTOs;
using MinimalVSA.Features.Category.Interfaces;
using MinimalVSA.Features.Category.Mapper;
using MinimalVSA.Infrastructure.Database;

namespace MinimalVSA.Features.Category.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetCategoryResponse>> GetCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories.MapToDto();
    }

    public async Task<GetCategoryResponse> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        return category.MapToDto();
    }

    public async Task<bool> AddCategoryAsync(AddCategoryRequest request)
    {
        await _context.Categories.AddAsync(request.MapToEntity());
        return await _context.SaveChangesAsync() > 0;
    }
}