using Microsoft.EntityFrameworkCore;
using ServiceRequestApp.Api.Endpoints;
using ServiceRequestApp.Application.Interfaces;
using ServiceRequestApp.Infrastructure.Data;
using ServiceRequestApp.Infrastructure.Repositories;
using ServiceRequestApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

// DbContext — Scoped by default via AddDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseSqlServer(
 builder.Configuration
 .GetConnectionString("DefaultConnection"))
);

// DI registrations — all Scoped
builder.Services.AddScoped<IPokemonRepository,
                          PokemonRepository>();
builder.Services.AddScoped<IPokemonRepository,
                          PokemonRepository>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapPokemonEndpoints();

app.Run();