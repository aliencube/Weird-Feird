namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
    /// <summary>
    /// This provides interfaces to the Enclosure class.
    /// </summary>
    public interface IEnclosure
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the URL where the enclosure is located.
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the size in bytes.
        /// </summary>
        long Length { get; set; }

        /// <summary>
        /// Gets or sets the MIME media-type of the enclosure
        /// </summary>
        string Type { get; set; }

        #endregion Properties - Required
    }
}