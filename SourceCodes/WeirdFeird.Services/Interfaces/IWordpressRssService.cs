using System.Collections;
using System.Collections.Generic;
using Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress;
using System.Xml.Linq;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Wordpress;

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
        /// <param name="channel">XElement channel instance.</param>
        /// <returns>Returns the Wordpress RSS instance.</returns>
        WordpressRss GetWordpressRss(XElement channel);

        /// <summary>
        /// Gets the Wordpress Channel instance from the channel element.
        /// </summary>
        /// <param name="channel">XElement channel instance.</param>
        /// <returns>Returns the Wordpress Channel instance.</returns>
        WordpressChannel GetWordpressChannel(XElement channel);

        /// <summary>
        /// Gets the list of Wordpress item entries from the channel element.
        /// </summary>
        /// <param name="channel">XElement channel instance.</param>
        /// <returns>Returns the list of Wordpress Item instances.</returns>
        IList<WordpressItem> GetWordpressItems(XElement channel);

        /// <summary>
        /// Gets the list of Wordpress item entries from the list of item elements.
        /// </summary>
        /// <param name="items">List of XElement item instances.</param>
        /// <returns>Returns the list of Wordpress Item instances.</returns>
        IList<WordpressItem> GetWordpressItems(IList<XElement> items);

        #endregion Methods
    }
}