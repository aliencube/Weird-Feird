﻿using Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Wordpress
{
    /// <summary>
    /// This provide interfaces to the WordpressRss class.
    /// </summary>
    public interface IWordpressRss
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the WordpressChannel instance.
        /// </summary>
        WordpressChannel Channel { get; set; }

        #endregion Properties - Required
    }
}