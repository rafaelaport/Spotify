﻿using Microsoft.Extensions.DependencyInjection;
using Spotify.Application.Album.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Application.ConfigurationModule).Assembly);

            services.AddScoped<IBandaService, BandaService>();


            return services;
        }
    }
}
