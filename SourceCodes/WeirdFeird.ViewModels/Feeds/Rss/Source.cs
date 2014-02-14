namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity indicating which RSS channel/feed the <c>Item</c> instance came from.
    /// </summary>
    public class Source
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the value that describes the source URL.
        /// </summary>
        public string Value { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the URL where the RSS channel that the item came from.
        /// </summary>
        public string Url { get; set; }

        #endregion Properties - Optional
    }
}