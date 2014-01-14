using Aliencube.WeirdFeird.Services.Exceptions;
using System;
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
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when no root element is found.</exception>
        bool IsWordpress(XDocument feed);

        #endregion Methods
    }
}