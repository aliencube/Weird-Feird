using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces
{
    /// <summary>
    /// This provides interfaces to the FeedEntry class.
    /// </summary>
    public interface IFeedEntryAdapter
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title of the feed entry.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the link URL of the feed entry.
        /// </summary>
        string Link { get; set; }

        /// <summary>
        /// Gets or sets the permalink URL of the feed entry.
        /// </summary>
        string Permalink { get; set; }

        /// <summary>
        /// Gets or sets the link URL of the comment for the feed entry.
        /// </summary>
        string CommentLink { get; set; }

        /// <summary>
        /// Gets or sets the brief discription of the feed entry.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the contents of the feed entry.
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail URL that represents the feed entry.
        /// </summary>
        string Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the date when the feed entry was published.
        /// </summary>
        DateTime? DatePublished { get; set; }

        /// <summary>
        /// Gets or sets the list of authors for the feed entry.
        /// </summary>
        IList<string> Authors { get; set; }

        /// <summary>
        /// Gets or sets the list of categories for the feed entry.
        /// </summary>
        IDictionary<string, string> Categories { get; set; }

        #endregion Properties
    }
}