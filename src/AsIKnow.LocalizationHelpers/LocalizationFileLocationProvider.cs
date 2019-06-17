using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using OrchardCore.Localization;
using OrchardCore.Localization.PortableObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AsIKnow.LocalizationHelpers
{
    public class LocalizationFileLocationProvider : ILocalizationFileLocationProvider
    {
        private readonly string _root;
        private readonly string _resourcesContainer;

        private IFileProvider _provider;

        public LocalizationFileLocationProvider(
            IHostingEnvironment hostingEnvironment, 
            IOptions<Microsoft.Extensions.Localization.LocalizationOptions> localizationOptions)
        {
            _root = hostingEnvironment.ContentRootPath;
            _resourcesContainer = localizationOptions.Value.ResourcesPath;

            _provider = new PhysicalFileProvider(Path.Combine(_root, _resourcesContainer));
        }

        public IEnumerable<IFileInfo> GetLocations(string cultureName)
        {
            if (string.IsNullOrEmpty(cultureName?.Trim()))
                return new List<IFileInfo>();
            else
                return _provider.GetDirectoryContents("").Where(p=>p.Name.EndsWith($"{cultureName}.po"));
        }
    }
}
