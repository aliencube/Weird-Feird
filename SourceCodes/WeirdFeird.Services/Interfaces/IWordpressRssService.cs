using Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the WordpressProvider class.
    /// </summary>
    public interface IWordpressRssService : IRssFeedService
    {
        #region Methods

        /// <summary>
        /// Gets the Wordpress RSS instance from the feed document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        WordpressRss GetWordpressRss(XDocument feed);

        /// <summary>
        /// Gets the Wordpress RSS instance from the channel element.
        /// </summary>
        /// <param name="element">XElement channel instance.</param>
        /// <returns>Returns the Wordpress RSS instance.</returns>
        WordpressRss GetWordpressRss(XElement element);

        /// <summary>
        /// Gets the Wordpress Channel instance from the channel element.
        /// </summary>
        /// <param name="element">XElement channel instance.</param>
        /// <returns>Returns the Wordpress Channel instance.</returns>
        WordpressChannel GetWordpressChannel(XElement element);

        /// <summary>
        /// Gets the list of Wordpress item entries from the channel element.
        /// </summary>
        /// <param name="element">XElement channel instance.</param>
        /// <returns>Returns the list of Wordpress Item instances.</returns>
        IList<WordpressItem> GetWordpressItems(XElement element);

        /// <summary>
        /// Gets the list of Wordpress item entries from the list of item elements.
        /// </summary>
        /// <param name="elements">List of XElement item instances.</param>
        /// <returns>Returns the list of Wordpress Item instances.</returns>
        IList<WordpressItem> GetWordpressItems(IList<XElement> elements);

        #endregion Methods
    }
}