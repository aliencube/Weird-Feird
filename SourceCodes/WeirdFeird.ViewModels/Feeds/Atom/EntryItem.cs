using Aliencube.WeirdFeird.ViewModels.Interfaces.Atom;
using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Atom
{
    /// <summary>
    /// This represents an entity of feed item, which is an individual entry, acting as a container for metadata and data associated with the entry.
    /// </summary>
    public abstract class EntryItem : CommonAttributes, IEntry
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets a universally unique and permanent URI. Suggestions on how to make a good id can be found [here](http://diveintomark.org/archives/2004/05/28/howto-atom-id). Two entries in a feed can have the same value for id if they represent the same entry at different points in time.
        /// </summary>
        public Id Id { get; set; }

        /// <summary>
        /// Gets or sets a human readable title for the entry. This value should not be blank.
        /// </summary>
        public Text Title { get; set; }

        /// <summary>
        /// Gets or sets the last time when the entry was modified in a significant way. This value need not change after a typo is fixed, only after a substantial modification. Generally, different entries in a feed will have different updated timestamps.
        /// </summary>
        public DateTime Updated { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets one or more authors of the entry. An entry may have multiple authors. An entry must contain at least one author element unless there is an author element in the enclosing feed, or there is an author element in the enclosed source element. More info [here](http://atomenabled.org/developers/syndication/#person).
        /// </summary>
        public IList<Person> Authors { get; set; }

        /// <summary>
        /// Gets or sets the value that contains or links to the complete content of the entry. Content must be provided if there is no alternate link, and should be provided if there is no summary. More info [here](http://atomenabled.org/developers/syndication/#contentElement).
        /// </summary>
        public Content Content { get; set; }

        /// <summary>
        /// Gets or sets a related Web page. The type of relation is defined by the rel attribute. An entry is limited to one alternate per type and hreflang. An entry must contain an alternate link if there is no content element. More info [here](http://atomenabled.org/developers/syndication/#link).
        /// </summary>
        public Link Link { get; set; }

        /// <summary>
        /// Gets or sets a short summary, abstract, or excerpt of the entry. Summary should be provided if there either is no content provided for the entry, or that content is not inline (i.e., contains a src attribute), or if the content is encoded in base64. More info [here](http://atomenabled.org/developers/syndication/#text).
        /// </summary>
        public Text Summary { get; set; }

        /// <summary>
        /// Gets or sets one or more categories that the entry belongs to. More info [here](http://atomenabled.org/developers/syndication/#category).
        /// </summary>
        public IList<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets one or more contributors to the entry. More info [here](http://atomenabled.org/developers/syndication/#person).
        /// </summary>
        public IList<Person> Contributors { get; set; }

        /// <summary>
        /// Gets or sets the time of the initial creation or first availability of the entry.
        /// </summary>
        public DateTime? Published { get; set; }

        /// <summary>
        /// Gets or sets the source value.
        /// </summary>
        /// <remarks>
        /// If an entry is copied from one feed into another feed, then the source feed's metadata (all child elements of feed other than the entry elements) should be preserved if the source feed contains any of the child elements author, contributor, rights, or category and those child elements are not present in the source entry.
        /// </remarks>
        public Source Source { get; set; }

        /// <summary>
        /// Gets or sets information about rights, e.g. copyrights, held in and over the entry. More info [here](http://atomenabled.org/developers/syndication/#text).
        /// </summary>
        public Text Rights { get; set; }

        #endregion Properties - Optional
    }
}