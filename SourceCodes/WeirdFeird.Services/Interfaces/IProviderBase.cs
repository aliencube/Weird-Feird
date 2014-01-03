using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliencube.WeirdFeird.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the ProviderBase class.
    /// </summary>
    public interface IProviderBase : IDisposable
    {
        #region Methods

        /// <summary>
        /// Gets the list of XML contents from given feed URLs asynchronously.
        /// </summary>
        /// <param name="feedUrls">List of feed URLs.</param>
        /// <returns>Returns the list of XML contents from given feed URLs asynchronously.</returns>
        Task<List<string>> GetContentsAsync(IEnumerable<string> feedUrls);

        #endregion
    }
}
