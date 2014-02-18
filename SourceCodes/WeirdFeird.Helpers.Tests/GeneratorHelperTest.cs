using Aliencube.WeirdFeird.Configurations;
using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Enums;
using Aliencube.WeirdFeird.Helpers.Interfaces;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Helpers.Tests
{
    /// <summary>
    /// This represents an entity to test generator helper.
    /// </summary>
    [TestFixture]
    public class GeneratorHelperTest
    {
        private IWeirdFeirdSettings _settings;
        private IGeneratorHelper _helper;

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            this._settings = ConfigurationManager.GetSection("weirdFeird") as WeirdFeirdSettings;
            this._helper = new GeneratorHelper(this._settings);
        }

        [TearDown]
        public void Dispose()
        {
            this._helper.Dispose();
            this._settings.Dispose();
        }

        #endregion SetUp / TearDown

        #region Tests

        /// <summary>
        /// Tests to get the list of generator patterns from the config file.
        /// </summary>
        [Test]
        public void GetGeneratorPatterns()
        {
            Assert.IsTrue(this._helper.GeneratorPatterns.Any());
        }

        /// <summary>
        /// Tests the generator element whether it contains expected generator pattern or not.
        /// </summary>
        /// <param name="key">Expected generator name.</param>
        /// <param name="value">Generator element value.</param>
        /// <param name="expected">Expected value.</param>
        [Test]
        [TestCase("Wordpress", "http://wordpress.org/?v=3.8", true)]
        [TestCase("Unknown", "Blogger", true)]
        public void GetGenerator_SendXElement_ReturnFeedGenerator(string key, string value, bool expected)
        {
            var element = new XElement("generator", value);
            var generator = this._helper.GetFeedGenerator(element);

            FeedGenerator parsedGenerator;
            var expectedGenerator = Enum.TryParse(key, true, out parsedGenerator)
                                        ? parsedGenerator
                                        : FeedGenerator.Unknown;

            Assert.AreEqual(expected, generator == expectedGenerator);
        }

        #endregion Tests
    }
}