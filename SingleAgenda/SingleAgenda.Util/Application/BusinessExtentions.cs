using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SingleAgenda.Application.Contact;
using SingleAgenda.Application.Dashboard;
using SingleAgenda.Application.UsersAndRoles;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Infra.IoC.Application
{
    public static class BusinessExtentions
    {

        public static IServiceCollection AddBusiness(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ContactBusiness>();
            services.AddScoped<AuthBusiness>();
            services.AddScoped<DashboardBusiness>();

            return services;
        }
    }
}
