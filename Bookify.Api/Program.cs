using Bookify.Api.Extensions;
using Bookify.Application;
using Bookify.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on port 8080
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(8080); // This makes the container listen on port 8080
//});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
    // app.SeedData();
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
