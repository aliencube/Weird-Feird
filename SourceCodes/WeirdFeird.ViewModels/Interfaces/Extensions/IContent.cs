namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Extensions
{
    /// <summary>
    /// This provides interfaces to the Content class.
    /// </summary>
    public interface IContent
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets an element whose contents are the entity-encoded or CDATA-escaped version of the content of the item.
        /// </summary>
        string Encoded { get; set; }

        #endregion Properties - Required
    }
}