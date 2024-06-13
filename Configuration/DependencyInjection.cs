using Carter;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MinimalVSA.Features.Category.Interfaces;
using MinimalVSA.Features.Category.Services;
using MinimalVSA.Features.Product.Interfaces;
using MinimalVSA.Features.Product.Services;
using MinimalVSA.Infrastructure.Database;

namespace MinimalVSA.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddCarter();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Default");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
    public static IServiceCollection AddWebApiConfig(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: nameof(CorsPolicy),
        builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });

        services.AddEndpointsApiExplorer();
        services.AddOpenApiDocument(c =>
        {
            c.Title = "VSA Minimal";
            c.Version = "v1";
        });


        return services;
    }

    public static WebApplication MapSwagger(this WebApplication app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi(settings => { settings.Path = "/api"; });

        return app;
    }
}