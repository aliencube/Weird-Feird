using Aliencube.WeirdFeird.ViewModels.Enums;
using Aliencube.WeirdFeird.ViewModels.Interfaces.Atom;

namespace Aliencube.WeirdFeird.ViewModels.Feeds.Atom
{
    /// <summary>
    /// This represents an entity that contains human-readable text, usually in small quantities. 
    /// </summary>
    /// <remarks>
    /// The type attribute determines how this information is encoded (default="text").
    /// </remarks>
    public class Text : CommonAttributes, IText
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the Text class.
        /// </summary>
        public Text()
        {
            this.Type = TextType.Text;
        }
        #endregion

        #region Properties - Optional

        /// <summary>
        /// Gets or sets the text type.
        /// </summary>
        public TextType Type { get; set; }

        #endregion Properties - Optional
    }
}