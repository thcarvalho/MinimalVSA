namespace MinimalVSA.Features.Product.DTOs;

public record GetProductResponse(int Id, string Name, decimal Price, int CategoryId, string CategoryName);