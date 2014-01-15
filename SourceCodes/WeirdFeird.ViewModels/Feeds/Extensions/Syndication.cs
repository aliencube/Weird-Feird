using Aliencube.WeirdFeird.ViewModels.Enums;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Extensions;
using System;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Extensions
{
    /// <summary>
    /// This represents an entity for Syndication that provides syndication hints to aggregators and others picking up this RDF Site Summary (RSS) feed regarding how often it is updated. For example, if you updated your file twice an hour, updatePeriod would be "hourly" and updateFrequency would be "2". The syndication module borrows from Ian Davis's [Open Content Syndication (OCS)](http://internetalchemy.org/ocs/) directory format. It supercedes the RSS 0.91 skipDay and skipHour elements.
    /// </summary>
    public class Syndication : ISyndication
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the Syndication class.
        /// </summary>
        public Syndication()
        {
            this.UpdatePeriod = UpdatePeriod.Daily;
            this.UpdateFrequency = 1;
        }

        #endregion Constructors

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the period over which the channel format is updated.
        /// </summary>
        /// <remarks>
        /// Acceptable values are: hourly, daily, weekly, monthly, yearly. If omitted, daily is assumed.
        /// </remarks>
        public UpdatePeriod UpdatePeriod { get; set; }

        /// <summary>
        /// Get or sets the frequency of updates in relation to the update period.
        /// </summary>
        /// <remarks>
        /// A positive integer indicates how many times in that period the channel is updated. For example, an updatePeriod of daily, and an updateFrequency of 2 indicates the channel format is updated twice daily. If omitted a value of 1 is assumed.
        /// </remarks>
        public int? UpdateFrequency { get; set; }

        /// <summary>
        /// Gets or sets the definition of a base date to be used in concert with updatePeriod and updateFrequency to calculate the publishing schedule.
        /// </summary>
        /// <remarks>
        /// The date format takes the form: yyyy-mm-ddThh:mm.
        /// </remarks>
        public DateTime? UpdateBase { get; set; }

        #endregion Properties - Optional
    }
}