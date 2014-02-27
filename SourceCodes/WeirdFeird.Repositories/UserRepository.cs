using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the repository entity for User.
    /// </summary>
    public class UserRepository : RepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the UserRepository class.
        /// </summary>
        /// <param name="context">WeirdFeirdDbContext instance.</param>
        public UserRepository(IWeirdFeirdDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new User object to the repository.
        /// </summary>
        /// <typeparam name="T">Type of User.</typeparam>
        /// <param name="user">User object.</param>
        /// <exception cref="ArgumentNullException">Throws when user object is NULL.</exception>
        public override void Add<T>(T user)
        {
            if (user.Equals(default(T)))
                throw new ArgumentNullException("user", "No user object provided");

            this.Context.Users.Add(user as User);
        }

        /// <summary>
        /// Gets the User object by UserId.
        /// </summary>
        /// <typeparam name="T">Type of User.</typeparam>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns the User object.</returns>
        /// <exception cref="ArgumentNullException">Throws when user object is NULL.</exception>
        public override T Get<T>(int userId)
        {
            if (userId < 0)
                throw new ArgumentOutOfRangeException("userId", "Invalid userId provided");

            var item = this.Context
                           .Users
                           .SingleOrDefault(p => p.UserId == userId);
            return (T)Convert.ChangeType(item, typeof(T));
        }

        /// <summary>
        /// Gets the list of User objects.
        /// </summary>
        /// <typeparam name="T">Type of User.</typeparam>
        /// <returns>Returns the list of User objects.</returns>
        public override IList<T> Get<T>()
        {
            var users = this.Context.Users.OrderBy(p => p.UserId);
            return (IList<T>)Convert.ChangeType(users, typeof(IList<T>));
        }

        /// <summary>
        /// Updates the User object.
        /// </summary>
        /// <typeparam name="T">Type of User.</typeparam>
        /// <param name="user">User object.</param>
        /// <exception cref="ArgumentNullException">Throws when user object is NULL.</exception>
        public override void Update<T>(T user)
        {
            if (user.Equals(default(T)))
                throw new ArgumentNullException("user", "No user object provided");

            if (this.Context.Users.Local.Select(p => p.UserId == (user as User).UserId).Any())
                throw new DbContextAlreadyExistException(String.Format("The {0} object already exists in the context. Update doesn't need to be called. Save occurs on commit.", typeof(T).Name));

            this.Context.Entry(user as User).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the User object from the repository.
        /// </summary>
        /// <typeparam name="T">Type of User.</typeparam>
        /// <param name="user">User object.</param>
        /// <exception cref="ArgumentNullException">Throws when user object is NULL.</exception>
        public override void Delete<T>(T user)
        {
            if (user.Equals(default(T)))
                throw new ArgumentNullException("user", "No user object provided");

            this.Context.Users.Remove(user as User);
        }

        #endregion Methods
    }
}