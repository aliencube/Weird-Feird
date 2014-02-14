using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity of a "story". This must be inherited.
    /// </summary>
    /// <remarks>
    /// This is much like a story in a newspaper or magazine; if so its description is a synopsis of the story,
    /// and the link points to the full story. An item may also be complete in itself, if so, the description
    /// contains the text (entity-encoded HTML is allowed), and the link and title may be omitted. All elements
    /// of an item are optional, however at least one of title or description must be present.
    /// </remarks>
    public abstract class EntryItem
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the title of the item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL of the item.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the item synopsis.
        /// </summary>
        public string Description { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the email address of the author of the item. [More](http://www.rssboard.org/rss-specification#ltauthorgtSubelementOfLtitemgt).
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets one or more categories that the item belongs to.
        /// </summary>
        public IList<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the URL of a page for comments relating to the item. [More](http://www.rssboard.org/rss-specification#ltcommentsgtSubelementOfLtitemgt).
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the media object that is attached to the item. [More](http://www.rssboard.org/rss-specification#ltenclosuregtSubelementOfLtitemgt).
        /// </summary>
        public Enclosure Enclosure { get; set; }

        /// <summary>
        /// Gets or sets the guid or permalink URL for this entry. [More](http://www.rssboard.org/rss-specification#ltguidgtSubelementOfLtitemgt).
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the date when the item was published. This is UTC value. [More](http://www.rssboard.org/rss-specification#ltpubdategtSubelementOfLtitemgt).
        /// </summary>
        public DateTime? PubDate { get; set; }

        /// <summary>
        /// Gets or sets the RSS channel that the item came from. [More](http://www.rssboard.org/rss-specification#ltsourcegtSubelementOfLtitemgt).
        /// </summary>
        public Source Source { get; set; }

        #endregion Properties - Optional
    }
}