namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity that allows processes to register with a cloud to be notified of updates to the channel, implementing a lightweight publish-subscribe protocol for RSS feeds.
    /// </summary>
    public class Cloud
    {
        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or stes the port number.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the procedure to call.
        /// </summary>
        public string RegisterProcedure { get; set; }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        public string Protocol { get; set; }
    }
}