using Microsoft.EntityFrameworkCore;

namespace Resto.SharedKernel.Configuration;

public interface IModelConfiguration
{
    void Configure(ModelBuilder builder);
}