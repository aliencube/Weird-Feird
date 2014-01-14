using Aliencube.WeirdFeird.ViewModels.Interfaces.Atom;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Atom
{
    /// <summary>
    /// This represents an entity for a category that the feed belongs to.
    /// </summary>
    public class Category : CommonAttributes, ICategory
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Term { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the categorization scheme via a URI.
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// Gets or sets a human-readable label for display.
        /// </summary>
        public string Label { get; set; }

        #endregion Properties - Optional
    }
}