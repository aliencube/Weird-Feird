using Aliencube.WeirdFeird.ViewModels.Feeds;
using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces
{
    /// <summary>
    /// This provides interfaces to the FeedAdapter class.
    /// </summary>
    public interface IFeedAdapter
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title of the feed.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the brief discription of the feed.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the link of the website providing the feed.
        /// </summary>
        string Link { get; set; }

        /// <summary>
        /// Gets or sets the link of the feed.
        /// </summary>
        string FeedLink { get; set; }

        /// <summary>
        /// Gets or sets the tools that generates the feed.
        /// </summary>
        string Generator { get; set; }

        /// <summary>
        /// Gets or sets the date/time in UTC, which lastly updated the feed.
        /// </summary>
        DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the list of authors managing the feed.
        /// </summary>
        IList<string> Editors { get; set; }

        /// <summary>
        /// Gets or sets the list of standard feed item instances.
        /// </summary>
        IList<FeedEntryAdapter> Entries { get; set; }

        #endregion Properties
    }
}