using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Aliencube.WeirdFeird.Configurations;
using Aliencube.WeirdFeird.Configurations.Interfaces;
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
        /// Tests to get contents from given feed URLs.
        /// </summary>
        /// <param name="feedUrls">List of feed URLs.</param>
        [Test]
        [TestCase("http://blog.aliencube.org/tag/weird-meetup/feed",
                  "http://justinchronicles.net/tag/weird-meetup/feed")]
        public async void GetContents_GivenFeedUrls_ContentsReturned(params string[] feedUrls)
        {
            var contents = new List<string>();
            using (var handler = new HttpClientHandler()
                                 {
                                     UseProxy = this._settings.Proxy.Use,
                                     Proxy = new WebProxy(this._settings.Proxy.Url)
                                 })
            using (var client = new HttpClient(handler))
            {
                foreach (var feedUrl in feedUrls)
                {
                    var content = await client.GetStringAsync(feedUrl);
                    contents.Add(content);
                }
            }

            Assert.IsTrue(contents.All(p => !String.IsNullOrWhiteSpace(p)));
        }

        #endregion
    }
}
