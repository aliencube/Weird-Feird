using Aliencube.WeirdFeird.ViewModels.Enums;
using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents the channel element of the RSS feed. This must be inherited.
    /// </summary>
    public abstract class Channel
    {
        #region Constructors

        protected Channel()
        {
            this.Docs = "http://www.rssboard.org/rss-specification";
        }

        #endregion Constructors

        #region Properties - Required

        /// <summary>
        /// Gets or sets the name of the channel. It's how people refer to your service. If you have an HTML website that contains the same information as your RSS file, the title of your channel should be the same as the title of your website.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL to the HTML website corresponding to the channel.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the phrase or sentence describing the channel.
        /// </summary>
        public string Description { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the language the channel is written in. This allows aggregators to group all Italian language sites, for example, on a single page. A list of allowable values for this element, as provided by Netscape, is [here](http://www.rssboard.org/rss-language-codes). You may also use [values defined](http://www.w3.org/TR/REC-html40/struct/dirlang.html#langcodes) by the W3C.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the copyright notice for content in the channel.
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the email address for person responsible for editorial content.
        /// </summary>
        public string ManagingEditor { get; set; }

        /// <summary>
        /// Gets or sets the email address for person responsible for technical issues relating to channel.
        /// </summary>
        public string WebMaster { get; set; }

        /// <summary>
        /// Gets or sets the publication date for the content in the channel. This is UTC value. All date-times in RSS conform to the Date and Time Specification of [RFC 822](http://asg.web.cmu.edu/rfc/rfc822.html), with the exception that the year may be expressed with two characters or four characters (four preferred).
        /// </summary>
        public DateTime? PubDate { get; set; }

        /// <summary>
        /// Gets or sets the last time the content of the channel changed. This is UTC value.
        /// </summary>
        public DateTime? LastBuildDate { get; set; }

        /// <summary>
        /// Gets or sets one or more categories that the channel belongs to. Follows the same rules as the item-level [category](http://www.rssboard.org/rss-specification#ltcategorygtSubelementOfLtitemgt) element. More [info](http://www.rssboard.org/rss-specification#syndic8).
        /// </summary>
        public IList<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the string indicating the program used to generate the channel.
        /// </summary>
        public string Generator { get; set; }

        /// <summary>
        /// Gets the URL that points to the [documentation](http://www.rssboard.org/rss-specification) for the format used in the RSS file. It's probably a pointer to this page. It's for people who might stumble across an RSS file on a Web server 25 years from now and wonder what it is.
        /// </summary>
        /// <remarks>It is always <c>http://www.rssboard.org/rss-specification</c>.</remarks>
        public string Docs { get; private set; }

        /// <summary>
        /// Gets or sets a process to register with a cloud to be notified of updates to the channel, implementing a lightweight publish-subscribe protocol for RSS feeds. More info [here](http://www.rssboard.org/rss-specification#ltcloudgtSubelementOfLtchannelgt).
        /// </summary>
        public Cloud Cloud { get; set; }

        /// <summary>
        /// Gets or sets the TTL value which is a number of minutes that indicates how long a channel can be cached before refreshing from the source. More info [here](http://www.rssboard.org/rss-specification#ltttlgtSubelementOfLtchannelgt).
        /// </summary>
        public int? Ttl { get; set; }

        /// <summary>
        /// Gets or sets the GIF, JPEG or PNG image that can be displayed with the channel. More info [here](http://www.rssboard.org/rss-specification#ltimagegtSubelementOfLtchannelgt).
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the the [PICS](http://www.w3.org/PICS/) rating for the channel.
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the text input box that can be displayed with the channel. More info [here](http://www.rssboard.org/rss-specification#lttextinputgtSubelementOfLtchannelgt).
        /// </summary>
        public TextInput TextInput { get; set; }

        /// <summary>
        /// Gets or sets the hint for aggregators telling them which hours they can skip. This element contains up to 24 hours sub-elements whose value is a number between 0 and 23, representing a time in GMT, when aggregators, if they support the feature, may not read the channel on hours listed in the <c>SkipHours</c> instance. The hour beginning at midnight is hour zero.
        /// </summary>
        public IList<int> SkipHours { get; set; }

        /// <summary>
        /// Gets or sets the hint for aggregators telling them which days they can skip. This element contains up to seven days sub-elements whose value is Monday, Tuesday, Wednesday, Thursday, Friday, Saturday or Sunday. Aggregators may not read the channel during days listed in the <c>SkipDays</c> instance.
        /// </summary>
        public IList<SkipDay> SkipDays { get; set; }

        /// <summary>
        /// Gets or sets the number of items. An item may represent a "story" -- much like a story in a newspaper or magazine; if so its description is a synopsis of the story, and the link points to the full story. An item may also be complete in itself, if so, the description contains the text (entity-encoded HTML is allowed; see [examples](http://www.rssboard.org/rss-encoding-examples)), and the link and title may be omitted. All elements of an item are optional, however at least one of title or description must be present.
        /// </summary>
        public IList<EntryItem> Items { get; set; }

        #endregion Properties - Optional
    }
}