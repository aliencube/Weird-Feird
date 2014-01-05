using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aliencube.WeirdFeird.Services.Exceptions
{
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
