using System;
using System.Runtime.Serialization;

namespace Aliencube.WeirdFeird.Exceptions
{
    /// <summary>
    /// This represents an exception entity that is thrown when data context already exists.
    /// </summary>
    public class DbContextAlreadyExistException : ApplicationException
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the DbContextAlreadyExistException class.
        /// </summary>
        public DbContextAlreadyExistException()
            : base()
        {
        }

        /// <summary>
        /// Initialises a new instance of the DbContextAlreadyExistException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        public DbContextAlreadyExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initialises a new instance of the DbContextAlreadyExistException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public DbContextAlreadyExistException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initialises a new instance of the DbContextAlreadyExistException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public DbContextAlreadyExistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Constructors
    }
}