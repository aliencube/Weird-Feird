using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the repository entity for UserFeed.
    /// </summary>
    public class UserFeedRepository : RepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the UserFeedRepository class.
        /// </summary>
        /// <param name="context">WeirdFeirdDbContext instance.</param>
        public UserFeedRepository(IWeirdFeirdDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new UserFeed object to the repository.
        /// </summary>
        /// <typeparam name="T">Type of UserFeed.</typeparam>
        /// <param name="userFeed">UserFeed object.</param>
        /// <exception cref="ArgumentNullException">Throws when userFeed object is NULL.</exception>
        public override void Add<T>(T userFeed)
        {
            if (userFeed.Equals(default(T)))
                throw new ArgumentNullException("userFeed", "No userFeed object provided");

            this.Context.UserFeeds.Add(userFeed as UserFeed);
        }

        /// <summary>
        /// Gets the UserFeed object by UserFeedId.
        /// </summary>
        /// <typeparam name="T">Type of UserFeed.</typeparam>
        /// <param name="userFeedId">UserFeed Id.</param>
        /// <returns>Returns the UserFeed object.</returns>
        /// <exception cref="ArgumentNullException">Throws when userFeed object is NULL.</exception>
        public override T Get<T>(int userFeedId)
        {
            if (userFeedId < 0)
                throw new ArgumentOutOfRangeException("userFeedId", "Invalid userFeedId provided");

            var item = this.Context
                           .UserFeeds
                           .SingleOrDefault(p => p.UserFeedId == userFeedId);
            return (T)Convert.ChangeType(item, typeof(T));
        }

        /// <summary>
        /// Gets the list of UserFeed objects.
        /// </summary>
        /// <typeparam name="T">Type of UserFeed.</typeparam>
        /// <returns>Returns the list of UserFeed objects.</returns>
        public override IList<T> Get<T>()
        {
            var userFeeds = this.Context.UserFeeds.OrderBy(p => p.UserFeedId);
            return (IList<T>)Convert.ChangeType(userFeeds, typeof(IList<T>));
        }

        /// <summary>
        /// Updates the UserFeed object.
        /// </summary>
        /// <typeparam name="T">Type of UserFeed.</typeparam>
        /// <param name="userFeed">UserFeed object.</param>
        /// <exception cref="ArgumentNullException">Throws when userFeed object is NULL.</exception>
        public override void Update<T>(T userFeed)
        {
            if (userFeed.Equals(default(T)))
                throw new ArgumentNullException("userFeed", "No userFeed object provided");

            if (this.Context.UserFeeds.Local.Select(p => p.UserFeedId == (userFeed as UserFeed).UserFeedId).Any())
                throw new DbContextAlreadyExistException(String.Format("The {0} object already exists in the context. Update doesn't need to be called. Save occurs on commit.", typeof(T).Name));

            this.Context.Entry(userFeed as UserFeed).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the UserFeed object from the repository.
        /// </summary>
        /// <typeparam name="T">Type of UserFeed.</typeparam>
        /// <param name="userFeed">UserFeed object.</param>
        /// <exception cref="ArgumentNullException">Throws when userFeed object is NULL.</exception>
        public override void Delete<T>(T userFeed)
        {
            if (userFeed.Equals(default(T)))
                throw new ArgumentNullException("userFeed", "No userFeed object provided");

            this.Context.UserFeeds.Remove(userFeed as UserFeed);
        }

        #endregion Methods
    }
}