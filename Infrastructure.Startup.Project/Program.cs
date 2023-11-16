using Infrastructure;
using Infrastructure.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSqlServerContext(builder.Configuration);

var app = builder.Build();

await DbContextSeed.SeedDataBase(app.Services);

app.Run();
