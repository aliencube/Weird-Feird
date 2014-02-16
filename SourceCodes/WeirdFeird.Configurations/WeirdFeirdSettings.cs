using Aliencube.WeirdFeird.Configurations.Interfaces;
using System.Configuration;

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
            get { return (ProxyElement)this["proxy"]; }
            set { this["proxy"] = value; }
        }

        /// <summary>
        /// Gets or sets the collection of generator element groups.
        /// </summary>
        [ConfigurationProperty("generators", IsRequired = false)]
        public GeneratorElementCollection Generators
        {
            get { return (GeneratorElementCollection)this["generators"]; }
            set { this["generators"] = value; }
        }

        #endregion Properties

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