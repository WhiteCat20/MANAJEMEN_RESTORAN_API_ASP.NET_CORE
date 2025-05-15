using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resto.UnitTest;

namespace Formulatrix.Fast.OEEMqttPublisher.UnitTest;

[CollectionDefinition("AppServiceCollection")]
public class AppServiceCollectionFixture : ICollectionFixture<AppFixture>
{
    public AppServiceCollectionFixture()
    {
        
    }
}

public class AppFixture : IDisposable
{
    public IHost Host { get; }

    public AppFixture()
    {
        Host = Helper.GetHost();
    }
    
    public void Dispose()
    {
        //
    }
    
    public T GetService<T>()
    {
        return Host.Services.CreateScope().ServiceProvider.GetRequiredService<T>();
    }
}