namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity indicating the permalink of the <c>Item</c>.
    /// </summary>
    public class Guid
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the permalink URL.
        /// </summary>
        public string Value { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the value that specifies whether the GUID represents a permalink or not.
        /// </summary>
        public bool? IsPermaLink { get; set; }

        #endregion Properties - Optional
    }
}