using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Aliencube.WeirdFeird.Configurations.Interfaces;

namespace Aliencube.WeirdFeird.Services
{
    /// <summary>
    /// This represents the provider entity for Wordpress feed.
    /// </summary>
    public partial class WordpressProvider : RssProvider
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the WordpressProvider class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        public WordpressProvider(IWeirdFeirdSettings settings)
            :base(settings)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the XML feed contents from given feed URL asynchronously.
        /// </summary>
        /// <param name="feedUrl">Feed URL.</param>
        /// <returns>Returns the XML feed contents from given feed URL asynchronously.</returns>
        public override async Task<XDocument> GetFeedXmlAsync(string feedUrl)
        {
            if (String.IsNullOrWhiteSpace(feedUrl))
                return null;

            XDocument xml;
            using (var handler = new HttpClientHandler() {UseProxy = this.Settings.Proxy.Use})
            {
                //  Sets the proxy server, if it is used.
                if (handler.UseProxy)
                {
                    handler.Proxy = new WebProxy(this.Settings.Proxy.Url);
                }

                using (var client = new HttpClient(handler))
                using (var stream = await client.GetStreamAsync(feedUrl))
                {
                    xml = XDocument.Load(stream);
                }
            }

            return xml;
        }

        /// <summary>
        /// Checks wether the given XML document is for RSS feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the name of the root element is "rss"; otherwise returns <c>False</c>.</returns>
        public override bool IsRss(XDocument feed)
        {
            if (feed == null || feed.Root == null)
                return false;

            return feed.Root.Name.ToString().ToLower() == "rss";
        }

        /// <summary>
        /// Checks wether the given XML document is for ATOM feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the name of the root element is "feed"; otherwise returns <c>False</c>.</returns>
        public override bool IsAtom(XDocument feed)
        {
            if (feed == null || feed.Root == null)
                return false;

            return feed.Root.Name.ToString().ToLower() == "feed";
        }

        #endregion

    }
}
