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
            var docs = new List<XDocument>();
            foreach (var feedUrl in feedUrls)
            {
                var doc = await this._wordpress.GetFeedXmlAsync(feedUrl);
                docs.Add(doc);
            }

            Assert.IsTrue(docs.All(p => p.Root != null));
        }

        /// <summary>
        /// Tests to check the name of the root element is "rss".
        /// </summary>
        /// <param name="feedUrl">Feed URL.</param>
        /// <param name="rootElementName">Name of the root element.</param>
        [Test]
        [TestCase("http://blog.aliencube.org/tag/weird-meetup/feed", "rss")]
        public async void CheckRssFeed_GivenFeedUrls_RssConfirmed(string feedUrl, string rootElementName)
        {
            var doc = await this._wordpress.GetFeedXmlAsync(feedUrl);

            if (doc.Root == null)
                Assert.Fail("Root element is missing");

            Assert.AreEqual(rootElementName, doc.Root.Name.ToString());
        }

        #endregion
    }
}
