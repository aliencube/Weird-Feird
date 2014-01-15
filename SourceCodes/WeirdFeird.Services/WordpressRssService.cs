using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Services.Interfaces;
using Aliencube.WeirdFeird.ViewModels.Enums;
using Aliencube.WeirdFeird.ViewModels.Feeds;
using Aliencube.WeirdFeird.ViewModels.Feeds.Atom;
using Aliencube.WeirdFeird.ViewModels.Feeds.Extensions;
using Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Category = Aliencube.WeirdFeird.ViewModels.Feeds.Rss.Category;
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
                         Title = this.GetElementValue(channel.Element("title"), true),
                         AtomLink = new Link()
                                    {
                                        Href = this.GetAttributeValue("href", channel.Element(atom + "link"), true),
                                        Rel = this.GetAttributeValue("rel", channel.Element(atom + "link")),
                                        Type = this.GetAttributeValue("type", channel.Element(atom + "link")),
                                    },
                         Link = this.GetElementValue(channel.Element("link"), true),
                         Description = this.GetElementValue(channel.Element("description"), true),

                         LastBuildDate = Convert.ToDateTime(this.GetElementValue(channel.Element("lastBuildDate"))),
                         Language = this.GetElementValue(channel.Element("language")),
                         Syndication = new Syndication()
                                       {
                                           // TODO: Extension methods for conversion with default value.
                                           UpdatePeriod = (UpdatePeriod)Enum.Parse(typeof (UpdatePeriod), this.GetElementValue(channel.Element(sy + "updatePeriod")), true),
                                           // TODO: Extension methods for conversion with default value.
                                           UpdateFrequency = Convert.ToInt32(this.GetElementValue(channel.Element(sy + "updateFrequency")))
                                       },
                         Generator = this.GetElementValue(channel.Element("generator")),
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
                                      Title = this.GetElementValue(p.Element("title"), true),
                                      Link = this.GetElementValue(p.Element("link"), true),
                                      Description = this.GetElementValue(p.Element("description"), true),

                                      Comments = this.GetElementValue(p.Element("comments")),
                                      // TODO: Extension methods for conversion with default value.
                                      PubDate = Convert.ToDateTime(this.GetElementValue(p.Element("pubDate"))),
                                      DublinCore = new DublinCore()
                                                   {
                                                       Creator = this.GetElementValue(p.Element(dc + "creator"))
                                                   },
                                      // TODO: Implementation for GetCategories() method.
                                      Categories = p.Elements("category")
                                                    .Select(q =>
                                                            new Category()
                                                            {
                                                                Domain =
                                                                    q.Attribute("domain") != null
                                                                        ? q.Attribute("domain").Value
                                                                        : null,
                                                                Value = q.Value
                                                            })
                                                    .ToList(),
                                      Guid = new Guid()
                                             {
                                                 IsPermaLink =
                                                     Convert.ToBoolean(this.GetAttributeValue("isPermaLink",
                                                                                              p.Element("guid"))),
                                                 Value = this.GetElementValue(p.Element("guid"))
                                             },
                                      Content = new Content()
                                                {
                                                    Encoded = this.GetElementValue(p.Element(content + "encoded"))
                                                },
                                      WellFormedWeb = new WellFormedWeb()
                                                      {
                                                          CommentRss =
                                                              this.GetElementValue(p.Element(wfw + "commentRss"))
                                                      },
                                      Slash = new Slash()
                                              {
                                                  // TODO: Extension methods for conversion with default value.
                                                  Comments =
                                                      Convert.ToInt32(this.GetElementValue(p.Element(slash + "comments")))
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