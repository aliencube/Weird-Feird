using System;

namespace Aliencube.WeirdFeird.ViewModels.Extensions
{
    public partial class Syndication : Schemata.Syndication.Syndication
    {
        public UpdatePeriod UpdatePeriod { get; set; }

        public int? UpdateFrequency { get; set; }

        public DateTime? UpdateBase { get; set; }
    }

    public enum UpdatePeriod
    {
        Hourly,
        Daily,
        Weekly,
        Monthly,
        Yearly,
    }
}