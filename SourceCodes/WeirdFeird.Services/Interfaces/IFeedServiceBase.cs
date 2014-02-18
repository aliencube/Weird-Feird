using Aliencube.WeirdFeird.Enums;
using Aliencube.WeirdFeird.ViewModels.Feeds;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the ProviderBase class.
    /// </summary>
    public interface IFeedServiceBase : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets the list of namespaces used in the feed.
        /// </summary>
        IDictionary<string, XNamespace> Namespaces { get; }

        /// <summary>
        /// Gets the regular expression instance to check feed generator.
        /// </summary>
        Regex Generator { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the XML feed contents from given feed URL asynchronously.
        /// </summary>
        /// <param name="feedUrl">Feed URL.</param>
        /// <returns>Returns the XML feed contents from given feed URL asynchronously.</returns>
        Task<XDocument> GetFeedXmlAsync(string feedUrl);

        /// <summary>
        /// Gets the root element from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement root instance.</returns>
        XElement GetRootElement(XDocument feed);

        /// <summary>
        /// Gets the generator element from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement generator instance.</returns>
        XElement GetGeneratorElement(XDocument feed);

        /// <summary>
        /// Gets the feed type.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the feed type.</returns>
        FeedType GetFeedType(XDocument feed);

        /// <summary>
        /// Gets the feed generator.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the feed generator.</returns>
        FeedGenerator GetFeedGenerator(XDocument feed);

        /// <summary>
        /// Gets the standardised feed instance from the feed XML document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the standardised feed instance.</returns>
        FeedAdapter GetFeed(XDocument feed);

        /// <summary>
        /// Gets the standard FeedAdapter instance from the feed instance.
        /// </summary>
        /// <typeparam name="T">Feed type.</typeparam>
        /// <param name="feed">Feed instance.</param>
        /// <returns>Returns the standard FeedAdapter instance.</returns>
        FeedAdapter GetFeedAdapter<T>(T feed);

        /// <summary>
        /// Gets the list of standard Feed Entry instances from the list of the feed entry instances.
        /// </summary>
        /// <typeparam name="T">Feed item type.</typeparam>
        /// <param name="entries">List of feed item instances.</param>
        /// <returns>Returns the list of standard Feed Entry instances.</returns>
        IList<FeedEntryAdapter> GetFeedEntryAdapters<T>(IList<T> entries);

        #endregion Methods
    }
}