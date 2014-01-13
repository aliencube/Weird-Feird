using Aliencube.WeirdFeird.ViewModels.Enums;
using System;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Extensions
{
    /// <summary>
    /// This provides interfaces to the Syndication class.
    /// </summary>
    public interface ISyndication
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the period over which the channel format is updated.
        /// </summary>
        /// <remarks>
        /// Acceptable values are: hourly, daily, weekly, monthly, yearly. If omitted, daily is assumed.
        /// </remarks>
        UpdatePeriod UpdatePeriod { get; set; }

        /// <summary>
        /// Get or sets the frequency of updates in relation to the update period.
        /// </summary>
        /// <remarks>
        /// A positive integer indicates how many times in that period the channel is updated. For example, an updatePeriod of daily, and an updateFrequency of 2 indicates the channel format is updated twice daily. If omitted a value of 1 is assumed.
        /// </remarks>
        int? UpdateFrequency { get; set; }

        /// <summary>
        /// Gets or sets the definition of a base date to be used in concert with updatePeriod and updateFrequency to calculate the publishing schedule.
        /// </summary>
        /// <remarks>
        /// The date format takes the form: yyyy-mm-ddThh:mm.
        /// </remarks>
        DateTime? UpdateBase { get; set; }

        #endregion Properties - Optional
    }
}