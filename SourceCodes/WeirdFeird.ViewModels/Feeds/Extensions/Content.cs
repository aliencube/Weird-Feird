namespace Aliencube.WeirdFeird.ViewModels.Feeds.Extensions
{
    /// <summary>
    /// This represents an entity for Content that is a module for the actual content of websites, in multiple formats.
    /// </summary>
    public class Content
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets an element whose contents are the entity-encoded or CDATA-escaped version of the content of the item.
        /// </summary>
        public string Encoded { get; set; }

        #endregion Properties - Required
    }
}