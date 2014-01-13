using Aliencube.WeirdFeird.ViewModels.Enums;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Rss;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity that allows processes to register with a cloud to be notified of updates to the channel, implementing a lightweight publish-subscribe protocol for RSS feeds.
    /// </summary>
    public class Cloud : ICloud
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the port number.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the method/function to run.
        /// </summary>
        public string RegisterProcedure { get; set; }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        public Protocol Protocol { get; set; }

        #endregion Properties - Required
    }
}