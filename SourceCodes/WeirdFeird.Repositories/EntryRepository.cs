using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Data.Entity;
using System.Linq;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the repository entity for Entry.
    /// </summary>
    public class EntryRepository : RepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the EntryRepository class.
        /// </summary>
        /// <param name="context">WeirdFeirdDbContext instance.</param>
        public EntryRepository(IWeirdFeirdDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new Entry object to the repository.
        /// </summary>
        /// <param name="entry">Entry object.</param>
        /// <exception cref="ArgumentNullException">Throws when entry object is NULL.</exception>
        public override void Add<T>(T entry)
        {
            if (entry.Equals(default(T)))
                throw new ArgumentNullException("entry", "No entry object provided");

            this.Context.Entries.Add(entry as Entry);
        }

        /// <summary>
        /// Gets the Entry object by EntryId.
        /// </summary>
        /// <param name="entryId">Entry Id.</param>
        /// <returns>Returns the Entry object.</returns>
        /// <exception cref="ArgumentNullException">Throws when entry object is NULL.</exception>
        public override T Get<T>(int entryId)
        {
            if (entryId < 0)
                throw new ArgumentOutOfRangeException("entryId", "Invalid entryId provided");

            var item = this.Context
                           .Entries
                           .SingleOrDefault(p => p.EntryId == entryId);
            return (T)Convert.ChangeType(item, typeof(T));
        }

        /// <summary>
        /// Updates the Entry object.
        /// </summary>
        /// <param name="entry">Entry object.</param>
        /// <exception cref="ArgumentNullException">Throws when entry object is NULL.</exception>
        public override void Update<T>(T entry)
        {
            if (entry.Equals(default(T)))
                throw new ArgumentNullException("entry", "No entry object provided");

            if (this.Context.Entries.Local.Select(p => p.EntryId == (entry as Entry).EntryId).Any())
                throw new DbContextAlreadyExistException(String.Format("The {0} object already exists in the context. Update doesn't need to be called. Save occurs on commit.", typeof(T).Name));

            this.Context.Entry(entry as Entry).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the Entry object from the repository.
        /// </summary>
        /// <param name="entry">Entry object.</param>
        /// <exception cref="ArgumentNullException">Throws when entry object is NULL.</exception>
        public override void Delete<T>(T entry)
        {
            if (entry.Equals(default(T)))
                throw new ArgumentNullException("entry", "No entry object provided");

            this.Context.Entries.Remove(entry as Entry);
        }

        #endregion Methods
    }
}