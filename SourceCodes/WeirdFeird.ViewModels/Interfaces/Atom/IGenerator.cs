namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Atom
{
    /// <summary>
    /// This provides interfaces to the Generator class.
    /// </summary>
    public interface IGenerator : ICommonAttribute
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the URL of the software that generates the feed.
        /// </summary>
        string Uri { get; set; }

        /// <summary>
        /// Gets or sets the version of the software that generates the feed.
        /// </summary>
        string Version { get; set; }

        #endregion Properties - Optional
    }
}