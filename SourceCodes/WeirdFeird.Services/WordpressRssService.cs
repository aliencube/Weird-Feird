﻿using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Exceptions;
using Aliencube.WeirdFeird.Extensions;
using Aliencube.WeirdFeird.Services.Interfaces;
using Aliencube.WeirdFeird.ViewModels.Feeds;
using Aliencube.WeirdFeird.ViewModels.Feeds.Atom;
using Aliencube.WeirdFeird.ViewModels.Feeds.Extensions;
using Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Initialises a new instance of the WordpressRssService class.
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

        #endregion Properties

        #region Methods

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
        /// <param name="element">XElement channel instance.</param>
        /// <returns>Returns the Wordpress RSS instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        public WordpressRss GetWordpressRss(XElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element", "No element provided");

            var wp = new WordpressRss() { Channel = this.GetWordpressChannel(element) };
            return wp;
        }

        /// <summary>
        /// Gets the Wordpress Channel instance from the channel element.
        /// </summary>
        /// <param name="element">XElement channel instance.</param>
        /// <returns>Returns the Wordpress Channel instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        public WordpressChannel GetWordpressChannel(XElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element", "No element provided");

            var atom = this.Namespaces["atom"];
            var sy = this.Namespaces["sy"];
            var channel = new WordpressChannel()
                          {
                              Title = element.Element("title").GetString(true),
                              AtomLink = new Link()
                                         {
                                             Href = element.Element(atom + "link").GetAttribute("href", true).GetString(true),

                                             Rel = element.Element(atom + "link").GetAttribute("rel").GetString(false),
                                             Type = element.Element(atom + "link").GetAttribute("type").GetString(false),
                                         },
                              Link = element.Element("link").GetString(true),
                              Description = element.Element("description").GetString(true),

                              LastBuildDate = element.Element("lastBuildDate").GetDateTime(false),
                              Language = element.Element("language").GetString(false),
                              Syndication = new Syndication()
                                            {
                                                UpdatePeriod = element.Element(sy + "updatePeriod").GetUpdaetPeriod(),
                                                UpdateFrequency = element.Element(sy + "updateFrequency").GetInt32(1)
                                            },
                              Generator = element.Element("generator").GetString(false),
                              Items = this.GetWordpressItems(element.Elements("item").ToList()),
                          };
            return channel;
        }

        /// <summary>
        /// Gets the list of Wordpress item entries from the channel element.
        /// </summary>
        /// <param name="element">XElement channel instance.</param>
        /// <returns>Returns the list of Wordpress Item instances.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        public IList<WordpressItem> GetWordpressItems(XElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element", "No element provided");

            var items = element.Elements("item").ToList();
            return this.GetWordpressItems(items);
        }

        /// <summary>
        /// Gets the list of Wordpress item entries from the list of item elements.
        /// </summary>
        /// <param name="elements">List of XElement item instances.</param>
        /// <returns>Returns the list of Wordpress Item instances.</returns>
        /// <exception cref="ArgumentNullException">Throws when elements is NULL or does not contain any item.</exception>
        public IList<WordpressItem> GetWordpressItems(IList<XElement> elements)
        {
            if (elements == null || !elements.Any())
                throw new ArgumentNullException("elements", "No elements provided");

            var content = this.Namespaces["content"];
            var wfw = this.Namespaces["wfw"];
            var dc = this.Namespaces["dc"];
            var slash = this.Namespaces["slash"];

            var items = elements.Select(p =>
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
            return items;
        }

        /// <summary>
        /// Gets the standard FeedAdapter instance from the feed instance.
        /// </summary>
        /// <typeparam name="T">Feed type.</typeparam>
        /// <param name="feed">Feed instance.</param>
        /// <returns>Returns the standard FeedAdapter instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when feed format is not Wordpress RSS.</exception>
        public override FeedAdapter GetFeedAdapter<T>(T feed)
        {
            if (feed.Equals(default(T)))
                throw new ArgumentNullException("feed", "No feed found");

            var instance = feed as WordpressRss;
            if (instance == null)
                throw new InvalidFeedFormatException("Not a valid Wordpress feed");

            var adapter = new FeedAdapter()
                          {
                              Title = instance.Channel.Title,
                              Description = instance.Channel.Description,
                              Link = instance.Channel.Link,
                              FeedLink = instance.Channel.AtomLink.Href,
                              Generator = instance.Channel.Generator,
                              DateLastUpdated = instance.Channel.LastBuildDate,
                              Editors = new List<string>() { instance.Channel.ManagingEditor },
                              Entries = this.GetFeedEntryAdapters(instance.Channel.Items),
                          };
            return adapter;
        }

        /// <summary>
        /// Gets the list of standard Feed Entry instances from the list of the feed entry instances.
        /// </summary>
        /// <typeparam name="T">Feed item type.</typeparam>
        /// <param name="entries">List of feed item instances.</param>
        /// <returns>Returns the list of standard Feed Entry instances.</returns>
        /// <exception cref="ArgumentNullException">Throws when entries is NULL or does not contain any item.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when feed format is not Wordpress RSS.</exception>
        public override IList<FeedEntryAdapter> GetFeedEntryAdapters<T>(IList<T> entries)
        {
            if (entries == null || !entries.Any())
                throw new ArgumentNullException("entries", "No entries provided");

            var items = entries as List<WordpressItem>;
            if (items == null)
                throw new InvalidFeedFormatException("Not a valid Wordpress feed");

            var adapters = items.Select(p => new FeedEntryAdapter()
                                             {
                                                 Title = p.Title,
                                                 Link = p.Link,
                                                 Permalink = p.Guid.Value,
                                                 CommentLink = p.Comments,
                                                 Description = p.Description,
                                                 Content = p.Content.Encoded,
                                                 //Thumbnail = p.Thumbnail,
                                                 DatePublished = p.PubDate,
                                                 Authors = new List<string>() { p.Author },
                                                 Categories = p.Categories.ToDictionary(q => q.Value, r => r.Domain),
                                             })
                                .ToList();
            return adapters;
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
            var adapter = this.GetFeedAdapter(wp);

            return adapter;
        }

        #endregion Methods
    }
}