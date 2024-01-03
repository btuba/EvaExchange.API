using EvaExchange.API.Controllers;
using EvaExchange.DataAccess.Context;
using EvaExchange.DataAccess.Repositories;
using EvaExchange.DataAccess.Repositories.Impl;
using EvaExchange.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Dependency Injections
builder.Services.AddScoped<IClientReadRepository, ClientReadRepository>();
builder.Services.AddScoped<IClientWriteRepository, ClientWriteRepository>();
builder.Services.AddScoped<IPortfolioReadRepository, PortfolioReadRepository>();
builder.Services.AddScoped<IPriceReadRepository, PriceReadRepository>();
builder.Services.AddScoped<IShareReadRepository, ShareReadRepository>();
builder.Services.AddScoped<IShareWriteRepository, ShareWriteRepository>();
builder.Services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();
builder.Services.AddScoped<ITransactionWriteRepository, TransactionWriteRepository>();

builder.Services.AddScoped<ITransactionService, TransactionService>();


// Connect to Db
builder.Services.AddDbContext<EvaDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));


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
