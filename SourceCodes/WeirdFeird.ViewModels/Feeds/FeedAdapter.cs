﻿using Aliencube.WeirdFeird.ViewModels.Interfaces;
using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Feeds
{
    /// <summary>
    /// This represents the standard feed entity.
    /// </summary>
    public partial class FeedAdapter : IFeedAdapter
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title of the feed.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the brief discription of the feed.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the link of the website providing the feed.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the link of the feed.
        /// </summary>
        public string FeedLink { get; set; }

        /// <summary>
        /// Gets or sets the tools that generates the feed.
        /// </summary>
        public string Generator { get; set; }

        /// <summary>
        /// Gets or sets the date/time in UTC, which lastly updated the feed.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the list of authors managing the feed.
        /// </summary>
        public IList<string> Editors { get; set; }

        /// <summary>
        /// Gets or sets the list of standard feed item instances.
        /// </summary>
        public IList<IFeedEntry> Entries { get; set; }

        #endregion Properties
    }
}