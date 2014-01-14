﻿using System;
using System.Collections.Generic;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Atom;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Atom
{
    /// <summary>
    /// This represents an entity of the source.
    /// </summary>
    /// <remarks>
    /// If an entry is copied from one feed into another feed, then the source feed's metadata (all child elements of feed other than the entry elements) should be preserved if the source feed contains any of the child elements author, contributor, rights, or category and those child elements are not present in the source entry.
    /// </remarks>
    public class Source : CommonAttributes, ISource
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets a universally unique and permanent URI. Suggestions on how to make a good id can be found [here](http://diveintomark.org/archives/2004/05/28/howto-atom-id). Two entries in a feed can have the same value for id if they represent the same entry at different points in time.
        /// </summary>
        public IId Id { get; set; }

        /// <summary>
        /// Gets or sets a human readable title for the entry. This value should not be blank.
        /// </summary>
        public IText Title { get; set; }

        /// <summary>
        /// Gets or sets the last time when the entry was modified in a significant way. This value need not change after a typo is fixed, only after a substantial modification. Generally, different entries in a feed will have different updated timestamps.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets one or more authors of the entry. An entry may have multiple authors. An entry must contain at least one author element unless there is an author element in the enclosing feed, or there is an author element in the enclosed source element. More info [here](http://atomenabled.org/developers/syndication/#person).
        /// </summary>
        public IList<IPerson> Authors { get; set; }

        /// <summary>
        /// Gets or sets a related Web page. The type of relation is defined by the rel attribute. An entry is limited to one alternate per type and hreflang. An entry must contain an alternate link if there is no content element. More info [here](http://atomenabled.org/developers/syndication/#link).
        /// </summary>
        public ILink Link { get; set; }

        /// <summary>
        /// Gets or sets one or more categories that the entry belongs to. More info [here](http://atomenabled.org/developers/syndication/#category).
        /// </summary>
        public IList<ICategory> Categories { get; set; }

        /// <summary>
        /// Gets or sets one or more contributors to the entry. More info [here](http://atomenabled.org/developers/syndication/#person).
        /// </summary>
        public IList<IPerson> Contributors { get; set; }

        /// <summary>
        /// Gets or sets the software used to generate the feed, for debugging and other purposes. Both the uri and version attributes are optional.
        /// </summary>
        public IGenerator Generator { get; set; }

        /// <summary>
        /// Gets or sets a small image which provides iconic visual identification for the feed. Icons should be square.
        /// </summary>
        public IIcon Icon { get; set; }

        /// <summary>
        /// Gets or sets a larger image which provides visual identification for the feed. Images should be twice as wide as they are tall.
        /// </summary>
        public ILogo Logo { get; set; }

        /// <summary>
        /// Gets or sets information about rights, e.g. copyrights, held in and over the feed. More info [here](http://atomenabled.org/developers/syndication/#text).
        /// </summary>
        public IText Rights { get; set; }

        /// <summary>
        /// Gets or sets a human-readable description or subtitle for the feed. More info [here](http://atomenabled.org/developers/syndication/#text).
        /// </summary>
        public IText SubTitle { get; set; }

        #endregion Properties - Optional
    }
}