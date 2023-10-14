using DarnThirsty.Api.Middlewares;
using DarnThirsty.Application.Handlers;
using DarnThirsty.Application.Interfaces.Handlers;
using DarnThirsty.Core.Data;
using DarnThirsty.Core.Repositories;
using DarnThirsty.Infrastructure.Data;
using DarnThirsty.Infrastructure.Data.Seeders;
using DarnThirsty.Infrastructure.Repositories;
using DarnThirsty.Tools.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

Settings.Configuration = builder.Configuration;

builder.Services.AddScoped<IAccountHandler, AccountHandler>();
builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Darn Thirsty API",
        Version = "v1",
        Description = "Darn Thirsty REST API"
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<IMongoContext>();
        DrinkTypesSeeder.Run(dbContext.DrinkTypes);
    }
    catch (Exception e)
    {
        Console.WriteLine(string.Format("Error while seeding data: {0}", e.Message));
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Darn Thirsty API");
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
