using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliencube.WeirdFeird.ViewModels.Enums
{
    /// <summary>
    /// This specifies the web service protocol for rssCloud interface.
    /// </summary>
    public enum Protocol
    {
        /// <summary>
        /// Identifies the protocol is XML-RPC.
        /// </summary>
        XmlRpc = 0,

        /// <summary>
        /// Identifies the protocol is HTTP-Post.
        /// </summary>
        HttpPost = 1,

        /// <summary>
        /// Identifies the protocol is SOAP.
        /// </summary>
        Soap = 2,
    }
}
