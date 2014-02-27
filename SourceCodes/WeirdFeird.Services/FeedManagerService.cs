using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Repositories;
using Aliencube.WeirdFeird.Repositories.Interfaces;
using Aliencube.WeirdFeird.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Aliencube.WeirdFeird.Services
{
    /// <summary>
    /// This represents the feed manager service entity.
    /// </summary>
    public class FeedManagerService : IFeedManagerService
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the FeedManagerService class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        /// <param name="authorRepository">AuthorRepository instance.</param>
        /// <param name="categoryRepository">CategoryRepository instance.</param>
        /// <param name="editorRepository">EditorRepository instance.</param>
        /// <param name="entryRepository">EntryRepository instance.</param>
        /// <param name="feedRepository">FeedRepository instance.</param>
        /// <param name="userCategoryRepository">UserCategoryRepository instance.</param>
        /// <param name="userEntryRepository">UserEntryRepository instance.</param>
        /// <param name="userFeedRepository">UserFeedRepository instance.</param>
        /// <param name="userRepository">UserRepository instance.</param>
        public FeedManagerService(IWeirdFeirdSettings settings,
                                  IRepositoryBase authorRepository,
                                  IRepositoryBase categoryRepository,
                                  IRepositoryBase editorRepository,
                                  IRepositoryBase entryRepository,
                                  IRepositoryBase feedRepository,
                                  IRepositoryBase userCategoryRepository,
                                  IRepositoryBase userEntryRepository,
                                  IRepositoryBase userFeedRepository,
                                  IRepositoryBase userRepository)
        {
            this._settings = settings;
            this._authorRepository = authorRepository;
            this._categoryRepository = categoryRepository;
            this._editorRepository = editorRepository;
            this._entryRepository = entryRepository;
            this._feedRepository = feedRepository;
            this._userCategoryRepository = userCategoryRepository;
            this._userEntryRepository = userEntryRepository;
            this._userFeedRepository = userFeedRepository;
            this._userRepository = userRepository;
        }

        #endregion Constructors

        #region Properties

        private readonly IWeirdFeirdSettings _settings;
        private readonly IRepositoryBase _authorRepository;
        private readonly IRepositoryBase _categoryRepository;
        private readonly IRepositoryBase _editorRepository;
        private readonly IRepositoryBase _entryRepository;
        private readonly IRepositoryBase _feedRepository;
        private readonly IRepositoryBase _userCategoryRepository;
        private readonly IRepositoryBase _userEntryRepository;
        private readonly IRepositoryBase _userFeedRepository;
        private readonly IRepositoryBase _userRepository;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the list of feed links.
        /// </summary>
        /// <returns>Returns the list of feed links.</returns>
        public IList<string> GetFeedLinks()
        {
            var links = this._feedRepository.Get<Feed>().Select(p => p.FeedLink).ToList();
            return links;
        }

        #endregion Methods
    }
}

namespace Aliencube.WeirdFeird.Services.Interfaces
{
}