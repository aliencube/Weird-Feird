using Aliencube.WeirdFeird.ViewModels.Feeds.Extensions;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Wordpress
{
    /// <summary>
    /// This provides interfaces to the WordpressItem class.
    /// </summary>
    public interface IWordpressItem
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the DublinCore instance.
        /// </summary>
        DublinCore DublinCore { get; set; }

        /// <summary>
        /// Gets or sets the Content instance.
        /// </summary>
        Content Content { get; set; }

        /// <summary>
        /// Gets or sets the WellFormedWeb instance.
        /// </summary>
        WellFormedWeb WellFormedWeb { get; set; }

        /// <summary>
        /// Gets or sets the Slash instance.
        /// </summary>
        Slash Slash { get; set; }

        #endregion Properties - Optional
    }
}