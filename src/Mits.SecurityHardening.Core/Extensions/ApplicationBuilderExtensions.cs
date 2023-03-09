namespace Mits.SecurityHardening.Core.Extensions
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Internal;
    using Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSecurityHardening(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var services = app.ApplicationServices;
            var options = services.GetRequiredService<IOptions<AppSettingsSecurity>>();
            return app.UseMiddleware<SecurityHardeningMiddleware>(options);
        }
    }
    
}
