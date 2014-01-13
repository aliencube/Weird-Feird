using Aliencube.WeirdFeird.ViewModels.Feeds.Rss;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Extensions;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Wordpress;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress
{
    /// <summary>
    /// This represents the item entity for Wordpress.
    /// </summary>
    public partial class WordpressItem : EntryItem, IWordpressItem
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the DublinCore instance.
        /// </summary>
        public IDublinCore DublinCore { get; set; }

        /// <summary>
        /// Gets or sets the Content instance.
        /// </summary>
        public IContent Content { get; set; }

        /// <summary>
        /// Gets or sets the WellFormedWeb instance.
        /// </summary>
        public IWellFormedWeb WellFormedWeb { get; set; }

        /// <summary>
        /// Gets or sets the Slash instance.
        /// </summary>
        public ISlash Slash { get; set; }

        #endregion Properties - Optional
    }
}