namespace Aliencube.WeirdFeird.ViewModels.Feeds.Atom
{
    /// <summary>
    /// This represents an entity of the content that either contains, or links to, the complete content of the entry.
    /// </summary>
    public class Content : CommonAttributes
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the media type of the content.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the URI of where the content can be found.
        /// </summary>
        public string Src { get; set; }

        #endregion Properties - Optional
    }
}