namespace Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress
{
    /// <summary>
    /// This represents an entity indicated by &lt;atom:link&gt; element in a Wordpress feed.
    /// </summary>
    public class FeedLink
    {
        /// <summary>
        /// Gets or sets the link URL.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the relation indicating REL attribute declared within the &lt;atom:link&gt; element.
        /// </summary>
        public string Rel { get; set; }

        /// <summary>
        /// Gets or sets the standard MIME type of the link instance.
        /// </summary>
        public string Type { get; set; }
    }
}