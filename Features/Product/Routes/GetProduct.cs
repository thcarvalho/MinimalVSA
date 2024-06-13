using Carter;
using MinimalVSA.Features.Product.Interfaces;

namespace MinimalVSA.Features.Product.Routes;

public class GetProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/products", async (IProductService service)
                => await service.GetProductsAsync())
            .WithName("GetProducts")
            .WithTags(nameof(Domain.Entities.Product));
        app.MapGet("api/products/{id:int}", async (IProductService service, int id)
                => await service.GetProductByIdAsync(id))
            .WithName("GetProductsById")
            .WithTags(nameof(Domain.Entities.Product));
    }
}