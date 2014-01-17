using Aliencube.WeirdFeird.ViewModels.Interfaces;
using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Feeds
{
    /// <summary>
    /// this represents the standard feed item entity.
    /// </summary>
    public partial class FeedEntryAdapter : IFeedEntryAdapter
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title of the feed entry.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the link URL of the feed entry.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the permalink URL of the feed entry.
        /// </summary>
        public string Permalink { get; set; }

        /// <summary>
        /// Gets or sets the link URL of the comment for the feed entry.
        /// </summary>
        public string CommentLink { get; set; }

        /// <summary>
        /// Gets or sets the brief discription of the feed entry.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the contents of the feed entry.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail URL that represents the feed entry.
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the date when the feed entry was published.
        /// </summary>
        public DateTime? DatePublished { get; set; }

        /// <summary>
        /// Gets or sets the list of authors for the feed entry.
        /// </summary>
        public IList<string> Authors { get; set; }

        /// <summary>
        /// Gets or sets the list of categories for the feed entry.
        /// </summary>
        public IDictionary<string, string> Categories { get; set; }

        #endregion Properties
    }
}