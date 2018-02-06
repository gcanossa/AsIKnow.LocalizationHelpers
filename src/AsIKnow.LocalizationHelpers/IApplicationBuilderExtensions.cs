using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Localization;
using System;
using System.Globalization;
using System.Linq;

namespace AsIKnow.LocalizationHelpers
{
    public static class IApplicationBuilderExtensions
    {
        public static IServiceCollection AddLocalizationHelpers(this IServiceCollection ext, LocalizationOptions options)
        {
            ext = ext ?? throw new ArgumentNullException(nameof(ext));

            ext.AddSingleton<ILocalizationFileLocationProvider, LocalizationFileLocationProvider>();

            ext.AddLocalization();
            ext.AddMvc()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            ext.AddPortableObjectLocalization(opt => opt.ResourcesPath = options.LocalizationsPath);

            return ext;
        }

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
