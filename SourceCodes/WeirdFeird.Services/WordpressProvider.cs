using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aliencube.WeirdFeird.Configurations.Interfaces;

namespace Aliencube.WeirdFeird.Services
{
    /// <summary>
    /// This represents the provider entity for Wordpress feed.
    /// </summary>
    public partial class WordpressProvider : RssProvider
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the WordpressProvider class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        public WordpressProvider(IWeirdFeirdSettings settings)
            :base(settings)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of XML contents from given feed URLs asynchronously.
        /// </summary>
        /// <param name="feedUrls">List of feed URLs.</param>
        /// <returns>Returns the list of XML contents from given feed URLs asynchronously.</returns>
        public override async Task<List<string>> GetContentsAsync(IEnumerable<string> feedUrls)
        {
            var contents = new List<string>();
            using (var handler = new HttpClientHandler() { UseProxy = this.Settings.Proxy.Use })
            {
                //  Sets the proxy server, if it is used.
                if (handler.UseProxy)
                {
                    handler.Proxy = new WebProxy(this.Settings.Proxy.Url);
                }

                using (var client = new HttpClient(handler))
                {
                    foreach (var feedUrl in feedUrls)
                    {
                        var content = await client.GetStringAsync(feedUrl);
                        contents.Add(content);
                    }
                }
            }
            return contents;
        }

        #endregion

    }
}
