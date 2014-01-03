using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Aliencube.WeirdFeird.Configurations;
using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Services.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace Aliencube.WeirdFeird.Services.Tests
{
    /// <summary>
    /// This represents an entity to test wordpress feeds.
    /// </summary>
    [TestFixture]
    public class WordpressServiceTest
    {
        private IWeirdFeirdSettings _settings;
        private IProviderBase _wordpress;

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            this._settings = ConfigurationManager.GetSection("weirdFeird") as WeirdFeirdSettings;
            this._wordpress = new WordpressProvider(this._settings);
        }

        [TearDown]
        public void Dispose()
        {
            this._wordpress.Dispose();
            this._settings.Dispose();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Tests to get contents from given feed URLs.
        /// </summary>
        /// <param name="feedUrls">List of feed URLs.</param>
        [Test]
        [TestCase("http://blog.aliencube.org/tag/weird-meetup/feed",
                  "http://justinchronicles.net/tag/weird-meetup/feed")]
        public async void GetContents_GivenFeedUrls_ContentsReturned(params string[] feedUrls)
        {
            var contents = await this._wordpress.GetContentsAsync(feedUrls);

            Assert.IsTrue(contents.All(p => !String.IsNullOrWhiteSpace(p)));
        }

        #endregion
    }
}
