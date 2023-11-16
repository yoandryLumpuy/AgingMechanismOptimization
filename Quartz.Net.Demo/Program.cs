using Infrastructure;
using Quartz.Net.Demo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlServerContext(builder.Configuration);

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblyContaining<Domain.Services.AssemblyRefClass>();
});

builder.Services.AddQuartzServices(builder.Configuration);

var app = builder.Build();

app.Run();
