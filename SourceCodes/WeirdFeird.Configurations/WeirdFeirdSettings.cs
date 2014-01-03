using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliencube.WeirdFeird.Configurations.Interfaces;

namespace Aliencube.WeirdFeird.Configurations
{
    /// <summary>
    /// This represents a configuration settings entity for Weird Feird.
    /// </summary>
    public class WeirdFeirdSettings : ConfigurationSection, IWeirdFeirdSettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets the proxy server settings element.
        /// This is optional.
        /// </summary>
        [ConfigurationProperty("proxy", IsRequired = false)]
        public ProxyElement Proxy
        {
            get { return (ProxyElement) this["proxy"]; }
            set { this["proxy"] = value; }
        }

        #endregion

        #region Methods

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
