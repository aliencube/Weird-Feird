using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Data.Entity;
using System.Linq;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the repository entity for Category.
    /// </summary>
    public class CategoryRepository : RepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the CategoryRepository class.
        /// </summary>
        /// <param name="context">WeirdFeirdDbContext instance.</param>
        public CategoryRepository(IWeirdFeirdDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new Category object to the repository.
        /// </summary>
        /// <param name="category">Category object.</param>
        /// <exception cref="ArgumentNullException">Throws when category object is NULL.</exception>
        public override void Add<T>(T category)
        {
            if (category.Equals(default(T)))
                throw new ArgumentNullException("category", "No category object provided");

            this.Context.Categories.Add(category as Category);
        }

        /// <summary>
        /// Gets the Category object by CategoryId.
        /// </summary>
        /// <param name="categoryId">Category Id.</param>
        /// <returns>Returns the Category object.</returns>
        /// <exception cref="ArgumentNullException">Throws when category object is NULL.</exception>
        public override T Get<T>(int categoryId)
        {
            if (categoryId < 0)
                throw new ArgumentOutOfRangeException("categoryId", "Invalid categoryId provided");

            var item = this.Context
                           .Categories
                           .SingleOrDefault(p => p.CategoryId == categoryId);
            return (T)Convert.ChangeType(item, typeof(T));
        }

        /// <summary>
        /// Updates the Category object.
        /// </summary>
        /// <param name="category">Category object.</param>
        /// <exception cref="ArgumentNullException">Throws when category object is NULL.</exception>
        public override void Update<T>(T category)
        {
            if (category.Equals(default(T)))
                throw new ArgumentNullException("category", "No category object provided");

            if (this.Context.Categories.Local.Select(p => p.CategoryId == (category as Category).CategoryId).Any())
                throw new DbContextAlreadyExistException(String.Format("The {0} object already exists in the context. Update doesn't need to be called. Save occurs on commit.", typeof(T).Name));

            this.Context.Entry(category as Category).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the Category object from the repository.
        /// </summary>
        /// <param name="category">Category object.</param>
        /// <exception cref="ArgumentNullException">Throws when category object is NULL.</exception>
        public override void Delete<T>(T category)
        {
            if (category.Equals(default(T)))
                throw new ArgumentNullException("category", "No category object provided");

            this.Context.Categories.Remove(category as Category);
        }

        #endregion Methods
    }
}