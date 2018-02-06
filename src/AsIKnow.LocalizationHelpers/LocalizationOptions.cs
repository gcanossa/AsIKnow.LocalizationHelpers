using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AsIKnow.LocalizationHelpers
{
    public class LocalizationOptions
    {
        public string LocalizationsPath { get; set; } = "Localizations";
        public string DefaultCulture { get; set; }
        public string[] SupportedCultures { get; set; }
    }
}
