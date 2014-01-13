﻿using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Atom
{
    /// <summary>
    /// This provides interfaces to the Feed class.
    /// </summary>
    public interface IFeed
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the universally unique and permanent URI.
        /// </summary>
        /// <remarks>
        /// If you have a long-term, renewable lease on your Internet domain name, then you can feel free to use your website's address.
        /// </remarks>
        IId Id { get; set; }

        /// <summary>
        /// Gets or sets the text contains a human readable title for the feed.
        /// </summary>
        /// <remarks>
        /// This is often the same as the title of the associated website. This value should not be blank.
        /// </remarks>
        IText Title { get; set; }

        /// <summary>
        /// Gets or sets last time when the feed was modified in a significant way.
        /// </summary>
        DateTime Updated { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets one or more authors of the feed. A feed must contain at least one author element unless all of the entry elements contain at least one author element. More info [here](http://atomenabled.org/developers/syndication/#person).
        /// </summary>
        List<IPerson> Authors { get; set; }

        /// <summary>
        /// Gets or sets a related Web page. The type of relation is defined by the <c>Rel</c> property. A feed is limited to one alternate per <c>Type</c> and <c>HrefLang</c>. A feed should contain a link back to the feed itself. More info [here](http://atomenabled.org/developers/syndication/#link).
        /// </summary>
        ILink Link { get; set; }

        /// <summary>
        /// Gets or sets one or more categories that the feed belong to. More info [here](http://atomenabled.org/developers/syndication/#category).
        /// </summary>
        List<ICategory> Categories { get; set; }

        /// <summary>
        /// Gets or sets one or more contributors to the feed. More info [here](http://atomenabled.org/developers/syndication/#person).
        /// </summary>
        List<IPerson> Contributors { get; set; }

        /// <summary>
        /// Gets or sets the software used to generate the feed, for debugging and other purposes. Both the uri and version attributes are optional.
        /// </summary>
        IGenerator Generator { get; set; }

        /// <summary>
        /// Gets or sets a small image which provides iconic visual identification for the feed. Icons should be square.
        /// </summary>
        IIcon Icon { get; set; }

        /// <summary>
        /// Gets or sets a larger image which provides visual identification for the feed. Images should be twice as wide as they are tall.
        /// </summary>
        ILogo Logo { get; set; }

        /// <summary>
        /// Gets or sets information about rights, e.g. copyrights, held in and over the feed. More info [here](http://atomenabled.org/developers/syndication/#text).
        /// </summary>
        IText Rights { get; set; }

        /// <summary>
        /// Gets or sets a human-readable description or subtitle for the feed. More info [here](http://atomenabled.org/developers/syndication/#text).
        /// </summary>
        IText SubTitle { get; set; }

        /// <summary>
        /// Gets or sets the list of entries acting as containers for metadata and data associated with the entry. This element can appear as a child of the atom:feed element, or it can appear as the document (i.e., top-level) element of a stand-alone Atom Entry Document.
        /// </summary>
        List<IEntry> Entries { get; set; }

        #endregion Properties - Optional
    }
}