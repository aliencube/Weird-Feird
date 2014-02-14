namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity consumed in RSS channel/feed, which is a GIF, JPEG or PNG image that can be displayed with the channel/feed.
    /// </summary>
    public class Image
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the Image class.
        /// </summary>
        public Image()
        {
            this.Width = 144;
            this.Height = 31;
        }

        #endregion Constructors

        #region Properties - Required

        /// <summary>
        /// Gets or sets the URL of a GIF, JPEG or PNG image that represents the channel.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the description of the image which is used in the <c>alt</c> attribute of the HTML <c>img</c> tag when the channel is rendered in HTML.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL of the site, when the channel is rendered, the image is a link to the site. (Note, in practice the image <c>Title</c> and <c>Link</c> should have the same value as the channel's <c>Title</c> and <c>Link</c>.
        /// </summary>
        public string Link { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the width of the image in pixels. Its maximum value is 144. Default value is 88.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the imag in pixels. Its maxinum value is 400. Default value is 31.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the text that is included in the <c>Title</c> property of the <c>Link</c> formed around the image in the HTML rendering.
        /// </summary>
        public string Description { get; set; }

        #endregion Properties - Optional
    }
}