using System.Collections.Generic;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Extensions
{
    /// <summary>
    /// This represents an entity for Slash which is the source code and database that was originally used to create Slashdot
    /// </summary>
    /// <remarks>
    /// Slash has now been released under the GNU General Public License. It is a bona fide Open Source / Free Software project.
    /// </remarks>
    public class Slash
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the number of comments.
        /// </summary>
        public int? Comments { get; set; }

        /// <summary>
        /// Gets or sets the list of numbers.
        /// </summary>
        public IList<int> HitParade { get; set; }

        #endregion Properties - Optional
    }
}