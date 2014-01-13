using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Extensions
{
    /// <summary>
    /// This provides interfaces to the Slash class.
    /// </summary>
    public interface ISlash
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        string Section { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        string Department { get; set; }

        /// <summary>
        /// Gets or sets the number of comments.
        /// </summary>
        int? Comments { get; set; }

        /// <summary>
        /// Gets or sets the list of numbers.
        /// </summary>
        IList<int> HitParade { get; set; }

        #endregion Properties - Optional
    }
}