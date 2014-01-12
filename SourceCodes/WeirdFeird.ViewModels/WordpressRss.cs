using Aliencube.WeirdFeird.ViewModels.Extensions;

namespace Aliencube.WeirdFeird.ViewModels
{
    public partial class WordpressRss : Extensions.Rss
    {
        #region Properties - Required

        public new WordpressChannel Channel { get; set; }

        #endregion Properties - Required
    }

    public partial class WordpressChannel : Extensions.Channel
    {
        #region Properties - Optional

        //AtomLink
        public Syndication Syndication { get; set; }

        #endregion Properties - Optional
    }

    public partial class WordpressItem : Extensions.Item
    {
        #region Properties - Optional

        public DublinCore DublinCore { get; set; }

        public Content Content { get; set; }

        public WellFormedWeb WellFormedWeb { get; set; }

        public Slash Slash { get; set; }

        #endregion Properties - Optional
    }
}