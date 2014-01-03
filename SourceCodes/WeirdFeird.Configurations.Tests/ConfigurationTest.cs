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
            Assert.AreEqual(expected, this._settings.Proxy.Use);
        }

        #endregion
    }
}
