using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliencube.WeirdFeird.ViewModels.Interfaces;

namespace Aliencube.WeirdFeird.ViewModels.Feeds
{
    /// <summary>
    /// This represents the standard feed entity.
    /// </summary>
    public partial class FeedAdapter : IFeedAdapter
    {
        #region Properties

        /// <summary>
        /// Gets or sets the list of standard feed item instances.
        /// </summary>
        public IList<IFeedEntry> Entries { get; set; }
        
        #endregion
    }

    /// <summary>
    /// this represents the standard feed item entity.
    /// </summary>
    public partial class FeedEntry : IFeedEntry
    {
        #region Properties
        #endregion
    }
}
