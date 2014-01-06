namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity that describes a media object that is attached to the <c>Item</c>.
    /// </summary>
    public class Enclosure
    {
        /// <summary>
        /// Gets or sets the URL of the media object.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the length of the media object.
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// Gets or sets the standard MIME type of the media object.
        /// </summary>
        public string Type { get; set; }
    }
}