using Aliencube.WeirdFeird.ViewModels.Feeds.Rss;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the RssFeedProvider class.
    /// </summary>
    public interface IRssFeedService : IFeedServiceBase
    {
        #region Methods

        /// <summary>
        /// Gets the channel element from the feed document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement channel instance.</returns>
        XElement GetChannel(XDocument feed);

        /// <summary>
        /// Gets the list of category instances from the list of category elements.
        /// </summary>
        /// <param name="elements">List of category elements.</param>
        /// <returns>Returns the list of category instances.</returns>
        IList<Category> GetCategories(IList<XElement> elements);

        #endregion Methods
    }
}