using Carter;
using MinimalVSA.Features.Product.DTOs;
using MinimalVSA.Features.Product.Interfaces;

namespace MinimalVSA.Features.Product.Routes;

public class AddProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/products", async (HttpRequest req, IProductService service, AddProductRequest dto)
                => await service.AddProductAsync(dto))
            .WithName(nameof(AddProduct))
            .WithTags(nameof(Domain.Entities.Product));
    }
}