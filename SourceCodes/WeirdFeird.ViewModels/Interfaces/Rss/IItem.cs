using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
    /// <summary>
    /// This provides interfaces to the Item class.
    /// </summary>
    public interface IItem
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the title of the item.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL of the item.
        /// </summary>
        string Link { get; set; }

        /// <summary>
        /// Gets or sets the item synopsis.
        /// </summary>
        string Description { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the email address of the author of the item. [More](http://www.rssboard.org/rss-specification#ltauthorgtSubelementOfLtitemgt).
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Gets or sets one or more categories that the item belongs to.
        /// </summary>
        IList<ICategory> Categories { get; set; }

        /// <summary>
        /// Gets or sets the URL of a page for comments relating to the item. [More](http://www.rssboard.org/rss-specification#ltcommentsgtSubelementOfLtitemgt).
        /// </summary>
        string Comments { get; set; }

        /// <summary>
        /// Gets or sets the media object that is attached to the item. [More](http://www.rssboard.org/rss-specification#ltenclosuregtSubelementOfLtitemgt).
        /// </summary>
        IEnclosure Enclosure { get; set; }

        /// <summary>
        /// Gets or sets the guid or permalink URL for this entry. [More](http://www.rssboard.org/rss-specification#ltguidgtSubelementOfLtitemgt).
        /// </summary>
        IGuid Guid { get; set; }

        /// <summary>
        /// Gets or sets the date when the item was published. [More](http://www.rssboard.org/rss-specification#ltpubdategtSubelementOfLtitemgt).
        /// </summary>
        DateTime? PubDate { get; set; }

        /// <summary>
        /// Gets or sets the RSS channel that the item came from. [More](http://www.rssboard.org/rss-specification#ltsourcegtSubelementOfLtitemgt).
        /// </summary>
        ISource Source { get; set; }

        #endregion Properties - Optional
    }
}