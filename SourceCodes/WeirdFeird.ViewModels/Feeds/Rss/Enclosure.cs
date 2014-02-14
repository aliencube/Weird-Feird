namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity that describes a media object that is attached to the <c>Item</c>.
    /// </summary>
    public class Enclosure
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the URL where the enclosure is located.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the size in bytes.
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// Gets or sets the MIME media-type of the enclosure
        /// </summary>
        public string Type { get; set; }

        #endregion Properties - Required
    }
}