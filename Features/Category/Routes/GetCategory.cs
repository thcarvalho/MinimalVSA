using Carter;
using MinimalVSA.Features.Category.Interfaces;

namespace MinimalVSA.Features.Category.Routes;

public class GetCategory : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/categories", async (ICategoryService service)
                => await service.GetCategoriesAsync())
            .WithName("GetCategories")
            .WithTags(nameof(Domain.Entities.Category));
        app.MapGet("api/categories/{id:int}", async (ICategoryService service, int id)
                => await service.GetCategoryByIdAsync(id))
            .WithName("GetCategoriesById")
            .WithTags(nameof(Domain.Entities.Category));
    }
}