using System;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress
{
    /// <summary>
    /// This represents an entity for RDF Site Summary 1.0 Modules: Syndication.
    /// </summary>
    /// <remarks>This entity is based on http://web.resource.org/rss/1.0/modules/syndication/ .</remarks>
    public class Syndication
    {
        /// <summary>
        /// Gets or sets the version of the module.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the update period that describes the period over which the channel format is updated.
        /// </summary>
        public UpdatePeriod UpdatePeriod { get; set; }

        /// <summary>
        /// Gets or sets the update frequency that is used to describe the frequency of updates in relation to
        /// the update period. This must be positive integer.
        /// </summary>
        public int? UpdateFrequency { get; set; }

        /// <summary>
        /// Gets or sets the base date  to be used in concert with UpdatePeriod and UpdateFrequency to calculate the publishing schedule.
        /// </summary>
        public DateTime? UpdateBase { get; set; }
    }
}