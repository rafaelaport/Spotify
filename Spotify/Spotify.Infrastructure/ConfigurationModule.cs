using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Infrastructure
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<Infrastructure.AzureBlobStorage.AzureBlobStorage>();

            return services;
        }
    }
}
