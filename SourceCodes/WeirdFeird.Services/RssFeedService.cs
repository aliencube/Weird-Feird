using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Services.Exceptions;
using Aliencube.WeirdFeird.Services.Interfaces;
using System;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Services
{
    /// <summary>
    /// This represents the provider entity for RSS feed.
    /// This must be inherited.
    /// </summary>
    public abstract class RssFeedService : FeedServiceBase, IRssFeedService
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the RssProvider class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        protected RssFeedService(IWeirdFeirdSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Checks whether the given XML document is for Wordpress feed or not.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns <c>True</c>, if the generator element identifies it is a Wordpress feed; otherwise returns <c>False</c>.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed is NULL.</exception>
        /// <exception cref="InvalidFeedFormatException">Throws when no root element is found.</exception>
        public abstract bool IsWordpress(XDocument feed);

        #endregion Methods
    }
}