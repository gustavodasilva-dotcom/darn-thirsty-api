using DarnThirsty.Application.Handlers;
using DarnThirsty.Application.Interfaces.Handlers;
using DarnThirsty.Core.Data;
using DarnThirsty.Core.Repositories;
using DarnThirsty.Infrastructure.Data;
using DarnThirsty.Infrastructure.Repositories;
using DarnThirsty.Tools.Configuration;

var builder = WebApplication.CreateBuilder(args);

Settings.Configuration = builder.Configuration;

builder.Services.AddScoped<IAccountHandler, AccountHandler>();
builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
