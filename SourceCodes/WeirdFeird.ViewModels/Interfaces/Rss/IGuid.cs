namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
    /// <summary>
    /// This provides interfaces to the Guid class.
    /// </summary>
    public interface IGuid
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the permalink URL.
        /// </summary>
        string Value { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the value that specifies whether the GUID represents a permalink or not.
        /// </summary>
        bool? IsPermaLink { get; set; }

        #endregion Properties - Optional
    }
}