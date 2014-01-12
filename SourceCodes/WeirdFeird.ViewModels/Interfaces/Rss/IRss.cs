using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Aliencube.WeirdFeird.ViewModels.Enums;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
    /// <summary>
    /// This provides interfaces to the Rss class.
    /// </summary>
    public interface IRss
    {
        #region Properties - Required
        /// <summary>
        /// Gets or sets the RSS version.
        /// </summary>
        /// <remarks>It is always <c>2.0</c>.</remarks>
        decimal Version { get; set; }

        /// <summary>
        /// Gets or sets the RSS channel instance.
        /// </summary>
        IChannel Channel { get; set; }
        #endregion
    }

    /// <summary>
    /// This provides interfaces to the Channel class.
    /// </summary>
    public interface IChannel
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the name of the channel. It's how people refer to your service. If you have an HTML website that contains the same information as your RSS file, the title of your channel should be the same as the title of your website.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL to the HTML website corresponding to the channel.
        /// </summary>
        string Link { get; set; }

        /// <summary>
        /// Gets or sets the phrase or sentence describing the channel.
        /// </summary>
        string Description { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the language the channel is written in. This allows aggregators to group all Italian language sites, for example, on a single page. A list of allowable values for this element, as provided by Netscape, is [here](http://www.rssboard.org/rss-language-codes). You may also use [values defined](http://www.w3.org/TR/REC-html40/struct/dirlang.html#langcodes) by the W3C.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        /// Gets or sets the copyright notice for content in the channel.
        /// </summary>
        string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the email address for person responsible for editorial content.
        /// </summary>
        string ManagingEditor { get; set; }

        /// <summary>
        /// Gets or sets the email address for person responsible for technical issues relating to channel.
        /// </summary>
        string WebMaster { get; set; }

        /// <summary>
        /// Gets or sets the publication date for the content in the channel. All date-times in RSS conform to the Date and Time Specification of [RFC 822](http://asg.web.cmu.edu/rfc/rfc822.html), with the exception that the year may be expressed with two characters or four characters (four preferred).
        /// </summary>
        DateTime? PubDate { get; set; }

        /// <summary>
        /// Gets or sets the last time the content of the channel changed.
        /// </summary>
        DateTime? LastBuildDate { get; set; }

        /// <summary>
        /// Gets or sets one or more categories that the channel belongs to. Follows the same rules as the item-level [category](http://www.rssboard.org/rss-specification#ltcategorygtSubelementOfLtitemgt) element. More [info](http://www.rssboard.org/rss-specification#syndic8).
        /// </summary>
        IList<ICategory> Categories { get; set; }

        /// <summary>
        /// Gets or sets the string indicating the program used to generate the channel.
        /// </summary>
        string Generator { get; set; }

        /// <summary>
        /// Gets or sets the URL that points to the [documentation](http://www.rssboard.org/rss-specification) for the format used in the RSS file. It's probably a pointer to this page. It's for people who might stumble across an RSS file on a Web server 25 years from now and wonder what it is.
        /// </summary>
        /// <remarks>It is always <c>http://www.rssboard.org/rss-specification</c>.</remarks>
        string Docs { get; set; }

        /// <summary>
        /// Gets or sets a process to register with a cloud to be notified of updates to the channel, implementing a lightweight publish-subscribe protocol for RSS feeds. More info [here](http://www.rssboard.org/rss-specification#ltcloudgtSubelementOfLtchannelgt).
        /// </summary>
        ICloud Cloud { get; set; }

        /// <summary>
        /// Gets or sets the TTL value which is a number of minutes that indicates how long a channel can be cached before refreshing from the source. More info [here](http://www.rssboard.org/rss-specification#ltttlgtSubelementOfLtchannelgt).
        /// </summary>
        int? Ttl { get; set; }

        /// <summary>
        /// Gets or sets the GIF, JPEG or PNG image that can be displayed with the channel. More info [here](http://www.rssboard.org/rss-specification#ltimagegtSubelementOfLtchannelgt).
        /// </summary>
        IImage Image { get; set; }

        /// <summary>
        /// Gets or sets the the [PICS](http://www.w3.org/PICS/) rating for the channel.
        /// </summary>
        string Rating { get; set; }

        /// <summary>
        /// Gets or sets the text input box that can be displayed with the channel. More info [here](http://www.rssboard.org/rss-specification#lttextinputgtSubelementOfLtchannelgt).
        /// </summary>
        ITextInput TextInput { get; set; }

        /// <summary>
        /// Gets or sets the hint for aggregators telling them which hours they can skip. This element contains up to 24 hours sub-elements whose value is a number between 0 and 23, representing a time in GMT, when aggregators, if they support the feature, may not read the channel on hours listed in the <c>SkipHours</c> instance. The hour beginning at midnight is hour zero.
        /// </summary>
        IList<int> SkipHours { get; set; }

        /// <summary>
        /// Gets or sets the hint for aggregators telling them which days they can skip. This element contains up to seven days sub-elements whose value is Monday, Tuesday, Wednesday, Thursday, Friday, Saturday or Sunday. Aggregators may not read the channel during days listed in the <c>SkipDays</c> instance.
        /// </summary>
        IList<SkipDay> SkipDays { get; set; }

        /// <summary>
        /// Gets or sets the number of items. An item may represent a "story" -- much like a story in a newspaper or magazine; if so its description is a synopsis of the story, and the link points to the full story. An item may also be complete in itself, if so, the description contains the text (entity-encoded HTML is allowed; see [examples](http://www.rssboard.org/rss-encoding-examples)), and the link and title may be omitted. All elements of an item are optional, however at least one of title or description must be present.
        /// </summary>
        IList<IItem> Items { get; set; }

        #endregion Properties - Optional
    }

    /// <summary>
    /// This provides interfaces to the Category class.
    /// </summary>
    public interface ICategory
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the value of the category.
        /// </summary>
        string Value { get; set; }

        #endregion
        #region Properties - Optional
        /// <summary>
        /// Gets or sets the URL of the category.
        /// </summary>
        string Domain { get; set; }
        #endregion

    }

    /// <summary>
    /// This provides interfaces to the Cloud class.
    /// </summary>
    public interface ICloud
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        string Domain { get; set; }

        /// <summary>
        /// Gets or sets the port number.
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// Gets or sets the method/function to run.
        /// </summary>
        string RegisterProcedure { get; set; }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        Protocol Protocol { get; set; }

        #endregion Properties - Required
    }

    /// <summary>
    /// This provides interfaces to the Image class.
    /// </summary>
    public interface IImage
    {
        #region Properties - Required
        /// <summary>
        /// Gets or sets the URL of a GIF, JPEG or PNG image that represents the channel.
        /// </summary>
        string Url { get; set; }
        /// <summary>
        /// Gets or sets the description of the image which is used in the <c>alt</c> attribute of the HTML <c>img</c> tag when the channel is rendered in HTML.
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// Gets or sets the URL of the site, when the channel is rendered, the image is a link to the site. (Note, in practice the image <c>Title</c> and <c>Link</c> should have the same value as the channel's <c>Title</c> and <c>Link</c>.
        /// </summary>
        string Link { get; set; }

        #endregion
        #region Properties - Optional
        /// <summary>
        /// Gets or sets the width of the image in pixels. Its maximum value is 144. Default value is 88.
        /// </summary>
        int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the imag in pixels. Its maxinum value is 400. Default value is 31.
        /// </summary>
        int? Height { get; set; }

        /// <summary>
        /// Gets or sets the text that is included in the <c>Title</c> property of the <c>Link</c> formed around the image in the HTML rendering.
        /// </summary>
        string Description { get; set; }

        #endregion
    }

    /// <summary>
    /// This provides interfaces to the TextInput class.
    /// </summary>
    public interface ITextInput
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the label of the Submit button in the text input area.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the eplanation of the text input area.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the text object in the text input area.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL of the CGI script that processes text input requests.
        /// </summary>
        string Link { get; set; }

        #endregion Properties - Required
    }

    /// <summary>
    /// This provides interfaces to the Item class.
    /// </summary>
    public interface IItem
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the title of the item.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL of the item.
        /// </summary>
        string Link { get; set; }

        /// <summary>
        /// Gets or sets the item synopsis.
        /// </summary>
        string Description { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the email address of the author of the item. [More](http://www.rssboard.org/rss-specification#ltauthorgtSubelementOfLtitemgt).
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Gets or sets one or more categories that the item belongs to.
        /// </summary>
        IList<ICategory> Categories { get; set; }

        /// <summary>
        /// Gets or sets the URL of a page for comments relating to the item. [More](http://www.rssboard.org/rss-specification#ltcommentsgtSubelementOfLtitemgt).
        /// </summary>
        string Comments { get; set; }

        /// <summary>
        /// Gets or sets the media object that is attached to the item. [More](http://www.rssboard.org/rss-specification#ltenclosuregtSubelementOfLtitemgt).
        /// </summary>
        IEnclosure Enclosure { get; set; }

        /// <summary>
        /// Gets or sets the guid or permalink URL for this entry. [More](http://www.rssboard.org/rss-specification#ltguidgtSubelementOfLtitemgt).
        /// </summary>
        IGuid Guid { get; set; }

        /// <summary>
        /// Gets or sets the date when the item was published. [More](http://www.rssboard.org/rss-specification#ltpubdategtSubelementOfLtitemgt).
        /// </summary>
        DateTime? PubDate { get; set; }

        /// <summary>
        /// Gets or sets the RSS channel that the item came from. [More](http://www.rssboard.org/rss-specification#ltsourcegtSubelementOfLtitemgt).
        /// </summary>
        ISource Source { get; set; }

        #endregion Properties - Optional
    }

    /// <summary>
    /// This provides interfaces to the Enclosure class.
    /// </summary>
    public interface IEnclosure
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the URL where the enclosure is located.
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the size in bytes.
        /// </summary>
        int Length { get; set; }

        /// <summary>
        /// Gets or sets the MIME media-type of the enclosure
        /// </summary>
        string Type { get; set; }

        #endregion Properties - Required
    }

    /// <summary>
    /// This provides interfaces to the Guid class.
    /// </summary>
    public interface IGuid
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the permalink URL.
        /// </summary>
        string Value { get; set; }
        
        #endregion

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the value that specifies whether the GUID represents a permalink or not.
        /// </summary>
        bool? IsPermaLink { get; set; }

        #endregion Properties - Optional
    }

    /// <summary>
    /// This provides interfaces to the Source class.
    /// </summary>
    public interface ISource
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the value that describes the source URL.
        /// </summary>
        string Value { get; set; }

        #endregion
        
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the URL where the RSS channel that the item came from.
        /// </summary>
        string Url { get; set; }

        #endregion Properties - Optional
    }
}
