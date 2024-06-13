using MinimalVSA.Features.Category.DTOs;
using MinimalVSA.Features.Product.DTOs;

namespace MinimalVSA.Features.Product.Interfaces;

public interface IProductService
{
    Task<bool> AddProductAsync(AddProductRequest request);
    Task<bool> UpdateProductAsync(UpdateProductRequest request);
    Task<bool> DeleteProductAsync(int id);
    Task<GetProductResponse> GetProductByIdAsync(int id);
    Task<IEnumerable<GetProductResponse>> GetProductsAsync();
}