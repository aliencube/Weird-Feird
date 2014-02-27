using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Aliencube.WeirdFeird.Repositories
{
    /// <summary>
    /// This represents the repository entity for Editor.
    /// </summary>
    public class EditorRepository : RepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the EditorRepository class.
        /// </summary>
        /// <param name="context">WeirdFeirdDbContext instance.</param>
        public EditorRepository(IWeirdFeirdDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new Editor object to the repository.
        /// </summary>
        /// <typeparam name="T">Type of Editor.</typeparam>
        /// <param name="editor">Editor object.</param>
        /// <exception cref="ArgumentNullException">Throws when editor object is NULL.</exception>
        public override void Add<T>(T editor)
        {
            if (editor.Equals(default(T)))
                throw new ArgumentNullException("editor", "No editor object provided");

            this.Context.Editors.Add(editor as Editor);
        }

        /// <summary>
        /// Gets the Editor object by EditorId.
        /// </summary>
        /// <typeparam name="T">Type of Editor.</typeparam>
        /// <param name="editorId">Editor Id.</param>
        /// <returns>Returns the Editor object.</returns>
        /// <exception cref="ArgumentNullException">Throws when editor object is NULL.</exception>
        public override T Get<T>(int editorId)
        {
            if (editorId < 0)
                throw new ArgumentOutOfRangeException("editorId", "Invalid editorId provided");

            var item = this.Context
                           .Editors
                           .SingleOrDefault(p => p.EditorId == editorId);
            return (T)Convert.ChangeType(item, typeof(T));
        }

        /// <summary>
        /// Gets the list of Editor objects.
        /// </summary>
        /// <typeparam name="T">Type of Editor.</typeparam>
        /// <returns>Returns the list of Editor objects.</returns>
        public override IList<T> Get<T>()
        {
            var editors = this.Context.Editors.OrderBy(p => p.EditorId);
            return (IList<T>)Convert.ChangeType(editors, typeof(IList<T>));
        }

        /// <summary>
        /// Updates the Editor object.
        /// </summary>
        /// <typeparam name="T">Type of Editor.</typeparam>
        /// <param name="editor">Editor object.</param>
        /// <exception cref="ArgumentNullException">Throws when editor object is NULL.</exception>
        public override void Update<T>(T editor)
        {
            if (editor.Equals(default(T)))
                throw new ArgumentNullException("editor", "No editor object provided");

            if (this.Context.Editors.Local.Select(p => p.EditorId == (editor as Editor).EditorId).Any())
                throw new DbContextAlreadyExistException(String.Format("The {0} object already exists in the context. Update doesn't need to be called. Save occurs on commit.", typeof(T).Name));

            this.Context.Entry(editor as Editor).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the Editor object from the repository.
        /// </summary>
        /// <typeparam name="T">Type of Editor.</typeparam>
        /// <param name="editor">Editor object.</param>
        /// <exception cref="ArgumentNullException">Throws when editor object is NULL.</exception>
        public override void Delete<T>(T editor)
        {
            if (editor.Equals(default(T)))
                throw new ArgumentNullException("editor", "No editor object provided");

            this.Context.Editors.Remove(editor as Editor);
        }

        #endregion Methods
    }
}