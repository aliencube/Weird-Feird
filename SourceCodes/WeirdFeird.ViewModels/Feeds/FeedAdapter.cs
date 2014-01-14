using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliencube.WeirdFeird.ViewModels.Interfaces;

namespace Aliencube.WeirdFeird.ViewModels.Feeds
{
    public partial class FeedAdapter : IFeedAdapter
    {
        #region Properties

        public IList<IFeedEntry> Entries { get; set; }
        
        #endregion
    }

    public partial class FeedEntry : IFeedEntry
    {
        #region Properties
        #endregion
    }
}
