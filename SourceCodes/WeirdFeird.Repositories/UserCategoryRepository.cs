using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Data.Entity;
using System.Linq;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the repository entity for UserCategory.
    /// </summary>
    public class UserCategoryRepository : RepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the UserCategoryRepository class.
        /// </summary>
        /// <param name="context">WeirdFeirdDbContext instance.</param>
        public UserCategoryRepository(IWeirdFeirdDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new UserCategory object to the repository.
        /// </summary>
        /// <param name="userCategory">UserCategory object.</param>
        /// <exception cref="ArgumentNullException">Throws when userCategory object is NULL.</exception>
        public override void Add<T>(T userCategory)
        {
            if (userCategory.Equals(default(T)))
                throw new ArgumentNullException("userCategory", "No userCategory object provided");

            this.Context.UserCategories.Add(userCategory as UserCategory);
        }

        /// <summary>
        /// Gets the UserCategory object by UserCategoryId.
        /// </summary>
        /// <param name="userCategoryId">UserCategory Id.</param>
        /// <returns>Returns the UserCategory object.</returns>
        /// <exception cref="ArgumentNullException">Throws when userCategory object is NULL.</exception>
        public override T Get<T>(int userCategoryId)
        {
            if (userCategoryId < 0)
                throw new ArgumentOutOfRangeException("userCategoryId", "Invalid userCategoryId provided");

            var item = this.Context
                           .UserCategories
                           .SingleOrDefault(p => p.UserCategoryId == userCategoryId);
            return (T)Convert.ChangeType(item, typeof(T));
        }

        /// <summary>
        /// Updates the UserCategory object.
        /// </summary>
        /// <param name="userCategory">UserCategory object.</param>
        /// <exception cref="ArgumentNullException">Throws when userCategory object is NULL.</exception>
        public override void Update<T>(T userCategory)
        {
            if (userCategory.Equals(default(T)))
                throw new ArgumentNullException("userCategory", "No userCategory object provided");

            if (this.Context.UserCategories.Local.Select(p => p.UserCategoryId == (userCategory as UserCategory).UserCategoryId).Any())
                throw new DbContextAlreadyExistException(String.Format("The {0} object already exists in the context. Update doesn't need to be called. Save occurs on commit.", typeof(T).Name));

            this.Context.Entry(userCategory as UserCategory).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the UserCategory object from the repository.
        /// </summary>
        /// <param name="userCategory">UserCategory object.</param>
        /// <exception cref="ArgumentNullException">Throws when userCategory object is NULL.</exception>
        public override void Delete<T>(T userCategory)
        {
            if (userCategory.Equals(default(T)))
                throw new ArgumentNullException("userCategory", "No userCategory object provided");

            this.Context.UserCategories.Remove(userCategory as UserCategory);
        }

        #endregion Methods
    }
}