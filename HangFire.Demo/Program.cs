using HangFire.Demo;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlServerContext(builder.Configuration);

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblyContaining<Domain.Services.AssemblyRefClass>();
});

builder.Services.AddHangFireServices(builder.Configuration);

var app = builder.Build();

app.UseHangFireServices();

app.Run();
