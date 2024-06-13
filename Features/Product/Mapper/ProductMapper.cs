using MinimalVSA.Features.Product.DTOs;

namespace MinimalVSA.Features.Product.Mapper;

public static class ProductMapper
{
    public static Domain.Entities.Product MapToEntity(this AddProductRequest request)
        => new()
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

    public static GetProductResponse MapToDto(this Domain.Entities.Product? entity)
        => entity is null   
                ? null
                : new(entity.Id, entity.Name, entity.Price, entity.CategoryId, entity.Category.Name);

    public static IEnumerable<GetProductResponse> MapToDto(this IEnumerable<Domain.Entities.Product> entities)
        => entities.Select(MapToDto);
}