using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Services.Exceptions;
using Aliencube.WeirdFeird.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Aliencube.WeirdFeird.ViewModels.Feeds;

namespace Aliencube.WeirdFeird.Services
{
    /// <summary>
    /// This represents the base provider entity.
    /// This must be inherited.
    /// </summary>
    public abstract class FeedServiceBase : IFeedServiceBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the ProviderBase class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        protected FeedServiceBase(IWeirdFeirdSettings settings)
        {
            this.Settings = settings;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the configuration settings instance for Weird-Feird.
        /// </summary>
        protected IWeirdFeirdSettings Settings { get; private set; }

        /// <summary>
        /// Gets the list of namespaces used in the feed.
        /// </summary>
        public abstract IDictionary<string, XNamespace> Namespaces { get; }

        /// <summary>
        /// Gets the regular expression instance to check feed generator.
        /// </summary>
        public abstract Regex Generator { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the XML feed contents from given feed URL asynchronously.
        /// </summary>
        /// <param name="feedUrl">Feed URL.</param>
        /// <returns>Returns the XML feed contents from given feed URL asynchronously.</returns>
        /// <exception cref="ArgumentNullException">Throws when <c>feedUrl</c> is NULL or whitespace.</exception>
        public async Task<XDocument> GetFeedXmlAsync(string feedUrl)
        {
            if (String.IsNullOrWhiteSpace(feedUrl))
                throw new ArgumentNullException("feedUrl", "No feed URL provided");

            XDocument xml;
            using (var handler = new HttpClientHandler() { UseProxy = this.Settings.Proxy.Use })
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
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when no root element is found.</exception>
        public bool IsRss(XDocument feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed", "No feed provided");

            if (feed.Root == null)
                throw new InvalidFeedFormatException("No root element found");

            return feed.Root.Name.ToString().ToLower() == "rss";
        }

        /// <summary>
        /// Checks wether the given XML document is for ATOM feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the name of the root element is "feed"; otherwise returns <c>False</c>.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when no root element is found.</exception>
        public bool IsAtom(XDocument feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed", "No feed provided");

            if (feed.Root == null)
                throw new InvalidFeedFormatException("No root element found");

            return feed.Root.Name.ToString().ToLower() == "feed";
        }

        /// <summary>
        /// Gets the standardised feed instance from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the standardised feed instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        public abstract FeedAdapter GetFeed(XDocument feed);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
        }

        #endregion Methods
    }
}