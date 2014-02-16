using System.Configuration;

namespace Aliencube.WeirdFeird.Configurations
{
    /// <summary>
    /// This represents the generator element entity.
    /// </summary>
    public class GeneratorElement : ConfigurationElement
    {
        #region Properties

        /// <summary>
        /// Gets or sets the key for unique identification.
        /// </summary>
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        /// <summary>
        /// Gets or sets the value of the element.
        /// </summary>
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }

        #endregion Properties
    }
}