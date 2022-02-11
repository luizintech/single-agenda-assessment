using Microsoft.Extensions.DependencyInjection;
using SingleAgenda.EFPersistence.Repositories;

namespace SingleAgenda.Infra.IoC.Application
{
    public static class RepositoriesScopeExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<PersonRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<AddressRepository>();

            return services;
        }
    }
}
