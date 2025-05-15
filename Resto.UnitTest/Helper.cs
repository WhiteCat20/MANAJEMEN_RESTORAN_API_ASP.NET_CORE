using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Resto.Domain;

namespace Resto.UnitTest;

public static class Helper
{
    public static IHost GetHost()
    {
        var builder = WebApplication.CreateBuilder();
        var logger = new NullLoggerFactory().CreateLogger("test");
        builder.Services.AddSingleton(logger);
        
        builder.Services.AddDomain();
        
        // builder.Services.AddDbContextPool<DatabaseContext, TestDatabaseContext>(options =>
        // {
        //     options.UseInMemoryDatabase(Guid.NewGuid().ToString());
        // });
        
        var host = builder.Build();
        
        return host;
    }
}

// public class TestDatabaseContext : DatabaseContext
// {
//     public TestDatabaseContext(DbContextOptions options) : base(options, new TestModelConfiguration())
//     {
//     }
// }