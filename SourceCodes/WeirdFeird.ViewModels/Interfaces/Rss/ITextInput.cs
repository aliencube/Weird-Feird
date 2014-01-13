namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
    /// <summary>
    /// This provides interfaces to the TextInput class.
    /// </summary>
    public interface ITextInput
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the label of the Submit button in the text input area.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the eplanation of the text input area.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the text object in the text input area.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL of the CGI script that processes text input requests.
        /// </summary>
        string Link { get; set; }

        #endregion Properties - Required
    }
}