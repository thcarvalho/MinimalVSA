using Carter;
using MinimalVSA.Features.Product.DTOs;
using MinimalVSA.Features.Product.Interfaces;

namespace MinimalVSA.Features.Product.Routes;

public class UpdateProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/products", async (HttpRequest req, IProductService service, UpdateProductRequest dto)
                => await service.UpdateProductAsync(dto))
            .WithName(nameof(UpdateProduct))
            .WithTags(nameof(Domain.Entities.Product));
    }
}