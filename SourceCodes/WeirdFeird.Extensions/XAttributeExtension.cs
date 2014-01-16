using Aliencube.WeirdFeird.Exceptions;
using System;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Extensions
{
    /// <summary>
    /// This represents an entity that extends the <c>XElement</c> class.
    /// </summary>
    public static class XAttributeExtension
    {
        /// <summary>
        /// Converts the element value to <c>String</c> value.
        /// </summary>
        /// <param name="attribute">XElement instance.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns>Returns the converted <c>String</c> value.</returns>
        public static string GetString(this XAttribute attribute, string defaultValue = null)
        {
            return GetString(attribute, false, defaultValue);
        }

        /// <summary>
        /// Converts the element value to <c>String</c> value.
        /// </summary>
        /// <param name="attribute">XElement instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns>Returns the converted <c>String</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when attribute is NULL.</exception>
        /// <exception cref="RequiredFeedAttributeException">Throws when no attribute value is set.</exception>
        public static string GetString(this XAttribute attribute, bool required = false, string defaultValue = null)
        {
            if (attribute == null)
            {
                if (required)
                    throw new ArgumentNullException("attribute", "No attribute found");
                return defaultValue;
            }

            var value = attribute.Value;
            if (String.IsNullOrWhiteSpace(value))
            {
                if (required)
                    throw new RequiredFeedAttributeException("Value must be set");
                return defaultValue;
            }

            return value;
        }

        /// <summary>
        /// Converts the element value to <c>Int32</c> value.
        /// </summary>
        /// <param name="attribute">XElement instance.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns>Returns the converted <c>Int32</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when attribute is NULL.</exception>
        /// <exception cref="RequiredFeedAttributeException">Throws when no attribute value is set.</exception>
        public static int GetInt32(this XAttribute attribute, int defaultValue = Int32.MinValue)
        {
            return GetInt32(attribute, false, defaultValue);
        }

        /// <summary>
        /// Converts the element value to <c>Int32</c> value.
        /// </summary>
        /// <param name="attribute">XElement instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns>Returns the converted <c>Int32</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when attribute is NULL.</exception>
        /// <exception cref="RequiredFeedAttributeException">Throws when no attribute value is set.</exception>
        public static int GetInt32(this XAttribute attribute, bool required = false, int defaultValue = Int32.MinValue)
        {
            if (attribute == null)
            {
                if (required)
                    throw new ArgumentNullException("attribute", "No attribute found");
                return defaultValue;
            }

            var value = attribute.Value;
            if (String.IsNullOrWhiteSpace(value))
            {
                if (required)
                    throw new RequiredFeedAttributeException("Value must be set");
                return defaultValue;
            }

            int result;
            return Int32.TryParse(value, out result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the attribute value to <c>DateTime</c> value in UTC.
        /// </summary>
        /// <param name="attribute">XAttribute instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the converted <c>DateTime</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when attribute is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no attribute value is set.</exception>
        public static DateTime GetDateTime(this XAttribute attribute, bool required = false)
        {
            if (attribute == null)
            {
                if (required)
                    throw new ArgumentNullException("attribute", "No attribute found");
                return DateTime.MinValue;
            }

            var value = attribute.Value;
            if (String.IsNullOrWhiteSpace(value))
            {
                if (required)
                    throw new RequiredFeedElementException("Value must be set");
                return DateTime.MinValue;
            }

            DateTime result;
            return DateTime.TryParse(value, out result) ? result.ToUniversalTime() : DateTime.MinValue;
        }
    }
}