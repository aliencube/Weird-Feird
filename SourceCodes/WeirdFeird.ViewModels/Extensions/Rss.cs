using Aliencube.WeirdFeird.ViewModels.Schemata.Rss;
using System;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Extensions
{
    public partial class Rss : Schemata.Rss.Rss
    {
        #region Properties - Required

        public decimal Version { get; set; }

        public virtual Channel Channel { get; set; }

        #endregion Properties - Required
    }

    public partial class Channel : Schemata.Rss.Channel
    {
        #region Properties - Required

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        public string Language { get; set; }

        public string Copyright { get; set; }

        public string ManagingEditor { get; set; }

        public string WebMaster { get; set; }

        public DateTime? PubDate { get; set; }

        public DateTime? LastBuildDate { get; set; }

        public IList<Category> Categories { get; set; }

        public string Generator { get; set; }

        public string Docs { get; set; }

        public Cloud Cloud { get; set; }

        public int? Ttl { get; set; }

        public Image Image { get; set; }

        public string Rating { get; set; }

        public TextInput TextInput { get; set; }

        public IList<int> SkipHours { get; set; }

        public IList<SkipDay> SkipDays { get; set; }

        public new IList<Item> Items { get; set; }

        #endregion Properties - Optional
    }

    public partial class Category : Schemata.Rss.Category
    {
        public string Domain { get; set; }
    }

    public partial class Cloud : Schemata.Rss.Cloud
    {
        #region Properties - Required

        public string Domain { get; set; }

        public int Port { get; set; }

        public string Path { get; set; }

        public string RegisterProcedure { get; set; }

        public Protocol Protocol { get; set; }

        #endregion Properties - Required
    }

    public enum Protocol
    {
        XmlRpc,
        HttpPost,
        Soap
    }

    public partial class Image : Schemata.Rss.Image
    {
        #region Properties - Required

        public string Url { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        public int? Width { get; set; }

        public int? Height { get; set; }

        #endregion Properties - Optional
    }

    public partial class TextInput : Schemata.Rss.TextInput
    {
        #region Properties - Required

        public string Title { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        #endregion Properties - Required
    }

    public partial class Item : Schemata.Rss.Item
    {
        #region Properties - Required

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        public string Author { get; set; }

        public IList<Category> Categories { get; set; }

        public string Comments { get; set; }

        public Enclosure Enclosure { get; set; }

        public Guid Guid { get; set; }

        public DateTime? PubDate { get; set; }

        public Source Source { get; set; }

        #endregion Properties - Optional
    }

    public partial class Enclosure : Schemata.Rss.Enclosure
    {
        #region Properties - Required

        public string Url { get; set; }

        public int Length { get; set; }

        public string Type { get; set; }

        #endregion Properties - Required
    }

    public partial class Guid : Schemata.Rss.Guid
    {
        #region Properties - Optional

        public bool IsPermaLink { get; set; }

        #endregion Properties - Optional
    }

    public partial class Source : Schemata.Rss.Source
    {
        #region Properties - Optional

        public string Url { get; set; }

        #endregion Properties - Optional
    }
}