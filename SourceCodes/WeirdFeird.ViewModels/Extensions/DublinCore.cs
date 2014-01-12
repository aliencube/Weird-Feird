using Aliencube.WeirdFeird.ViewModels.Schemata.DublinCore;
using System;

namespace Aliencube.WeirdFeird.ViewModels.Extensions
{
    public partial class DublinCore : Schemata.DublinCore.DublinCore
    {
        #region Properties - Optional

        public string Contrubutor { get; set; }

        public string Coverage { get; set; }

        public string Creator { get; set; }

        public DateTime? Date { get; set; }

        public string Description { get; set; }

        public string Format { get; set; }

        public string Identifier { get; set; }

        public string Language { get; set; }

        public string Publisher { get; set; }

        public string Relation { get; set; }

        public string Rights { get; set; }

        public string Source { get; set; }

        public string Subject { get; set; }

        public string Title { get; set; }

        public DcmiType Type { get; set; }

        #endregion Properties - Optional
    }
}