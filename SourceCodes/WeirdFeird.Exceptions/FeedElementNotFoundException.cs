using System;
using System.Runtime.Serialization;

namespace Aliencube.WeirdFeird.Exceptions
{
    /// <summary>
    /// This represents an entity that is thrown when a feed element is not found.
    /// </summary>
    public class FeedElementNotFoundException : ApplicationException
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the FeedElementNotFoundException class.
        /// </summary>
        public FeedElementNotFoundException()
            : base()
        {
        }

        /// <summary>
        /// Initialises a new instance of the FeedElementNotFoundException class.
        /// </summary>
        /// <param name="info">The object that holds the serialised object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        public FeedElementNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initialises a new instance of the FeedElementNotFoundException class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public FeedElementNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initialises a new instance of the FeedElementNotFoundException class.
        /// </summary>
        /// <param name="elementName">Element name that throws the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        public FeedElementNotFoundException(string elementName, string message)
            : base(message)
        {
            this.ElementName = elementName;
        }

        /// <summary>
        /// Initialises a new instance of the FeedElementNotFoundException class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// If the innerException parameter is not a null reference,
        /// the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        public FeedElementNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initialises a new instance of the FeedElementNotFoundException class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="elementName">Element name that throws the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// If the innerException parameter is not a null reference,
        /// the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        public FeedElementNotFoundException(string elementName, string message, Exception innerException)
            : base(message, innerException)
        {
            this.ElementName = elementName;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the feed element name that throws the exception.
        /// </summary>
        public string ElementName { get; set; }

        #endregion Properties
    }
}