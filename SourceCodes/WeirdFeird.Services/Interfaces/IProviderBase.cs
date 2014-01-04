using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the ProviderBase class.
    /// </summary>
    public interface IProviderBase : IDisposable
    {
        #region Methods

        /// <summary>
        /// Gets the XML feed contents from given feed URL asynchronously.
        /// </summary>
        /// <param name="feedUrl">Feed URL.</param>
        /// <returns>Returns the XML feed contents from given feed URL asynchronously.</returns>
        Task<XDocument> GetFeedXmlAsync(string feedUrl);

        /// <summary>
        /// Checks wether the given XML document is for RSS feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the name of the root element is "rss"; otherwise returns <c>False</c>.</returns>
        bool IsRss(XDocument feed);

        /// <summary>
        /// Checks wether the given XML document is for ATOM feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the name of the root element is "feed"; otherwise returns <c>False</c>.</returns>
        bool IsAtom(XDocument feed);

        #endregion
    }
}
