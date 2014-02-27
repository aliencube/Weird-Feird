using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Data.Entity;
using System.Linq;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the repository entity for Author.
    /// </summary>
    public class AuthorRepository : RepositoryBase
    {
        #region Constructors

        public AuthorRepository(IWeirdFeirdDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new Author object to the repository.
        /// </summary>
        /// <param name="author">Author object.</param>
        /// <exception cref="ArgumentNullException">Throws when author object is NULL.</exception>
        public override void Add<T>(T author)
        {
            if (author.Equals(default(T)))
                throw new ArgumentNullException("author", "No author object provided");

            this.Context.Authors.Add(author as Author);
        }

        /// <summary>
        /// Gets the Author object by AuthorId.
        /// </summary>
        /// <param name="authorId">Author Id.</param>
        /// <returns>Returns the Author object.</returns>
        /// <exception cref="ArgumentNullException">Throws when author object is NULL.</exception>
        public override T Get<T>(int authorId)
        {
            if (authorId < 0)
                throw new ArgumentOutOfRangeException("authorId", "Invalid authorId provided");

            var item = this.Context
                           .Authors
                           .SingleOrDefault(p => p.AuthorId == authorId);
            return (T)Convert.ChangeType(item, typeof(T));
        }

        /// <summary>
        /// Updates the Author object.
        /// </summary>
        /// <param name="author">Author object.</param>
        /// <exception cref="ArgumentNullException">Throws when author object is NULL.</exception>
        public override void Update<T>(T author)
        {
            if (author.Equals(default(T)))
                throw new ArgumentNullException("author", "No author object provided");

            if (this.Context.Authors.Local.Select(p => p.AuthorId == (author as Author).AuthorId).Any())
                throw new DbContextAlreadyExistException(String.Format("The {0} object already exists in the context. Update doesn't need to be called. Save occurs on commit.", typeof(T).Name));

            this.Context.Entry(author as Author).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the Author object from the repository.
        /// </summary>
        /// <param name="author">Author object.</param>
        /// <exception cref="ArgumentNullException">Throws when author object is NULL.</exception>
        public override void Delete<T>(T author)
        {
            if (author.Equals(default(T)))
                throw new ArgumentNullException("author", "No author object provided");

            this.Context.Authors.Remove(author as Author);
        }

        #endregion Methods
    }
}