using MANAJEMEN_RESTORAN_API.Data;
using MANAJEMEN_RESTORAN_API.Mappings;
using MANAJEMEN_RESTORAN_API.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dependency injection 
builder.Services.AddDbContext<RestoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestoConnectionString"))
);

builder.Services.AddScoped<ICustomerRepository, SQLCustomerRepository>();
builder.Services.AddScoped<ICabangRepository, SQLCabangRepository>();
builder.Services.AddScoped<ITableRepository, SQLTableRepository>();
builder.Services.AddScoped<IFnbRepository, SQLFnbRepository>();
builder.Services.AddScoped<IReservationRepository, SQLReservationRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles)); // inject the automapper


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
