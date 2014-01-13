namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
    /// <summary>
    /// This provides interfaces to the Source class.
    /// </summary>
    public interface ISource
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the value that describes the source URL.
        /// </summary>
        string Value { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the URL where the RSS channel that the item came from.
        /// </summary>
        string Url { get; set; }

        #endregion Properties - Optional
    }
}