using Carter;
using MinimalVSA.Features.Product.Interfaces;

namespace MinimalVSA.Features.Product.Routes;

public class DeleteProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/products/{id:int}", async (HttpRequest req, IProductService service, int id)
                => await service.DeleteProductAsync(id))
            .WithName(nameof(DeleteProduct))
            .WithTags(nameof(Domain.Entities.Product));
    }

}