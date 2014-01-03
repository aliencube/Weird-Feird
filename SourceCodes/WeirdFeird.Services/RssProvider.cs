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
    /// This represents the provider entity for RSS feed.
    /// This must be inherited.
    /// </summary>
    public abstract class RssProvider : ProviderBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the RssProvider class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        protected RssProvider(IWeirdFeirdSettings settings)
            : base(settings)
        {
        }

        #endregion
    }
}
