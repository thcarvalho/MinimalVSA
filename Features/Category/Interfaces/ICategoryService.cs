using MinimalVSA.Features.Category.DTOs;

namespace MinimalVSA.Features.Category.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<GetCategoryResponse>> GetCategoriesAsync();
    Task<GetCategoryResponse> GetCategoryByIdAsync(int id);
    Task<bool> AddCategoryAsync(AddCategoryRequest request);
}