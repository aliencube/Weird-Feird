using Aliencube.WeirdFeird.ViewModels.Feeds.Atom;
using Aliencube.WeirdFeird.ViewModels.Feeds.Extensions;
using Aliencube.WeirdFeird.ViewModels.Feeds.Rss;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress
{
    /// <summary>
    /// This represents the channel entity for Wordpress.
    /// </summary>
    public partial class WordpressChannel : Channel
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the ATOM Link instance.
        /// </summary>
        public Link AtomLink { get; set; }

        /// <summary>
        /// Gets or sets the Syndication instance.
        /// </summary>
        public Syndication Syndication { get; set; }

        /// <summary>
        /// Gets or sets the number of items. An item may represent a "story" -- much like a story in a newspaper or magazine; if so its description is a synopsis of the story, and the link points to the full story. An item may also be complete in itself, if so, the description contains the text (entity-encoded HTML is allowed; see [examples](http://www.rssboard.org/rss-encoding-examples)), and the link and title may be omitted. All elements of an item are optional, however at least one of title or description must be present.
        /// </summary>
        public new IList<WordpressItem> Items { get; set; }

        #endregion Properties - Optional
    }
}