using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces
{
    /// <summary>
    /// This provides interfaces to the FeedAdapter class.
    /// </summary>
    public interface IFeedAdapter
    {
        #region Properties

        IList<IFeedEntry> Entries { get; set; }

        #endregion
    }

    /// <summary>
    /// This provides interfaces to the FeedEntry class.
    /// </summary>
    public interface IFeedEntry
    {
        #region Properties
        #endregion
    }
}
