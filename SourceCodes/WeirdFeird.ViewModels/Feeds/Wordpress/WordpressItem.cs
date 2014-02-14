using Aliencube.WeirdFeird.ViewModels.Feeds.Extensions;
using Aliencube.WeirdFeird.ViewModels.Feeds.Rss;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress
{
    /// <summary>
    /// This represents the item entity for Wordpress.
    /// </summary>
    public partial class WordpressItem : EntryItem
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the DublinCore instance.
        /// </summary>
        public DublinCore DublinCore { get; set; }

        /// <summary>
        /// Gets or sets the Content instance.
        /// </summary>
        public Content Content { get; set; }

        /// <summary>
        /// Gets or sets the WellFormedWeb instance.
        /// </summary>
        public WellFormedWeb WellFormedWeb { get; set; }

        /// <summary>
        /// Gets or sets the Slash instance.
        /// </summary>
        public Slash Slash { get; set; }

        #endregion Properties - Optional
    }
}