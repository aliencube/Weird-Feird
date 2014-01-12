using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents the RSS feed entity. This must be inherited.
    /// </summary>
    /// <remarks>
    /// The structure of this class is based on http://www.rssboard.org/rss-specification.
    /// </remarks>
    public abstract class RssFeed
    {
        /// <summary>
        /// Gets or sets the name of the channel/feed.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the feed URL.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the phrase or sentence describing the channel/feed.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the language the channel/feed is written in.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets copyright notice for content in the channel.
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets email address for person responsible for editorial content.
        /// </summary>
        public string ManagingEditor { get; set; }

        /// <summary>
        /// Gets or sets email address for person responsible for technical issues relating to channel/feed.
        /// </summary>
        public string WebMaster { get; set; }

        /// <summary>
        /// Gets or sets the publication date for the content in the channel/feed.
        /// </summary>
        public DateTime PubDate { get; set; }

        /// <summary>
        /// Gets or sets the last time the content of the channel/feed changed.
        /// </summary>
        public DateTime LastBuildDate { get; set; }

        /// <summary>
        /// Gets or sets the list of categories that the channel/feed belong to.
        /// </summary>
        public IList<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets a string indicating the program used to generate the channel/feed.
        /// </summary>
        public string Generator { get; set; }

        /// <summary>
        /// Gets or sets a URL that points to the documentation (http://www.rssboard.org/rss-specification) for the format used in the RSS file.
        /// </summary>
        public string Docs { get; set; }

        /// <summary>
        /// Gets or sets the <c>Cloud</c> instance that allows processes to register with a cloud to be notified of updates to the channel, implementing a lightweight publish-subscribe protocol for RSS feeds.
        /// </summary>
        public Cloud Cloud { get; set; }

        /// <summary>
        /// Gets or sets the value in minutes that indicates how long a channel can be cached before refreshing from the source.
        /// </summary>
        public int Ttl { get; set; }

        /// <summary>
        /// Gets or sets a GIF, JPEG or PNG image that can be displayed with the channel/feed.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the PICS rating for the channel/feed.
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the <c>TextInput</c> instance that specifies a text input box that can be displayed with the channel/feed.
        /// </summary>
        public TextInput TextInput { get; set; }

        /// <summary>
        /// Gets or sets a hint for aggregators telling them which hours they can skip.
        /// </summary>
        public int SkipHours { get; set; }

        /// <summary>
        /// Gets or sets a hint for aggregators telling them which days they can skip.
        /// </summary>
        public string SkipDays { get; set; }

        /// <summary>
        /// Gets or sets the list of "story" items.
        /// </summary>
        public IList<EntryItem> Items { get; set; }
    }
}