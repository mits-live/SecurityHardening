namespace Mits.SecurityHardening.Core.Models
{
    using Microsoft.Extensions.Configuration;

    public class AppSettingsSecurity
    {
        #region Declarations

        public const string ConfigurationSectionName = "AppSecurity";

        #endregion

        #region Settings properties

        public string ReferrerPolicy { get; set; }

        public string ContentTypeOptions { get; set; }

        public string FrameOptions { get; set; }

        public string PermittedCrossDomainPolicies { get; set; }

        public string XssProtection { get; set; }

        public string CertificateTransparency { get; set; }

        public string FeaturePolicy { get; set; }

        public string PermissionsPolicy { get; set; }

        public string ContentSecurityPolicy { get; set; }

        #endregion

        #region Loading and Instantiation

        public static IConfigurationSection GetSection(IConfiguration configuration)
            => configuration.GetSection(ConfigurationSectionName);

        public static AppSettingsSecurity Load(IConfiguration configuration)
            => configuration.GetSection(ConfigurationSectionName).Get<AppSettingsSecurity>();

        #endregion
    }
}
