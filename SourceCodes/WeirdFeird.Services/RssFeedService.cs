using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Exceptions;
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
        public abstract bool IsWordpress(XDocument feed);

        /// <summary>
        /// Gets the channel element from the feed document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement channel instance.</returns>
        /// <exception cref="InvalidFeedFormatException">Throws when no channel element is found.</exception>
        public XElement GetChannel(XDocument feed)
        {
            var root = this.GetRoot(feed);
            var channel = root.Element("channel");
            if (channel == null)
                throw new InvalidFeedFormatException("No channel element found");

            return channel;
        }

        /// <summary>
        /// Gets the generator element from the feed document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement generator instance.</returns>
        public XElement GetGenerator(XDocument feed)
        {
            var channel = this.GetChannel(feed);

            return this.GetGenerator(channel);
        }

        /// <summary>
        /// Gets the generator element from the channel element.
        /// </summary>
        /// <param name="channel">XElement channel instance.</param>
        /// <returns>Returns the XElement generator instance.</returns>
        /// <exception cref="ArgumentNullException">Throws when channel is NULL.</exception>
        public XElement GetGenerator(XElement channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel", "No channel provided");

            return channel.Element("generator");
        }

        #endregion Methods
    }
}