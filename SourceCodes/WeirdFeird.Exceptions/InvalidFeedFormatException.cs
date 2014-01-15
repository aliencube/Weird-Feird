using System;
using System.Runtime.Serialization;

namespace Aliencube.WeirdFeird.Exceptions
{
    /// <summary>
    /// This represents an entity that is thrown when a feed format is invalid.
    /// </summary>
    public class InvalidFeedFormatException : ApplicationException
    {
        /// <summary>
        /// Initialises a new instance of the InvalidFeedFormatException class.
        /// </summary>
        public InvalidFeedFormatException()
            : base()
        {
        }

        /// <summary>
        /// Initialises a new instance of the InvalidFeedFormatException class.
        /// </summary>
        /// <param name="info">The object that holds the serialised object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        public InvalidFeedFormatException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initialises a new instance of the InvalidFeedFormatException class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public InvalidFeedFormatException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initialises a new instance of the InvalidFeedFormatException class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// If the innerException parameter is not a null reference,
        /// the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        public InvalidFeedFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}