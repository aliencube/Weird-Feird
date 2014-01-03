using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliencube.WeirdFeird.Configurations.Interfaces
{
    /// <summary>
    /// This provides interfaces to the WeirdFeirdSettings class.
    /// </summary>
    public interface IWeirdFeirdSettings : IDisposable
    {
        /// <summary>
        /// Gets or sets the proxy server settings element.
        /// This is optional.
        /// </summary>
        ProxyElement Proxy { get; set; }
    }
}
