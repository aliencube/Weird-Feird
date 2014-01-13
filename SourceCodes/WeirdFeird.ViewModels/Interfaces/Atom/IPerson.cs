namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Atom
{
    /// <summary>
    /// This provides interfaces to the class of Person.
    /// </summary>
    public interface IPerson : ICommonAttribute
    {
        #region Properties - Required

        /// <summary>
        /// Gets or sets the human-readable name for the person.
        /// </summary>
        string Name { get; set; }

        #endregion Properties - Required

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the home page for the person.
        /// </summary>
        string Uri { get; set; }

        /// <summary>
        /// Gets or sets the email address for the person.
        /// </summary>
        string Email { get; set; }

        #endregion Properties - Optional
    }
}