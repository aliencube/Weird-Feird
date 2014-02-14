namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity that specifies a text input box that can be displayed with the channel/feed.
    /// </summary>
    public class TextInput
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the label of the Submit button in the text input area.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the eplanation of the text input area.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the text object in the text input area.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL of the CGI script that processes text input requests.
        /// </summary>
        public string Link { get; set; }

        #endregion Properties - Required
    }
}