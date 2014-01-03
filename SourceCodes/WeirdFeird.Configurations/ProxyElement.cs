using System.Configuration;

namespace Aliencube.WeirdFeird.Configurations
{
    /// <summary>
    /// This represents the proxy server settings element entity.
    /// </summary>
    public class ProxyElement : ConfigurationElement
    {
        #region Properties

        /// <summary>
        /// Gets or sets the value whether to use proxy server or not.
        /// Default value is <c>False</c>.
        /// </summary>
        [ConfigurationProperty("use", DefaultValue = false, IsRequired = false)]
        public bool Use
        {
            get { return (bool) this["use"]; }
            set { this["use"] = value; }
        }

        /// <summary>
        /// Gets or sets the proxy server URL.
        /// Default value is <c>http://localhost:8080</c>.
        /// </summary>
        [ConfigurationProperty("url", DefaultValue = "http://localhost:8080", IsRequired = false)]
        public string Url
        {
            get { return (string) this["url"]; }
            set { this["url"] = value; }
        }

        #endregion Properties
    }
}