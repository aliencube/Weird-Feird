using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Services.Interfaces;

namespace Aliencube.WeirdFeird.Services
{
    /// <summary>
    /// This represents the base provider entity.
    /// This must be inherited.
    /// </summary>
    public abstract class ProviderBase : IProviderBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the ProviderBase class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        protected ProviderBase(IWeirdFeirdSettings settings)
        {
            this.Settings = settings;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the configuration settings instance for Weird-Feird.
        /// </summary>
        protected IWeirdFeirdSettings Settings { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of XML contents from given feed URLs asynchronously.
        /// </summary>
        /// <param name="feedUrls">List of feed URLs.</param>
        /// <returns>Returns the list of XML contents from given feed URLs asynchronously.</returns>
        public abstract Task<List<string>> GetContentsAsync(IEnumerable<string> feedUrls);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion Methods
    }
}
