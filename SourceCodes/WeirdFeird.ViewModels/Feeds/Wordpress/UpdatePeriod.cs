using System;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress
{
    /// <summary>
    /// This describes the period over which the channel format is updated.
    /// </summary>
    [Flags]
    public enum UpdatePeriod
    {
        /// <summary>
        /// Indicates no update period is identified.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Indicates that the update period is hourly.
        /// </summary>
        Hourly = 1,

        /// <summary>
        /// Indicates that the update period is daily.
        /// </summary>
        Daily = 2,

        /// <summary>
        /// Indicates that the update period is weekly.
        /// </summary>
        Weekly = 4,

        /// <summary>
        /// Indicates that the update period is monthly.
        /// </summary>
        Monthly = 8,

        /// <summary>
        /// Indicates that the update period is yearly.
        /// </summary>
        Yearly = 16
    }
}