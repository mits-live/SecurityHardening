namespace Mits.SecurityHardening.Core.Internal
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Options;
    using Models;

    public sealed class SecurityHardeningMiddleware
    {
        #region Middleware parameters

        private readonly RequestDelegate _next;

        private readonly AppSettingsSecurity _settings;

        private readonly ILoggerFactory _loggerFactory;

        #endregion

        public SecurityHardeningMiddleware(RequestDelegate next, IOptions<AppSettingsSecurity> options, ILoggerFactory loggerFactory)
        {
            _next = next;
            _settings = options.Value;
            _loggerFactory = loggerFactory;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.AddSecurityHardening(_settings, _loggerFactory);
            return _next(context);
        }
    }
}
