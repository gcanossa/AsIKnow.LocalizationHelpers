using AsIKnow.LocalizationHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace UnitTest
{
    [TestCaseOrderer(AsIKnow.XUnitExtensions.Constants.PriorityOrdererTypeName, AsIKnow.XUnitExtensions.Constants.PriorityOrdererTypeAssemblyName)]
    [Collection("Environment collection")]
    public class UnitTest1
    {
        protected EnvironmentFixture Fixture { get; set; }

        public UnitTest1(EnvironmentFixture fixture)
        {
            Fixture = fixture;
        }

        [Trait("Category", "Matcher")]
        [Fact(DisplayName = nameof(GetLocations))]
        public void GetLocations()
        {
            Mock<IHostingEnvironment> env = new Mock<IHostingEnvironment>();
            env.Setup(p => p.EnvironmentName).Returns("Staging");
            env.Setup(p => p.ContentRootPath).Returns(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            LocalizationFileLocationProvider provider = new LocalizationFileLocationProvider(
                env.Object, 
                new OptionsWrapper<Microsoft.Extensions.Localization.LocalizationOptions>(new Microsoft.Extensions.Localization.LocalizationOptions()
                {
                    ResourcesPath = "testdata"
                }));

            Assert.Equal(new string[] {"it-IT.po", "it.po","test.it.po" }, provider.GetLocations("it").Select(p => p.Name).ToArray());
            //Assert.Equal(new string[] { Path.Combine(".", "testdata", "it-IT.po"), Path.Combine(".","testdata","it.po"), Path.Combine(".","testdata", "test.it.po") }, provider.GetLocations("it").Select(p=>p.Name));
        }
    }
}
