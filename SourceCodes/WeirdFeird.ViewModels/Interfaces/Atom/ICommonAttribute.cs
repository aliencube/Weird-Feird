namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Atom
{
    /// <summary>
    /// This provides interfaces to any class providing human readable text.
    /// </summary>
    public interface ICommonAttribute
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the value may be used to identify the language of any human readable text.
        /// </summary>
        string Lang { get; set; }

        /// <summary>
        /// Gets or sets the base URL may be used to control how relative URIs are resolved.
        /// </summary>
        string Base { get; set; }

        #endregion Properties - Optional
    }
}