namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Atom
{
    /// <summary>
    /// This provides interfaces to the Category class.
    /// </summary>
    public interface ICategory : ICommonAttribute
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        string Term { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the categorization scheme via a URI.
        /// </summary>
        string Scheme { get; set; }

        /// <summary>
        /// Gets or sets a human-readable label for display.
        /// </summary>
        string Label { get; set; }

        #endregion Properties - Optional
    }
}