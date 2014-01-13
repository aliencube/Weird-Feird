using Aliencube.WeirdFeird.ViewModels.Interfaces.Rss;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents the RSS feed entity. This must be inherited.
    /// </summary>
    /// <remarks>
    /// The structure of this class is based on http://www.rssboard.org/rss-specification.
    /// </remarks>
    public abstract class RssFeed : IRss
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the RssFeed class.
        /// </summary>
        protected RssFeed()
        {
            this.Version = 2.0m;
        }

        #endregion Constructors

        #region Properties - Required

        /// <summary>
        /// Gets the RSS version.
        /// </summary>
        /// <remarks>It is always <c>2.0</c>.</remarks>
        public decimal Version { get; private set; }

        /// <summary>
        /// Gets or sets the RSS channel instance.
        /// </summary>
        public IChannel Channel { get; set; }

        #endregion Properties - Required
    }
}