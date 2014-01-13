namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
    /// <summary>
    /// This provides interfaces to the Image class.
    /// </summary>
    public interface IImage
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the URL of a GIF, JPEG or PNG image that represents the channel.
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the description of the image which is used in the <c>alt</c> attribute of the HTML <c>img</c> tag when the channel is rendered in HTML.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL of the site, when the channel is rendered, the image is a link to the site. (Note, in practice the image <c>Title</c> and <c>Link</c> should have the same value as the channel's <c>Title</c> and <c>Link</c>.
        /// </summary>
        string Link { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the width of the image in pixels. Its maximum value is 144. Default value is 88.
        /// </summary>
        int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the imag in pixels. Its maxinum value is 400. Default value is 31.
        /// </summary>
        int? Height { get; set; }

        /// <summary>
        /// Gets or sets the text that is included in the <c>Title</c> property of the <c>Link</c> formed around the image in the HTML rendering.
        /// </summary>
        string Description { get; set; }

        #endregion Properties - Optional
    }
}