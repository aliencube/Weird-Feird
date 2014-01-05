using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Services.Exceptions;

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

        #region Properties

        private Regex _generator;

        /// <summary>
        /// Gets the regular expression instance to check feed generator.
        /// </summary>
        public override Regex Generator
        {
            get
            {
                if (this._generator == null)
                    this._generator = new Regex(@"^http://wordpress\.(com|org)",
                                                RegexOptions.Compiled | RegexOptions.IgnoreCase);
                return this._generator;
            }
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
                throw new ArgumentNullException("feedUrl", "No feed URL provided");

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
                throw new InvalidFeedFormatException("No feed element found");

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
                throw new InvalidFeedFormatException("No feed element found");

            return feed.Root.Name.ToString().ToLower() == "feed";
        }

        /// <summary>
        /// Checks whether the given XML document is for Wordpress feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the generator element identifies it is a Wordpress feed; otherwise returns <c>False</c>.</returns>
        public override bool IsWordpress(XDocument feed)
        {
            if (feed == null || feed.Root == null)
                throw new InvalidFeedFormatException("No feed element found");

            var channel = feed.Root.Element("channel");
            if (channel == null)
                throw new InvalidFeedFormatException("No channel element found");

            var generator = channel.Element("generator");
            if (generator == null)
                throw new InvalidFeedFormatException("No generator element found");

            var value = generator.Value;
            return this.Generator.IsMatch(value);
        }

        #endregion

    }
}
