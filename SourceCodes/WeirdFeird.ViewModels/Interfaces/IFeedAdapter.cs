using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces
{
    public interface IFeedAdapter
    {
        #region Properties

        IList<IFeedEntry> Entries { get; set; }

        #endregion
    }

    public interface IFeedEntry
    {
        #region Properties
        #endregion
    }
}
