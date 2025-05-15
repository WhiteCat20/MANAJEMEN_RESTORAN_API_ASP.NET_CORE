using Microsoft.EntityFrameworkCore;
using Resto.Domain;
using Resto.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connectionString = builder.Configuration.GetConnectionString("PgSqlConnectionString");
// dependency injection 


builder.Services.AddInfrastructure(connectionString!);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var sqlDatabaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    sqlDatabaseContext.Database.Migrate();
}

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
