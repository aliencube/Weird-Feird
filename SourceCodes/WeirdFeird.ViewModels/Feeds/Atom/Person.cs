using Aliencube.WeirdFeird.ViewModels.Interfaces.Atom;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Atom
{
    /// <summary>
    /// This represents an entity for a person.
    /// </summary>
    public class Person : CommonAttributes, IPerson
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the human-readable name for the person.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the home page for the person.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the email address for the person.
        /// </summary>
        public string Email { get; set; }

        #endregion Properties - Optional
    }
}