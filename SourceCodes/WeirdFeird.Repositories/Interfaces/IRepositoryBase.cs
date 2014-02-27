using System;
using System.Collections.Generic;

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
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="item">Item object.</param>
        void Add<T>(T item);

        /// <summary>
        /// Gets the item object by itemId.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="itemId">Item Id.</param>
        /// <returns>Returns the item object.</returns>
        T Get<T>(int itemId);

        /// <summary>
        /// Gets the list of item objects.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <returns>Returns the list of item objects.</returns>
        IList<T> Get<T>();

        /// <summary>
        /// Updates the item object.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="item">Item object.</param>
        void Update<T>(T item);

        /// <summary>
        /// Deletes the item object from the repository.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="item">Item object.</param>
        void Delete<T>(T item);

        #endregion Methods
    }
}