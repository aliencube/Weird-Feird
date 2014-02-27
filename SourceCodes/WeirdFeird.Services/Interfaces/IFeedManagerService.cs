using System.Collections.Generic;

namespace Aliencube.WeirdFeird.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the FeedManagerService class.
    /// </summary>
    public interface IFeedManagerService
    {
        #region Methods

        /// <summary>
        /// Gets the list of feed links.
        /// </summary>
        /// <returns>Returns the list of feed links.</returns>
        IList<string> GetFeedLinks();

        #endregion Methods
    }
}