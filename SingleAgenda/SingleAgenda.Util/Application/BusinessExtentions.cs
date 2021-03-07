using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SingleAgenda.Application.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Util.Application
{
    public static class BusinessExtentions
    {

        public static IServiceCollection AddBusiness(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ContactBusiness>();

            return services;
        }
    }
}
