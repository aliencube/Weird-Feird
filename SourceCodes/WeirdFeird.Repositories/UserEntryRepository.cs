using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Data.Entity;
using System.Linq;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the repository entity for UserEntry.
    /// </summary>
    public class UserEntryRepository : RepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the UserEntryRepository class.
        /// </summary>
        /// <param name="context">WeirdFeirdDbContext instance.</param>
        public UserEntryRepository(IWeirdFeirdDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new UserEntry object to the repository.
        /// </summary>
        /// <param name="userEntry">UserEntry object.</param>
        /// <exception cref="ArgumentNullException">Throws when userEntry object is NULL.</exception>
        public override void Add<T>(T userEntry)
        {
            if (userEntry.Equals(default(T)))
                throw new ArgumentNullException("userEntry", "No userEntry object provided");

            this.Context.UserEntries.Add(userEntry as UserEntry);
        }

        /// <summary>
        /// Gets the UserEntry object by UserEntryId.
        /// </summary>
        /// <param name="userEntryId">UserEntry Id.</param>
        /// <returns>Returns the UserEntry object.</returns>
        /// <exception cref="ArgumentNullException">Throws when userEntry object is NULL.</exception>
        public override T Get<T>(int userEntryId)
        {
            if (userEntryId < 0)
                throw new ArgumentOutOfRangeException("userEntryId", "Invalid userEntryId provided");

            var item = this.Context
                           .UserEntries
                           .SingleOrDefault(p => p.UserEntryId == userEntryId);
            return (T)Convert.ChangeType(item, typeof(T));
        }

        /// <summary>
        /// Updates the UserEntry object.
        /// </summary>
        /// <param name="userEntry">UserEntry object.</param>
        /// <exception cref="ArgumentNullException">Throws when userEntry object is NULL.</exception>
        public override void Update<T>(T userEntry)
        {
            if (userEntry.Equals(default(T)))
                throw new ArgumentNullException("userEntry", "No userEntry object provided");

            if (this.Context.UserEntries.Local.Select(p => p.UserEntryId == (userEntry as UserEntry).UserEntryId).Any())
                throw new DbContextAlreadyExistException(String.Format("The {0} object already exists in the context. Update doesn't need to be called. Save occurs on commit.", typeof(T).Name));

            this.Context.Entry(userEntry as UserEntry).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the UserEntry object from the repository.
        /// </summary>
        /// <param name="userEntry">UserEntry object.</param>
        /// <exception cref="ArgumentNullException">Throws when userEntry object is NULL.</exception>
        public override void Delete<T>(T userEntry)
        {
            if (userEntry.Equals(default(T)))
                throw new ArgumentNullException("userEntry", "No userEntry object provided");

            this.Context.UserEntries.Remove(userEntry as UserEntry);
        }

        #endregion Methods
    }
}