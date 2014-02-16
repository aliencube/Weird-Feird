using System;

namespace Aliencube.WeirdFeird.Configurations.Interfaces
{
    /// <summary>
    /// This provides interfaces to the WeirdFeirdSettings class.
    /// </summary>
    public interface IWeirdFeirdSettings : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the proxy server settings element.
        /// This is optional.
        /// </summary>
        ProxyElement Proxy { get; set; }

        /// <summary>
        /// Gets or sets the collection of generator element groups.
        /// </summary>
        GeneratorElementCollection Generators { get; set; }

        #endregion Properties
    }
}