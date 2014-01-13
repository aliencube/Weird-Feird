namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
    /// <summary>
    /// This provides interfaces to the Rss class.
    /// </summary>
    public interface IRss
    {
        #region Properties - Required

        /// <summary>
        /// Gets the RSS version.
        /// </summary>
        /// <remarks>It is always <c>2.0</c>.</remarks>
        decimal Version { get; }

        /// <summary>
        /// Gets or sets the RSS channel instance.
        /// </summary>
        IChannel Channel { get; set; }

        #endregion Properties - Required
    }
}