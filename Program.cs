using Carter;
using Microsoft.AspNetCore.Cors.Infrastructure;
using MinimalVSA.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApiConfig();
builder.Services.AddApplicationCore();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

app.UseCors(nameof(CorsPolicy));
app.UseStaticFiles();
app.MapSwagger();
app.MapCarter();
app.Run();