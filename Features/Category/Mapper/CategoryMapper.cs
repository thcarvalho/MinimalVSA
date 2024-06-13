using MinimalVSA.Features.Category.DTOs;

namespace MinimalVSA.Features.Category.Mapper;

public static class CategoryMapper
{
    public static GetCategoryResponse MapToDto(this Domain.Entities.Category? entity)
        => entity is null 
            ? null
            : new(entity.Id, entity.Name, entity.Description);

    public static IEnumerable<GetCategoryResponse> MapToDto(this IEnumerable<Domain.Entities.Category> entity)
        => entity.Select(MapToDto);

    public static Domain.Entities.Category MapToEntity(this AddCategoryRequest request)
        => new ()
        {
            Name = request.Name,
            Description = request.Description
        };
}