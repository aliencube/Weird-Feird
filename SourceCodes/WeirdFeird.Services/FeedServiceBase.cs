using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Enums;
using Aliencube.WeirdFeird.Exceptions;
using Aliencube.WeirdFeird.Helpers;
using Aliencube.WeirdFeird.Services.Interfaces;
using Aliencube.WeirdFeird.ViewModels.Feeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the XML feed contents from given feed URL asynchronously.
        /// </summary>
        /// <param name="feedUrl">Feed URL.</param>
        /// <returns>Returns the XML feed contents from given feed URL asynchronously.</returns>
        /// <exception cref="NullReferenceException">Throws when the <c>FeedUrl</c> property value is NULL or empty.</exception>
        public async Task<XDocument> GetFeedXmlAsync(string feedUrl)
        {
            if (String.IsNullOrWhiteSpace(feedUrl))
                throw new ArgumentNullException("feedUrl", "No feed URL provided");

            XDocument xml;
            using (var handler = new HttpClientHandler() { UseProxy = this.Settings.Proxy.Use })
            {
                //  Sets the proxy server, if it is used.
                if (handler.UseProxy)
                    handler.Proxy = new WebProxy(this.Settings.Proxy.Url);

                using (var client = new HttpClient(handler))
                using (var stream = await client.GetStreamAsync(feedUrl))
                {
                    xml = XDocument.Load(stream);
                }
            }
            return xml;
        }

        /// <summary>
        /// Gets the root element from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement root instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when no root element is found.</exception>
        public XElement GetRootElement(XDocument feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed", "No feed provided");

            var root = feed.Root;
            if (root == null)
                throw new FeedElementNotFoundException("No root element found");

            return root;
        }

        /// <summary>
        /// Gets the generator element from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement generator instance.</returns>
        public XElement GetGeneratorElement(XDocument feed)
        {
            var root = this.GetRootElement(feed);
            var element = root.DescendantsAndSelf("generator").FirstOrDefault();
            if (element == null)
                throw new FeedElementNotFoundException("generator", "No generator element found");

            return element;
        }

        /// <summary>
        /// Gets the feed type.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the feed type.</returns>
        public FeedType GetFeedType(XDocument feed)
        {
            var feedType = FeedType.Unknown;
            try
            {
                var root = this.GetRootElement(feed);

                FeedType parsedFeedType;
                feedType = Enum.TryParse(root.Name.ToString(), true, out parsedFeedType)
                               ? parsedFeedType
                               : FeedType.Unknown;
            }
            catch { }
            return feedType;
        }

        /// <summary>
        /// Gets the feed generator.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the feed generator.</returns>
        public FeedGenerator GetFeedGenerator(XDocument feed)
        {
            var generator = FeedGenerator.Unknown;
            try
            {
                var element = this.GetGeneratorElement(feed);

                var helper = new GeneratorHelper(this.Settings);
                generator = helper.GetFeedGenerator(element);
            }
            catch { }
            return generator;
        }

        /// <summary>
        /// Gets the standardised feed instance from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the standardised feed instance.</returns>
        public abstract FeedAdapter GetFeed(XDocument feed);

        /// <summary>
        /// Gets the standard FeedAdapter instance from the feed instance.
        /// </summary>
        /// <typeparam name="T">Feed type.</typeparam>
        /// <param name="feed">Feed instance.</param>
        /// <returns>Returns the standard FeedAdapter instance.</returns>
        public abstract FeedAdapter GetFeedAdapter<T>(T feed);

        /// <summary>
        /// Gets the list of standard Feed Entry instances from the list of the feed entry instances.
        /// </summary>
        /// <typeparam name="T">Feed item type.</typeparam>
        /// <param name="entries">List of feed item instances.</param>
        /// <returns>Returns the list of standard Feed Entry instances.</returns>
        public abstract IList<FeedEntryAdapter> GetFeedEntryAdapters<T>(IList<T> entries);

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