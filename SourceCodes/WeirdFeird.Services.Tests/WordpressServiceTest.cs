using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
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
        /// Tests to get XML contents from given feed URLs.
        /// </summary>
        /// <param name="feedUrls">List of feed URLs.</param>
        [Test]
        [TestCase("http://blog.aliencube.org/tag/weird-meetup/feed",
                  "http://justinchronicles.net/tag/weird-meetup/feed")]
        public async void GetXmlDocs_GivenFeedUrls_XmlDocsReturned(params string[] feedUrls)
        {
            var feeds = new List<XDocument>();
            foreach (var feedUrl in feedUrls)
            {
                var feed = await this._wordpress.GetFeedXmlAsync(feedUrl);
                feeds.Add(feed);
            }

            Assert.IsTrue(feeds.All(p => p.Root != null));
        }

        /// <summary>
        /// Tests to check the name of the root element is "rss".
        /// </summary>
        /// <param name="feedUrl">Feed URL.</param>
        /// <param name="expected">Expected value that specifies whether it is RSS feed or not.</param>
        [Test]
        [TestCase("http://blog.aliencube.org/tag/weird-meetup/feed", true)]
        public async void CheckRssFeed_GivenFeedUrls_RssConfirmed(string feedUrl, bool expected)
        {
            var feed = await this._wordpress.GetFeedXmlAsync(feedUrl);
            var isRss = this._wordpress.IsRss(feed);

            Assert.AreEqual(expected, isRss);
        }

        #endregion
    }
}
