namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
    /// <summary>
    /// This provides interfaces to the Category class.
    /// </summary>
    public interface ICategory
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the value of the category.
        /// </summary>
        string Value { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the URL of the category.
        /// </summary>
        string Domain { get; set; }

        #endregion Properties - Optional
    }
}