using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Extensions;
using Aliencube.WeirdFeird.Services.Interfaces;
using Aliencube.WeirdFeird.ViewModels.Feeds;
using Aliencube.WeirdFeird.ViewModels.Feeds.Atom;
using Aliencube.WeirdFeird.ViewModels.Feeds.Extensions;
using Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Content = Aliencube.WeirdFeird.ViewModels.Feeds.Extensions.Content;
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
        public override bool IsWordpress(XDocument feed)
        {
            var generator = this.GetGenerator(feed);
            if (generator == null)
                return false;

            var value = generator.Value;
            return this.Generator.IsMatch(value);
        }

        /// <summary>
        /// Gets the Wordpress RSS instance from the feed document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the Wordpress RSS instance.</returns>
        public WordpressRss GetWordpressRss(XDocument feed)
        {
            var channel = this.GetChannel(feed);
            return this.GetWordpressRss(channel);
        }

        /// <summary>
        /// Gets the Wordpress RSS instance from the channel element.
        /// </summary>
        /// <param name="channel">XElement channel instance.</param>
        /// <returns>Returns the Wordpress RSS instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when channel is NULL.</exception>
        public WordpressRss GetWordpressRss(XElement channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel", "No channel provided");

            var wp = new WordpressRss() { Channel = this.GetWordpressChannel(channel) };
            return wp;
        }

        /// <summary>
        /// Gets the Wordpress Channel instance from the channel element.
        /// </summary>
        /// <param name="channel">XElement channel instance.</param>
        /// <returns>Returns the Wordpress Channel instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when channel is NULL.</exception>
        public WordpressChannel GetWordpressChannel(XElement channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel", "No channel provided");

            var atom = this.Namespaces["atom"];
            var sy = this.Namespaces["sy"];
            var wp = new WordpressChannel()
                     {
                         Title = channel.Element("title").GetString(true),
                         AtomLink = new Link()
                                    {
                                        Href = channel.Element(atom + "link").GetAttribute("href", true).GetString(true),

                                        Rel = channel.Element(atom + "link").GetAttribute("rel").GetString(false),
                                        Type = channel.Element(atom + "link").GetAttribute("type").GetString(false),
                                    },
                         Link = channel.Element("link").GetString(true),
                         Description = channel.Element("description").GetString(true),

                         LastBuildDate = channel.Element("lastBuildDate").GetDateTime(false),
                         Language = channel.Element("language").GetString(false),
                         Syndication = new Syndication()
                                       {
                                           UpdatePeriod = channel.Element(sy + "updatePeriod").GetUpdaetPeriod(),
                                           UpdateFrequency = channel.Element(sy + "updateFrequency").GetInt32(1)
                                       },
                         Generator = channel.Element("generator").GetString(false),
                         Items = this.GetWordpressItems(channel.Elements("item").ToList()),
                     };
            return wp;
        }

        /// <summary>
        /// Gets the list of Wordpress item entries from the channel element.
        /// </summary>
        /// <param name="channel">XElement channel instance.</param>
        /// <returns>Returns the list of Wordpress Item instances.</returns>
        /// <exception cref="ArgumentNullException">Throws when channel is NULL.</exception>
        public IList<WordpressItem> GetWordpressItems(XElement channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel", "No channel provided");

            var items = channel.Elements("item").ToList();
            return this.GetWordpressItems(items);
        }

        /// <summary>
        /// Gets the list of Wordpress item entries from the list of item elements.
        /// </summary>
        /// <param name="items">List of XElement item instances.</param>
        /// <returns>Returns the list of Wordpress Item instances.</returns>
        /// <exception cref="ArgumentNullException">Throws when items is NULL or does not contain any item.</exception>
        public IList<WordpressItem> GetWordpressItems(IList<XElement> items)
        {
            if (items == null || !items.Any())
                throw new ArgumentNullException("items", "No items provided");

            var content = this.Namespaces["content"];
            var wfw = this.Namespaces["wfw"];
            var dc = this.Namespaces["dc"];
            var slash = this.Namespaces["slash"];

            var wp = items.Select(p =>
                                  new WordpressItem()
                                  {
                                      Title = p.Element("title").GetString(true),
                                      Link = p.Element("link").GetString(true),
                                      Description = p.Element("description").GetString(true),

                                      Comments = p.Element("comments").GetString(false),
                                      PubDate = p.Element("pubDate").GetDateTime(false),
                                      DublinCore = new DublinCore()
                                                   {
                                                       Creator = p.Element(dc + "creator").GetString(false)
                                                   },
                                      Categories = this.GetCategories(p.Elements("category").ToList()),
                                      Guid = new Guid()
                                             {
                                                 IsPermaLink = p.Element("guid").GetAttribute("isPermaLink").GetBoolean(false, true),
                                                 Value = p.Element("guid").GetString(false)
                                             },
                                      Content = new Content()
                                                {
                                                    Encoded = p.Element(content + "encoded").GetString(false)
                                                },
                                      WellFormedWeb = new WellFormedWeb()
                                                      {
                                                          CommentRss = p.Element(wfw + "commentRss").GetString(false)
                                                      },
                                      Slash = new Slash()
                                              {
                                                  Comments = p.Element(slash + "comments").GetInt32(false)
                                              }
                                  })
                          .ToList();
            return wp;
        }

        /// <summary>
        /// Gets the standardised feed instance from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the standardised feed instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        public override FeedAdapter GetFeed(XDocument feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed", "No feed provided");

            var wp = this.GetWordpressRss(feed);

            throw new NotImplementedException();
        }

        #endregion Methods
    }
}