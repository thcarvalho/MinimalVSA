using Carter;
using MinimalVSA.Features.Category.DTOs;
using MinimalVSA.Features.Category.Interfaces;

namespace MinimalVSA.Features.Category.Routes;

public class AddCategory : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/categories", async (HttpRequest req, ICategoryService service, AddCategoryRequest dto)
                => await service.AddCategoryAsync(dto))
            .WithName(nameof(AddCategory))
            .WithTags(nameof(Domain.Entities.Category));;
    }
}