using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Services.Exceptions;
using Aliencube.WeirdFeird.Services.Interfaces;
using Aliencube.WeirdFeird.ViewModels.Feeds;
using System;
using System.Collections.Generic;
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
        public bool IsRss(XDocument feed)
        {
            var root = this.GetRoot(feed);

            return root.Name.ToString().ToLower() == "rss";
        }

        /// <summary>
        /// Checks wether the given XML document is for ATOM feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the name of the root element is "feed"; otherwise returns <c>False</c>.</returns>
        public bool IsAtom(XDocument feed)
        {
            var root = this.GetRoot(feed);

            return root.Name.ToString().ToLower() == "feed";
        }

        /// <summary>
        /// Gets the root element from the feed document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement channel instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when no root element is found.</exception>
        public XElement GetRoot(XDocument feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed", "No feed provided");

            var root = feed.Root;
            if (root == null)
                throw new InvalidFeedFormatException("No root element found");

            return root;
        }

        /// <summary>
        /// Gets the value from the XElement instance.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="required">Value that specifies whether the value is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the element value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedAttributeException">Throws when no element value is set.</exception>
        public string GetElementValue(XElement element, bool required = false)
        {
            if (element == null)
                throw new ArgumentNullException("element", "No element provided");

            var value = element.Value;
            if (required && String.IsNullOrWhiteSpace(value))
                throw new RequiredFeedElementException("Value must be set");

            return value;
        }

        /// <summary>
        /// Gets the value from the XAttribute instance.
        /// </summary>
        /// <param name="attribute">Name of attribute.</param>
        /// <param name="element">XElement instance.</param>
        /// <param name="required">Value that specifies whether the value is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the attribute value.</returns>
        /// <exception cref="ArgumentNullException">Throws when attribute or element is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when no attribute is found.</exception>
        public string GetAttributeValue(string attribute, XElement element, bool required = false)
        {
            if (String.IsNullOrWhiteSpace(attribute))
                throw new ArgumentNullException("attribute", "No attribute provided");
            if (element == null)
                throw new ArgumentNullException("element", "No element provided");

            var attr = element.Attribute(attribute);
            if (attr == null)
                throw new InvalidFeedFormatException("No attribute found");

            return this.GetAttributeValue(attr, required);
        }

        /// <summary>
        /// Gets the value from the XAttribute instance.
        /// </summary>
        /// <param name="attribute">XAttribute instance.</param>
        /// <param name="required">Value that specifies whether the value is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the attribute value.</returns>
        /// <exception cref="ArgumentNullException">Throws when attribute is NULL.</exception>
        /// <exception cref="RequiredFeedAttributeException">Throws when no attribute value is set.</exception>
        public string GetAttributeValue(XAttribute attribute, bool required = false)
        {
            if (attribute == null)
                throw new ArgumentNullException("attribute", "No attribute provided");

            var value = attribute.Value;
            if (required && String.IsNullOrWhiteSpace(value))
                throw new RequiredFeedAttributeException("Value must be set");

            return value;
        }

        /// <summary>
        /// Gets the standardised feed instance from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the standardised feed instance.</returns>
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