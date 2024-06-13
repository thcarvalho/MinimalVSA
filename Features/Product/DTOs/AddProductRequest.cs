namespace MinimalVSA.Features.Product.DTOs;

public record AddProductRequest(string Name, decimal Price, int CategoryId);