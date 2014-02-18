using Aliencube.WeirdFeird.Enums;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Helpers.Interfaces
{
    /// <summary>
    /// This provides interfaces to the GeneratorHelper class.
    /// </summary>
    public interface IGeneratorHelper : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets the list of regular expressions to identify generator patterns.
        /// </summary>
        IDictionary<string, Regex> GeneratorPatterns { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the feed generator.
        /// </summary>
        /// <param name="element">XElement generator instance.</param>
        /// <returns>Returns the feed generator.</returns>
        FeedGenerator GetFeedGenerator(XElement element);

        #endregion Methods
    }
}