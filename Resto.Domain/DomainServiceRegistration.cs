using Microsoft.Extensions.DependencyInjection;
using Resto.Domain.Service;

namespace Resto.Domain;

public static class DomainServiceRegistration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
       services.AddScoped<ICustomerRepository, CustomerService>();
       services.AddScoped<ICabangRepository, CabangService>();
       services.AddScoped<ITableRepository, TableService>();
       services.AddScoped<IFnbRepository, FnbService>();
       services.AddScoped<IReservationRepository, ReservationService>();
       services.AddScoped<ICheckinRepository, CheckinService>();

       return services;
    }
}