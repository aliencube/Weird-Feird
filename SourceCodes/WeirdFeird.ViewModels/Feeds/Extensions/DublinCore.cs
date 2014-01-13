using System;
using Aliencube.WeirdFeird.ViewModels.Enums;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Extensions;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Extensions
{
    /// <summary>
    /// This represents an entity for DublinCore metadata element set.
    /// </summary>
    public class DublinCore : IDublinCore
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets an entity responsible for making contributions to the resource.
        /// </summary>
        /// <remarks>
        /// Examples of a Contributor include a person, an organization, or a service. Typically, the name of a Contributor should be used to indicate the entity.
        /// </remarks>
        public string Contrubutor { get; set; }

        /// <summary>
        /// Gets or sets the spatial or temporal topic of the resource, the spatial applicability of the resource, or the jurisdiction under which the resource is relevant.
        /// </summary>
        /// <remarks>
        /// Spatial topic and spatial applicability may be a named place or a location specified by its geographic coordinates. Temporal topic may be a named period, date, or date range. A jurisdiction may be a named administrative entity or a geographic place to which the resource applies. Recommended best practice is to use a controlled vocabulary such as the Thesaurus of Geographic Names [TGN]. Where appropriate, named places or time periods can be used in preference to numeric identifiers such as sets of coordinates or date ranges.
        /// </remarks>
        public string Coverage { get; set; }

        /// <summary>
        /// Gets or sets an entity primarily responsible for making the resource.
        /// </summary>
        /// <remarks>
        /// Examples of a Creator include a person, an organization, or a service. Typically, the name of a Creator should be used to indicate the entity.
        /// </remarks>
        public string Creator { get; set; }

        /// <summary>
        /// Gets or sets a point or period of time associated with an event in the lifecycle of the resource.
        /// </summary>
        /// <remarks>
        /// Date may be used to express temporal information at any level of granularity. Recommended best practice is to use an encoding scheme, such as the W3CDTF profile of ISO 8601 [W3CDTF](http://www.w3.org/TR/NOTE-datetime).
        /// </remarks>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets an account of the resource.
        /// </summary>
        /// <remarks>
        /// Description may include but is not limited to: an abstract, a table of contents, a graphical representation, or a free-text account of the resource.
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the file format, physical medium, or dimensions of the resource.
        /// </summary>
        /// <remarks>
        /// Examples of dimensions include size and duration. Recommended best practice is to use a controlled vocabulary such as the list of Internet Media Types [MIME](http://www.iana.org/assignments/media-types/).
        /// </remarks>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets an unambiguous reference to the resource within a given context.
        /// </summary>
        /// <remarks>
        /// Recommended best practice is to identify the resource by means of a string conforming to a formal identification system.
        /// </remarks>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets a language of the resource.
        /// </summary>
        /// <remarks>
        /// Recommended best practice is to use a controlled vocabulary such as RFC 4646 [RFC4646](http://www.ietf.org/rfc/rfc4646.txt).
        /// </remarks>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets an entity responsible for making the resource available.
        /// </summary>
        /// <remarks>
        /// Examples of a Publisher include a person, an organization, or a service. Typically, the name of a Publisher should be used to indicate the entity.
        /// </remarks>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets a related resource.
        /// </summary>
        /// <remarks>
        /// Recommended best practice is to identify the related resource by means of a string conforming to a formal identification system.
        /// </remarks>
        public string Relation { get; set; }

        /// <summary>
        /// Gets or sets information about rights held in and over the resource.
        /// </summary>
        /// <remarks>
        /// Typically, rights information includes a statement about various property rights associated with the resource, including intellectual property rights.
        /// </remarks>
        public string Rights { get; set; }

        /// <summary>
        /// Gets or sets a related resource from which the described resource is derived.
        /// </summary>
        /// <remarks>
        /// The described resource may be derived from the related resource in whole or in part. Recommended best practice is to identify the related resource by means of a string conforming to a formal identification system.
        /// </remarks>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the topic of the resource.
        /// </summary>
        /// <remarks>
        /// Typically, the subject will be represented using keywords, key phrases, or classification codes. Recommended best practice is to use a controlled vocabulary.
        /// </remarks>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets a name given to the resource.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the nature or genre of the resource.
        /// </summary>
        public DcmiType Type { get; set; }

        #endregion Properties - Optional
    }
}