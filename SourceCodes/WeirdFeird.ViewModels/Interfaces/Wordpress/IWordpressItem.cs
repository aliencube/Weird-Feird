using Aliencube.WeirdFeird.ViewModels.Interfaces.Extensions;

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
        IDublinCore DublinCore { get; set; }

        /// <summary>
        /// Gets or sets the Content instance.
        /// </summary>
        IContent Content { get; set; }

        /// <summary>
        /// Gets or sets the WellFormedWeb instance.
        /// </summary>
        IWellFormedWeb WellFormedWeb { get; set; }

        /// <summary>
        /// Gets or sets the Slash instance.
        /// </summary>
        ISlash Slash { get; set; }

        #endregion Properties - Optional
    }
}