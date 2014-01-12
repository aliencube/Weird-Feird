using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Extensions
{
    public partial class Slash : Schemata.Slash.Slash
    {
        #region Properties - Optional

        public string Section { get; set; }

        public string Department { get; set; }

        public int? Comments { get; set; }

        public IList<int> HitParade { get; set; }

        #endregion Properties - Optional
    }
}