# Security Hardening for Microsoft .NET Core, .NET 5/6/7 Web applications.

## Automatically includes the following HTTP Response Headers in the HTTP Responses of the web application

X-Content-Type-Options  
X-Frame-Options  
referrer-policy  
X-Permitted-Cross-Domain-Policies  
X-XSS-Protection  
Expect-CT  
Feature-Policy  
Content-Security-Policy  

## Removes the following HTTP Response Header from the HTTP Response of the web application
X-Powered-By  
X-AspNetMvc-Version  

## Example configuration

```json
"AppSecurity": {
    "ReferrerPolicy": "strict-origin-when-cross-origin",
    "ContentTypeOptions": "nosniff",
    "FrameOptions": "DENY",
    "PermittedCrossDomainPolicies": "none",
    "XssProtection": "1; mode=block",
    "CertificateTransparency": "max-age=0, enforce, report-uri=https://example.report-uri.com/r/d/ct/enforce",
    "FeaturePolicy": "accelerometer 'none'; camera 'none'; geolocation 'none'; gyroscope 'none'; magnetometer 'none'; microphone 'none'; payment 'none'; usb 'none'",
    "ContentSecurityPolicy": "default-src 'none'; base-uri 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval' https://*.some-page.com https://*.tv-page.tv https://*.tools.net ; style-src 'self' 'unsafe-inline' https://*.cloudflare.com; img-src 'self'  data: https://*.data-page.net; font-src 'self' data:; connect-src 'self' https://dc.services.visualstudio.com; media-src 'self' data: https://*.data-page.tv; frame-src 'self' https://*.tv-page.tv; frame-ancestors 'self';"
  }
```