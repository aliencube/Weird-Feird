using System;
using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Services.Exceptions;
using Aliencube.WeirdFeird.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Services
{
    /// <summary>
    /// This represents the provider entity for Wordpress feed.
    /// </summary>
    public partial class WordpressRssService : RssFeedService, IWordpressRssService
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the WordpressProvider class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        public WordpressRssService(IWeirdFeirdSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Properties

        private IDictionary<string, XNamespace> _namespaces;

        /// <summary>
        /// Gets the list of namespaces used in the feed.
        /// </summary>
        public override IDictionary<string, XNamespace> Namespaces
        {
            get
            {
                if (this._namespaces == null || !this._namespaces.Any())
                {
                    this._namespaces = new Dictionary<string, XNamespace>()
                                       {
                                           {"content", XNamespace.Get("http://purl.org/rss/1.0/modules/content/")},
                                           {"wfw", XNamespace.Get("http://wellformedweb.org/CommentAPI/")},
                                           {"dc", XNamespace.Get("http://purl.org/dc/elements/1.1/")},
                                           {"atom", XNamespace.Get("http://www.w3.org/2005/Atom")},
                                           {"sy", XNamespace.Get("http://purl.org/rss/1.0/modules/syndication/")},
                                           {"slash", XNamespace.Get("http://purl.org/rss/1.0/modules/slash/")},
                                       };
                }
                return this._namespaces;
            }
        }

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

        #endregion Properties

        #region Methods

        /// <summary>
        /// Checks whether the given XML document is for Wordpress feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the generator element identifies it is a Wordpress feed; otherwise returns <c>False</c>.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when no root element, channel element or generator element is found.</exception>
        public override bool IsWordpress(XDocument feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed", "No feed provided");

            if (feed.Root == null)
                throw new InvalidFeedFormatException("No root element found");

            var channel = feed.Root.Element("channel");
            if (channel == null)
                throw new InvalidFeedFormatException("No channel element found");

            var generator = channel.Element("generator");
            if (generator == null)
                throw new InvalidFeedFormatException("No generator element found");

            var value = generator.Value;
            return this.Generator.IsMatch(value);
        }

        #endregion Methods
    }
}