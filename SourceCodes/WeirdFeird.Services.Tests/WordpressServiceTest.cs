using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using NUnit.Framework;
using NSubstitute;

namespace Aliencube.WeirdFeird.Services.Tests
{
    [TestFixture]
    public class WordpressServiceTest
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
        [TestCase("http://blog.aliencube.org/tag/weird-meetup/feed", "http://justinchronicles.net/tag/weird-meetup/feed")]
        async public void FetchItems_GivenFeedUrls_ItemsReturned(params string[] feedUrls)
        {
            var contents = new List<string>();
            using (var client = new HttpClient())
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
