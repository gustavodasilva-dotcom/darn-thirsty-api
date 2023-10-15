using System.Text;
using DarnThirsty.Api.Middlewares;
using DarnThirsty.Application.Handlers;
using DarnThirsty.Application.Interfaces.Handlers;
using DarnThirsty.Core.Data;
using DarnThirsty.Core.Repositories;
using DarnThirsty.Infrastructure.Data;
using DarnThirsty.Infrastructure.Data.Seeders;
using DarnThirsty.Infrastructure.Repositories;
using DarnThirsty.Tools.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

Settings.Configuration = builder.Configuration;

builder.Services.AddScoped<IAccountHandler, AccountHandler>();
builder.Services.AddScoped<IDrinkHandler, DrinkHandler>();
builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();
builder.Services.AddScoped<IDrinkTypeRepository, DrinkTypeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Darn Thirsty API",
        Version = "v1",
        Description = "Darn Thirsty REST API"
    });

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("Jwt:SecretKey").Value!
        ))
    };
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<IMongoContext>();
        DrinkTypesSeeder.Run(dbContext);
        DrinksSeeder.Run(dbContext);
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
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Darn Thirsty API");
    });
}

app.UsePathBase("/api");

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Assets")),
    RequestPath = "/Assets"
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
