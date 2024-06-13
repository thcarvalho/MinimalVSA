namespace MinimalVSA.Features.Product.DTOs;

public record UpdateProductRequest(int Id, string Name, decimal Price, int CategoryId);