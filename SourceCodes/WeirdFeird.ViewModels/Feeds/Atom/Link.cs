using System;
using System.Xml.Linq;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Atom;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Atom
{
    /// <summary>
    /// This represents an entity patterned after HTML's <c>link</c> element.
    /// </summary>
    public class Link : CommonAttributes, ILink
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the URI of the referenced resource (typically a Web page).
        /// </summary>
        public string Href { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets a single link relationship type.
        /// </summary>
        /// <remarks>
        /// It can be a full URI (see [extensibility](http://atomenabled.org/developers/syndication/#extensibility)), or one of the predefined values (default=alternate)
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Alternate</term>
        ///             <description>An alternate representation of the entry or feed, for example a permalink to the html version of the entry, or the front page of the weblog.</description>
        ///         </item>
        ///         <item>
        ///             <term>Enclosure</term>
        ///             <description>A related resource which is potentially large in size and might require special handling, for example an audio or video recording.</description>
        ///         </item>
        ///         <item>
        ///             <term>Related</term>
        ///             <description>A document related to the entry or feed.</description>
        ///         </item>
        ///         <item>
        ///             <term>Self</term>
        ///             <description>The feed itself.</description>
        ///         </item>
        ///         <item>
        ///             <term>Via</term>
        ///             <description>The source of the information provided in the entry.</description>
        ///         </item>
        ///     </list>
        /// </remarks>
        public string Rel { get; set; }

        /// <summary>
        /// Gets or sets the media type of the resource.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the language of the referenced resource.
        /// </summary>
        public string HrefLang { get; set; }

        /// <summary>
        /// Gets or sets human readable information about the link, typically for display purposes.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the length of the resource, in bytes.
        /// </summary>
        public int? Length { get; set; }

        #endregion Properties - Optional
    }
}