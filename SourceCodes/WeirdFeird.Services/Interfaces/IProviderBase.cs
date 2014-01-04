using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the ProviderBase class.
    /// </summary>
    public interface IProviderBase : IDisposable
    {
        #region Methods

        /// <summary>
        /// Gets the XML feed contents from given feed URL asynchronously.
        /// </summary>
        /// <param name="feedUrl">Feed URL.</param>
        /// <returns>Returns the XML feed contents from given feed URL asynchronously.</returns>
        Task<XDocument> GetFeedXmlAsync(string feedUrl);

        #endregion
    }
}
