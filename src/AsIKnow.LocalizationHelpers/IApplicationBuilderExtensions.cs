using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System;
using System.Globalization;
using System.Linq;

namespace AsIKnow.LocalizationHelpers
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseLocalizationHelpers(this IApplicationBuilder ext, LocalizationOptions options)
        {
            CultureInfo[] supportedCultures = options.SupportedCultures.Select(p => new CultureInfo(p)).ToArray();

            ext.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(options.DefaultCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            return ext;
        }
    }
}
