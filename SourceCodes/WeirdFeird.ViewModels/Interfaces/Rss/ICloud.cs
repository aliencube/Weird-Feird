using Aliencube.WeirdFeird.ViewModels.Enums;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Rss
{
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
}