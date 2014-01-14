using Aliencube.WeirdFeird.ViewModels.Enums;

namespace Aliencube.WeirdFeird.ViewModels.Interfaces.Atom
{
    /// <summary>
    /// This provides interfaces to the class of Text.
    /// </summary>
    public interface IText
    {
        #region Properties - Optional

        /// <summary>
        /// Gets or sets the text type.
        /// </summary>
        TextType Type { get; set; }

        #endregion Properties - Optional
    }
}