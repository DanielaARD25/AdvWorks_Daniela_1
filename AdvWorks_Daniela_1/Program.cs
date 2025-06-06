using Microsoft.EntityFrameworkCore;
using AdvWorks_Daniela_1.Data;
using AdvWorks_Daniela_1.Interface;
using System.Data.SqlTypes;
using AdvWorks_Daniela_1.Applications;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));

builder.Services.AddScoped<ISalesTerritoryRepository, SalesTerritoryRepository>();
builder.Services.AddScoped<ISalesTerritorySpRepository, SalesTerritorySpRepository>();
builder.Services.AddScoped<ISalesTerritoryOperation, SalesTerritoryOperation>();

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
