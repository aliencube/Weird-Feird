using Aliencube.WeirdFeird.ViewModels.Interfaces.Atom;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Extensions;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Wordpress
{
    /// <summary>
    /// This provides interfaces to the WordpressChannel class.
    /// </summary>
    public interface IWordpressChannel
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the ATOM Link instance.
        /// </summary>
        ILink AtomLink { get; set; }

        /// <summary>
        /// Gets or sets the Syndication instance.
        /// </summary>
        ISyndication Syndication { get; set; }

        #endregion Properties - Optional
    }
}