using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Aliencube.WeirdFeird.Configurations.Interfaces;
using NUnit.Framework;

namespace Aliencube.WeirdFeird.Configurations.Tests
{
    /// <summary>
    /// This represents an entity to test configuration settings.
    /// </summary>
    [TestFixture]
    public class ConfigurationTest
    {
        private IWeirdFeirdSettings _settings;

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            this._settings = ConfigurationManager.GetSection("weirdFeird") as WeirdFeirdSettings;
        }

        [TearDown]
        public void Dispose()
        {
            this._settings.Dispose();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Tests whether to use proxy server or not.
        /// </summary>
        /// <param name="expected">Expected value.</param>
        [Test]
        [TestCase(true)]
        public void TestWhetherToUseProxyOrNot(bool expected)
        {
            var proxy = this._settings.Proxy;

            Assert.AreEqual(expected, proxy.Use);
        }

        /// <summary>
        /// Tests whether to use proxy server or not.
        /// </summary>
        /// <param name="key">Key for generator.</param>
        /// <param name="keyExists">Value that specifies whether the key exists or not.</param>
        /// <param name="valueExists">Value that specifies whether the value exists or not.</param>
        [Test]
        [TestCase("Wordpress", true, true)]
        [TestCase("Blogger", false, false)]
        public void GetGenerator_SendKey_GetGeneratorRegexValue(string key, bool keyExists, bool valueExists)
        {
            var generator = this._settings
                                .Generators
                                .Cast<GeneratorElement>()
                                .FirstOrDefault(p => p.Key.ToLower() == key.ToLower());

            Assert.AreEqual(keyExists, generator != null);
            Assert.AreEqual(valueExists, generator != null && !String.IsNullOrWhiteSpace(generator.Value));
        }

        #endregion
    }
}
