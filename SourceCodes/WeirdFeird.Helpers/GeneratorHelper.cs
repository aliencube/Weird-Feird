using Aliencube.WeirdFeird.Configurations;
using Aliencube.WeirdFeird.Configurations.Interfaces;
using Aliencube.WeirdFeird.Enums;
using Aliencube.WeirdFeird.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Helpers
{
    /// <summary>
    /// This represents a helper class for feed generator.
    /// </summary>
    public class GeneratorHelper : IGeneratorHelper
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the GeneratorHelper class.
        /// </summary>
        /// <param name="settings">Configuration settings instance for Weird-Feird.</param>
        public GeneratorHelper(IWeirdFeirdSettings settings)
        {
            this._settings = settings;
        }

        #endregion Constructors

        #region Properties

        private IWeirdFeirdSettings _settings;

        private IDictionary<string, Regex> _generatorPatterns;

        /// <summary>
        /// Gets the list of regular expressions to identify generator patterns.
        /// </summary>
        public IDictionary<string, Regex> GeneratorPatterns
        {
            get
            {
                if (this._generatorPatterns == null || !this._generatorPatterns.Any())
                {
                    this._generatorPatterns = this._settings
                                                  .Generators
                                                  .Cast<GeneratorElement>()
                                                  .ToDictionary(p => p.Key,
                                                                q => new Regex(q.Value,
                                                                               RegexOptions.Compiled | RegexOptions.IgnoreCase));
                }
                return this._generatorPatterns;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the feed generator.
        /// </summary>
        /// <param name="element">XElement generator instance.</param>
        /// <returns>Returns the feed generator.</returns>
        public FeedGenerator GetFeedGenerator(XElement element)
        {
            var generator = FeedGenerator.Unknown;
            try
            {
                var expression = this.GeneratorPatterns
                                     .SingleOrDefault(p => p.Value.IsMatch(element.Value));
                if (expression.Equals(default(KeyValuePair<string, Regex>)))
                    return FeedGenerator.Unknown;

                //  Key is expected as one of the feed generator enum value.
                FeedGenerator parsedGenerator;
                if (Enum.TryParse(expression.Key, true, out parsedGenerator))
                    generator = parsedGenerator;
            }
            catch { }
            return generator;
        }

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