namespace Aliencube.WeirdFeird.ViewModels.Feeds.Atom
{
    /// <summary>
    /// This represents an entity describing common attributes.
    /// </summary>
    public abstract class CommonAttributes
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the value may be used to identify the language of any human readable text.
        /// </summary>
        public string Lang { get; set; }

        /// <summary>
        /// Gets or sets the base URL may be used to control how relative URIs are resolved.
        /// </summary>
        public string Base { get; set; }

        #endregion Properties - Optional
    }
}