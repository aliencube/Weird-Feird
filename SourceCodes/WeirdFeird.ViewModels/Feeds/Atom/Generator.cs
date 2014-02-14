namespace Aliencube.WeirdFeird.ViewModels.Feeds.Atom
{
    /// <summary>
    /// This represents an entity for generator that identifies the software used to generate the feed, for debugging and other purposes.
    /// </summary>
    public class Generator : CommonAttributes
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the URL of the software that generates the feed.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the version of the software that generates the feed.
        /// </summary>
        public string Version { get; set; }

        #endregion Properties - Optional
    }
}