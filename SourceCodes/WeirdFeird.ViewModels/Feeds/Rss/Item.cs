using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity of a "story", which is much like a story in a newspaper or magazine; if so its description is a synopsis of the story, and the link points to the full story. An item may also be complete in itself, if so, the description contains the text (entity-encoded HTML is allowed), and the link and title may be omitted. All elements of an item are optional, however at least one of title or description must be present.
    /// </summary>
    public class Item
    {
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

        /// <summary>
        /// Gets or sets Email address of the author of the item.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the list of categories that the item belongs to.
        /// </summary>
        public IList<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets URL of a page for comments relating to the item.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the <c>Enclosure</c> instance that describes a media object that is attached to the item.
        /// </summary>
        public Enclosure Enclosure { get; set; }

        /// <summary>
        /// Gets or sets a string that uniquely identifies the item.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the date indicating when the item was published.
        /// </summary>
        public DateTime PubDate { get; set; }

        /// <summary>
        /// Gets or sets the RSS channel/feed that the item came from.
        /// </summary>
        public Source Source { get; set; }
    }
}