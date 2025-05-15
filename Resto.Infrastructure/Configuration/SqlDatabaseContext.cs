using Microsoft.EntityFrameworkCore;
using Resto.Domain;

namespace Resto.Infrastructure.Configuration;

internal class SqlDatabaseContext : DatabaseContext
{
    public SqlDatabaseContext(DbContextOptions options) : base(options, new ModelConfiguration())
    {
    }
}