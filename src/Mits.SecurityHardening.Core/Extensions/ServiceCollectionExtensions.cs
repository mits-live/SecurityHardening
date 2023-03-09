using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mits.SecurityHardening.Core.Models;

namespace Mits.SecurityHardening.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSecurityHardening(this IServiceCollection services, Action<AppSettingsSecurity> setupAction = null)
        {
            services.AddOptions<AppSettingsSecurity>()
                    .Configure<IConfiguration>((options, configuration) =>
                    {
                        setupAction?.Invoke(options);
                        AppSettingsSecurity.GetSection(configuration).Bind(options);
                    });
            return services;
        }
    }
}