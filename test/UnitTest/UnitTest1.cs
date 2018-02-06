using AsIKnow.LocalizationHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.IO;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Trait("Category", "Matcher")]
        [Fact(DisplayName = nameof(GetLocations))]
        public void GetLocations()
        {
            Mock<IHostingEnvironment> env = new Mock<IHostingEnvironment>();
            env.Setup(p => p.EnvironmentName).Returns("Staging");
            env.Setup(p => p.ContentRootPath).Returns(".");

            LocalizationFileLocationProvider provider = new LocalizationFileLocationProvider(
                env.Object, 
                new OptionsWrapper<Microsoft.Extensions.Localization.LocalizationOptions>(new Microsoft.Extensions.Localization.LocalizationOptions()
                {
                    ResourcesPath = "testdata"
                }));

            Assert.Equal(new string[] { Path.Combine(".","testdata","it.po"), Path.Combine(".","testdata", "test.it.po") }, provider.GetLocations("it"));
        }
    }
}
