﻿using Aliencube.WeirdFeird.Repositories.Interfaces;
using System.Collections.Generic;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the base repository class inherited to all repository classes.
    /// </summary>
    public abstract class RepositoryBase : IRepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the RepositoryBase class.
        /// </summary>
        /// <param name="context">WeirdFeirdDbContext instance.</param>
        protected RepositoryBase(IWeirdFeirdDbContext context)
        {
            this.Context = context as WeirdFeirdDbContext;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the WeirdFeirdDbContext instance.
        /// </summary>
        protected WeirdFeirdDbContext Context { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds a new item object to the repository.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="item">Item object.</param>
        public abstract void Add<T>(T item);

        /// <summary>
        /// Gets the item object by itemId.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="itemId">Item Id.</param>
        /// <returns>Returns the item object.</returns>
        public abstract T Get<T>(int itemId);

        /// <summary>
        /// Gets the list of item objects.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <returns>Returns the list of item objects.</returns>
        public abstract IList<T> Get<T>();

        /// <summary>
        /// Updates the item object.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="item">Item object.</param>
        public abstract void Update<T>(T item);

        /// <summary>
        /// Deletes the item object from the repository.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="item">Item object.</param>
        public abstract void Delete<T>(T item);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
        }

        #endregion Methods
    }
}