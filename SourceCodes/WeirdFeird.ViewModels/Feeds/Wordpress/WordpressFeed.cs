using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliencube.WeirdFeird.ViewModels.Feeds.Rss;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Wordpress
{
    /// <summary>
    /// This represents an entity for a Wordpress feed.
    /// </summary>
    public class WordpressFeed : RssFeed
    {
        /// <summary>
        /// Gets or sets the <c>FeedLink</c> instance.
        /// </summary>
        public FeedLink FeedLink { get; set; }

        /// <summary>
        /// Gets or sets the RDF site summary syndication module instance.
        /// </summary>
        public Syndication Syndication { get; set; }
    }
}
