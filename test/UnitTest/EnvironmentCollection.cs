using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest
{
    [CollectionDefinition("Environment collection")]
    public class EnvironmentCollection : ICollectionFixture<EnvironmentFixture>
    {
    }
}
