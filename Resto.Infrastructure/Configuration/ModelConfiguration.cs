using Microsoft.EntityFrameworkCore;
using Resto.SharedKernel.Configuration;

namespace Resto.Infrastructure.Configuration;

public class ModelConfiguration : IModelConfiguration
{
    public void Configure(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ModelConfiguration).Assembly);
    }
}