using System;

namespace Aliencube.WeirdFeird.Repositories.Interfaces
{
    /// <summary>
    /// This provides interfaces to the RepositoryBase class.
    /// </summary>
    public interface IRepositoryBase : IDisposable
    {
        #region Methods

        /// <summary>
        /// Adds a new item object to the repository.
        /// </summary>
        /// <param name="item">Item object.</param>
        void Add<T>(T item);

        /// <summary>
        /// Gets the item object by itemId.
        /// </summary>
        /// <param name="itemId">Item Id.</param>
        /// <returns>Returns the item object.</returns>
        T Get<T>(int itemId);

        /// <summary>
        /// Updates the item object.
        /// </summary>
        /// <param name="item">Item object.</param>
        void Update<T>(T item);

        /// <summary>
        /// Deletes the item object from the repository.
        /// </summary>
        /// <param name="item">Item object.</param>
        void Delete<T>(T item);

        #endregion Methods
    }
}