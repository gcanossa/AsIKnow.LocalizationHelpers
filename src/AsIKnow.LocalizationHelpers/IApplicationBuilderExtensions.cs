using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Localization;
using System;
using System.Globalization;
using System.Linq;

namespace AsIKnow.LocalizationHelpers
{
    public static class IApplicationBuilderExtensions
    {
        public static IServiceCollection AddLocalizationHelpers(this IServiceCollection ext, LocalizationOptions options = null)
        {
            ext = ext ?? throw new ArgumentNullException(nameof(ext));
            options = options ?? ext.BuildServiceProvider().GetRequiredService<IOptions<LocalizationOptions>>().Value;
            
            ext.AddLocalization();
            ext.AddMvc()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            ext.AddPortableObjectLocalization(opt => opt.ResourcesPath = options.LocalizationsPath);

            ext.AddSingleton<ILocalizationFileLocationProvider, LocalizationFileLocationProvider>();

            return ext;
        }

        public static IApplicationBuilder UseLocalizationHelpers(this IApplicationBuilder ext)
        {
            using (IServiceScope scope = ext.ApplicationServices.CreateScope())
            {
                LocalizationOptions options = scope.ServiceProvider.GetRequiredService<IOptions<LocalizationOptions>>().Value;

                CultureInfo[] supportedCultures = options.SupportedCultures.Select(p => new CultureInfo(p)).ToArray();

                ext.UseRequestLocalization(new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture(options.DefaultCulture),
                    SupportedCultures = supportedCultures,
                    SupportedUICultures = supportedCultures
                });
            }

            return ext;
        }
    }
}
