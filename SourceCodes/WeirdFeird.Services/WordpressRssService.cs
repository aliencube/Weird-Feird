using System;
using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Services.Exceptions;
using Aliencube.WeirdFeird.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Aliencube.WeirdFeird.ViewModels.Enums;
using Aliencube.WeirdFeird.ViewModels.Feeds;
using Aliencube.WeirdFeird.ViewModels.Feeds.Atom;
using Aliencube.WeirdFeird.ViewModels.Feeds.Extensions;
using Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress;
using Category = Aliencube.WeirdFeird.ViewModels.Feeds.Rss.Category;
using Content = Aliencube.WeirdFeird.ViewModels.Feeds.Atom.Content;
using Guid = Aliencube.WeirdFeird.ViewModels.Feeds.Rss.Guid;

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

        /// <summary>
        /// Gets the standardised feed instance from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the standardised feed instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when no root element or channel element is found.</exception>
        public override FeedAdapter GetFeed(XDocument feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed", "No feed provided");

            if (feed.Root == null)
                throw new InvalidFeedFormatException("No root element found");

            var channel = feed.Root.Element("channel");
            if (channel == null)
                throw new InvalidFeedFormatException("No channel element found");

            var content = this.Namespaces["content"];
            var wfw = this.Namespaces["wfw"];
            var dc = this.Namespaces["dc"];
            var atom = this.Namespaces["atom"];
            var sy = this.Namespaces["sy"];
            var slash = this.Namespaces["slash"];

            var wp = new WordpressRss()
                     {
                         Channel = new WordpressChannel()
                                   {
                                       Title = channel.Element("title").Value,
                                       AtomLink = new Link()
                                                  {
                                                      Href = channel.Element(atom + "link").Attribute("href").Value,
                                                      Rel = channel.Element(atom + "link").Attribute("rel").Value,
                                                      Type = channel.Element(atom + "link").Attribute("type").Value,
                                                  },
                                       Link = channel.Element("link").Value,
                                       Description = channel.Element("description").Value,
                                       LastBuildDate = Convert.ToDateTime(channel.Element("lastBuildDate").Value),
                                       Language = channel.Element("language").Value,
                                       Syndication = new Syndication()
                                                     {
                                                         UpdatePeriod = (UpdatePeriod)Enum.Parse(typeof(UpdatePeriod), channel.Element(sy + "updatePeriod").Value, true),
                                                         UpdateFrequency = Convert.ToInt32(channel.Element(sy + "updateFrequency").Value)
                                                     },
                                       Generator = channel.Element("generator").Value,
                                       Items = channel.Elements("item")
                                                      .Select(p => new WordpressItem()
                                                                   {
                                                                       Title = p.Element("title").Value,
                                                                       Link = p.Element("link").Value,
                                                                       Comments = p.Element("comments").Value,
                                                                       PubDate = Convert.ToDateTime(p.Element("pubDate").Value),
                                                                       DublinCore = new DublinCore() { Creator = p.Element(dc + "creator").Value },
                                                                       Categories = p.Elements("category")
                                                                                     .Select(q => new Category()
                                                                                                  {
                                                                                                      Domain = q.Attribute("domain") != null ? q.Attribute("domain").Value : null,
                                                                                                      Value = q.Value
                                                                                                  })
                                                                                     .ToList(),
                                                                       Guid = new Guid()
                                                                              {
                                                                                  IsPermaLink = Convert.ToBoolean(p.Element("guid")
                                                                                                                   .Attribute("isPermaLink")
                                                                                                                   .Value),
                                                                                  Value = p.Element("guid").Value
                                                                              },
                                                                       Description = p.Element("description").Value,
                                                                       Content = new ViewModels.Feeds.Extensions.Content() { Encoded = p.Element(content + "encoded").Value },
                                                                       WellFormedWeb = new WellFormedWeb() { CommentRss = p.Element(wfw + "commentRss").Value },
                                                                       Slash = new Slash() { Comments = Convert.ToInt32(p.Element(slash + "comments").Value)}
                                                                   })
                                                      .ToList()
                                   }
                     };

            throw new NotImplementedException();
        }

        #endregion Methods
    }
}