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
        /// Checks whether the given XML document is for Wordpress feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the generator element identifies it is a Wordpress feed; otherwise returns <c>False</c>.</returns>
        bool IsWordpress(XDocument feed);

        /// <summary>
        /// Gets the channel element from the feed document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement channel instance.</returns>
        XElement GetChannel(XDocument feed);

        /// <summary>
        /// Gets the generator element from the feed document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement generator instance.</returns>
        XElement GetGenerator(XDocument feed);

        /// <summary>
        /// Gets the generator element from the channel element.
        /// </summary>
        /// <param name="channel">XElement channel instance.</param>
        /// <returns>Returns the XElement generator instance.</returns>
        XElement GetGenerator(XElement channel);

        /// <summary>
        /// Gets the list of category instances from the list of category elements.
        /// </summary>
        /// <param name="elements">List of category elements.</param>
        /// <returns>Returns the list of category instances.</returns>
        IList<Category> GetCategories(IList<XElement> elements);

        #endregion Methods
    }
}