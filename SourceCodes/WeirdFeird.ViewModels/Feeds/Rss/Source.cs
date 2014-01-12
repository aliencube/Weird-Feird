namespace Aliencube.WeirdFeird.ViewModels.Feeds.Rss
{
    /// <summary>
    /// This represents an entity indicating which RSS channel/feed the <c>Item</c> instance came from.
    /// </summary>
    public class Source
    {
        //Gets or sets the RSS channel/feed URL.
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the RSS channel/feed title.
        /// </summary>
        public string Text { get; set; }
    }
}