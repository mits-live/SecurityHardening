namespace Mits.SecurityHardening.Core.Internal
{
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Models;

internal static class HttpResponseSecurityHelper
{
    internal static void AddSecurityHardening(this HttpResponse response, AppSettingsSecurity settings, ILoggerFactory loggerFactory)
    {
        var logger = loggerFactory?.CreateLogger(nameof(AddSecurityHardening));
        if (response.HasStarted || response.Headers.IsReadOnly)
        {
            logger?.LogWarning("Response to '{ResponseUrl}' has already been started, the Headers collection will remain not changed", response.Headers.GetLocation().ToString());
            return;
        }

        var headersModified = false;

        response.Headers.Remove(XHeaderNames.XPoweredBy);
        response.Headers.Remove(XHeaderNames.AspNetMvcVersion);

        if (!string.IsNullOrEmpty(settings.ReferrerPolicy))
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referrer-Policy
            response.Headers.Add(XHeaderNames.ReferrerPolicy, new StringValues(settings.ReferrerPolicy));
            headersModified = true;
        }

        if (!string.IsNullOrEmpty(settings.ContentTypeOptions))
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options
            response.Headers.Add(XHeaderNames.XContentTypeOptions, new StringValues(settings.ContentTypeOptions));
            headersModified = true;
        }

        if (!string.IsNullOrEmpty(settings.FrameOptions))
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options
            response.Headers.Add(XHeaderNames.XFrameOptions, new StringValues(settings.FrameOptions));
            headersModified = true;
        }

        if (!string.IsNullOrEmpty(settings.PermittedCrossDomainPolicies))
        {
            // https://security.stackexchange.com/questions/166024/does-the-x-permitted-cross-domain-policies-header-have-any-benefit-for-my-websit
            response.Headers.Add(XHeaderNames.PermittedCrossDomainPolicies, new StringValues(settings.PermittedCrossDomainPolicies));
            headersModified = true;
        }

        if (!string.IsNullOrEmpty(settings.XssProtection))
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection
            response.Headers.Add(XHeaderNames.XxssProtection, new StringValues(settings.XssProtection));
            headersModified = true;
        }

        if (!string.IsNullOrEmpty(settings.CertificateTransparency))
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Expect-CT
            // You can use https://report-uri.com/ to get notified when a misissued certificate is detected
            response.Headers.Add(XHeaderNames.CertificateTransparency, new StringValues(settings.CertificateTransparency));
            headersModified = true;
        }

        if (!string.IsNullOrEmpty(settings.FeaturePolicy))
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Feature-Policy
            // https://github.com/w3c/webappsec-feature-policy/blob/master/features.md
            // https://developers.google.com/web/updates/2018/06/feature-policy
            response.Headers.Add(XHeaderNames.FeaturePolicy, new StringValues(settings.FeaturePolicy));
            headersModified = true;
        }

        if (!string.IsNullOrEmpty(settings.ContentSecurityPolicy))
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy
            response.Headers.Add(XHeaderNames.ContentSecurityPolicy, new StringValues(settings.ContentSecurityPolicy));
            headersModified = true;
        }

        if (headersModified)
        {
            logger?.LogInformation("Response headers to '{ResponseUrl}' have been modified", response.Headers.GetLocation().ToString());
        }
    }
}}
