namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Atom
{
    /// <summary>
    /// This provides interfaces to the Content class.
    /// </summary>
    public interface IContent : ICommonAttribute
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the media type of the content.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the URI of where the content can be found.
        /// </summary>
        string Src { get; set; }

        #endregion Properties - Optional
    }
}