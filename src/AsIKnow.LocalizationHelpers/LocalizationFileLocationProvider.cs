using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using OrchardCore.Localization;
using OrchardCore.Localization.PortableObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AsIKnow.LocalizationHelpers
{
    public class LocalizationFileLocationProvider : ILocalizationFileLocationProvider
    {
        private readonly string _root;
        private readonly string _resourcesContainer;

        public LocalizationFileLocationProvider(
            IHostingEnvironment hostingEnvironment, 
            IOptions<Microsoft.Extensions.Localization.LocalizationOptions> localizationOptions)
        {
            _root = hostingEnvironment.ContentRootPath;
            _resourcesContainer = localizationOptions.Value.ResourcesPath;
        }

        public IEnumerable<string> GetLocations(string cultureName)
        {
            return Directory.GetFiles(Path.Combine(_root, _resourcesContainer), $"*{cultureName}.po");
        }
    }
}
