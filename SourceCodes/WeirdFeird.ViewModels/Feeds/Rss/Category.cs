namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity that describes a category of the <c>Item</c>.
    /// </summary>
    public class Category
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the value of the category.
        /// </summary>
        public string Value { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the URL of the category.
        /// </summary>
        public string Domain { get; set; }

        #endregion Properties - Optional
    }
}