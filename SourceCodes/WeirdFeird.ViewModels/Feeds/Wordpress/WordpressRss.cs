using Aliencube.WeirdFeird.ViewModels.Feeds.Rss;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress
{
    /// <summary>
    /// This represents the RSS feed entity for Wordpress.
    /// </summary>
    public partial class WordpressRss : RssFeed
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the WordpressChannel instance.
        /// </summary>
        public new WordpressChannel Channel { get; set; }

        #endregion Properties - Required
    }
}