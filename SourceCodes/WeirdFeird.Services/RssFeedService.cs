﻿using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Exceptions;
using Aliencube.WeirdFeird.Extensions;
using Aliencube.WeirdFeird.Services.Interfaces;
using Aliencube.WeirdFeird.ViewModels.Feeds.Rss;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Initialises a new instance of the RssFeedService class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        protected RssFeedService(IWeirdFeirdSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the channel element from the feed document.
        /// </summary>
        /// <param name="feed">XDocument feed instance.</param>
        /// <returns>Returns the XElement channel instance.</returns>
        /// <exception cref="InvalidFeedFormatException">Throws when no channel element is found.</exception>
        public XElement GetChannel(XDocument feed)
        {
            var root = this.GetRootElement(feed);
            var channel = root.Element("channel");
            if (channel == null)
                throw new FeedElementNotFoundException("channel", "No channel element found");

            return channel;
        }

        /// <summary>
        /// Gets the list of category instances from the list of category elements.
        /// </summary>
        /// <param name="elements">List of category elements.</param>
        /// <returns>Returns the list of category instances.</returns>
        public IList<Category> GetCategories(IList<XElement> elements)
        {
            if (elements == null || !elements.Any())
                throw new ArgumentNullException("elements", "No elements provided");

            if (elements.All(p => p.Name.ToString() != "category"))
                throw new FeedElementNotFoundException("category", "No category element provided");

            var categories = elements.Select(q => new Category()
                                                  {
                                                      Domain = q.GetAttribute("domain").GetString(false),
                                                      Value = q.GetString(false)
                                                  })
                                     .ToList();
            return categories;
        }

        #endregion Methods
    }
}