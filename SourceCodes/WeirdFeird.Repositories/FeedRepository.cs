using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the repository entity for Feed.
    /// </summary>
    public class FeedRepository : RepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the FeedRepository class.
        /// </summary>
        /// <param name="context">WeirdFeirdDbContext instance.</param>
        public FeedRepository(IWeirdFeirdDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new Feed object to the repository.
        /// </summary>
        /// <typeparam name="T">Type of Feed.</typeparam>
        /// <param name="feed">Feed object.</param>
        /// <exception cref="ArgumentNullException">Throws when feed object is NULL.</exception>
        public override void Add<T>(T feed)
        {
            if (feed.Equals(default(T)))
                throw new ArgumentNullException("feed", "No feed object provided");

            this.Context.Feeds.Add(feed as Feed);
        }

        /// <summary>
        /// Gets the Feed object by FeedId.
        /// </summary>
        /// <typeparam name="T">Type of Feed.</typeparam>
        /// <param name="feedId">Feed Id.</param>
        /// <returns>Returns the Feed object.</returns>
        /// <exception cref="ArgumentNullException">Throws when feed object is NULL.</exception>
        public override T Get<T>(int feedId)
        {
            if (feedId < 0)
                throw new ArgumentOutOfRangeException("feedId", "Invalid feedId provided");

            var item = this.Context
                           .Feeds
                           .SingleOrDefault(p => p.FeedId == feedId);
            return (T)Convert.ChangeType(item, typeof(T));
        }

        /// <summary>
        /// Gets the list of Feed objects.
        /// </summary>
        /// <typeparam name="T">Type of Feed.</typeparam>
        /// <returns>Returns the list of Feed objects.</returns>
        public override IList<T> Get<T>()
        {
            var feeds = this.Context.Feeds.OrderBy(p => p.FeedId);
            return (IList<T>)Convert.ChangeType(feeds, typeof(IList<T>));
        }

        /// <summary>
        /// Updates the Feed object.
        /// </summary>
        /// <typeparam name="T">Type of Feed.</typeparam>
        /// <param name="feed">Feed object.</param>
        /// <exception cref="ArgumentNullException">Throws when feed object is NULL.</exception>
        public override void Update<T>(T feed)
        {
            if (feed.Equals(default(T)))
                throw new ArgumentNullException("feed", "No feed object provided");

            if (this.Context.Feeds.Local.Select(p => p.FeedId == (feed as Feed).FeedId).Any())
                throw new DbContextAlreadyExistException(String.Format("The {0} object already exists in the context. Update doesn't need to be called. Save occurs on commit.", typeof(T).Name));

            this.Context.Entry(feed as Feed).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the Feed object from the repository.
        /// </summary>
        /// <typeparam name="T">Type of Feed.</typeparam>
        /// <param name="feed">Feed object.</param>
        /// <exception cref="ArgumentNullException">Throws when feed object is NULL.</exception>
        public override void Delete<T>(T feed)
        {
            if (feed.Equals(default(T)))
                throw new ArgumentNullException("feed", "No feed object provided");

            this.Context.Feeds.Remove(feed as Feed);
        }

        #endregion Methods
    }
}