namespace Aliencube.WeirdFeird.ViewModels.Feeds.Extensions
{
    /// <summary>
    /// This represents an entity for Well-formed Web.
    /// </summary>
    public class WellFormedWeb
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the first element to appear in this namespace. This element appears in RSS feeds and contains the URI that comment entries are to be POSTed to.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the second element to appear in this namespace. This element also appears in RSS feeds and contains the URI of the RSS feed for comments on that Item. This is documented in [Chris Sells' Specification](http://www.sellsbrothers.com/spout/default.aspx?content=archive.htm#exposingRssComments). Note that for quite a while this page has had a typo and erroneously referred to this element as 'commentRSS' as opposed to the correct 'commentRss'. Feed consumers should be aware that they may run into both spellings in the wild. Please see [this page](http://intertwingly.net/blog/2006/04/15/commentRss) for more information.
        /// </summary>
        public string CommentRss { get; set; }

        #endregion Properties - Optional
    }
}