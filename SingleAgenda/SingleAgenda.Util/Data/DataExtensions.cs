using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Util.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDbContext<TContext>(this IServiceCollection services,
            IConfiguration configuration, string connectionName = "DefaultConnection")
                where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
            {
                options.ConfigureWarnings(w => w.Default(WarningBehavior.Throw));
                options.ConfigureWarnings(w => w.Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
                options.ConfigureWarnings(w => w.Ignore(CoreEventId.FirstWithoutOrderByAndFilterWarning));
                options.ConfigureWarnings(w => w.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));

                options.UseSqlServer(configuration.GetConnectionString(connectionName), sqlOptions =>
                {
                    sqlOptions.CommandTimeout(60);
                });
            });

            return services;
        }
    }
}
