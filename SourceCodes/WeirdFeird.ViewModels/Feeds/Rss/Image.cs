namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity consumed in RSS channel/feed, which is a GIF, JPEG or PNG image that can be displayed with the channel/feed.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets or sets the URL of a GIF, JPEG or PNG image that represents the channel/feed.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a description of the image, it's used in the ALT attribute of the HTML &lt;img&gt; tag when the channel/feed is rendered in HTML.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL of the site, when the channel/feed is rendered, the image is a link to the site. 
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the width of the image in pixels. Default value is 88 and maximum value is 144.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the image in pixels. Default value is 81 and maximum value is 400.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the text to be included in the TITLE attribute of the HTML &lt;a&gt; tag when the channel/feed is rendering.
        /// </summary>
        public string Description { get; set; }
    }
}