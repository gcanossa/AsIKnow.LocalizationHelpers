using AsIKnow.LocalizationHelpers;
using AsIKnow.XUnitExtensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    public interface EnvironmentTest
    { }
    public class EnvironmentFixture : DependencyInjectionBaseFixture<EnvironmentTest>
    {
        protected override void ConfigureServices(ServiceCollection sc)
        {
            sc.Configure<LocalizationOptions>(Configuration.GetSection("Localization"));

            sc.AddLocalization();
            sc.AddLocalizationHelpers();
        }

        public void Configure()
        {
        }
    }
}
