using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Aliencube.WeirdFeird.Configurations.Tests
{
    [TestFixture]
    public class ConfigurationTest
    {
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        #endregion

        #region Tests

        [Test]
        [TestCase("UseProxy", "true")]
        public void GetConfigValue_SendConfigKey_ReturnConfigValue(string key, string value)
        {
        }

        #endregion
    }
}
