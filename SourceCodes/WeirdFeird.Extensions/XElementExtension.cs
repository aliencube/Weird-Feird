using Aliencube.WeirdFeird.Exceptions;
using Aliencube.WeirdFeird.ViewModels.Enums;
using System;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Extensions
{
    /// <summary>
    /// This represents an entity that extends the <c>XElement</c> class.
    /// </summary>
    public static class XElementExtension
    {
        /// <summary>
        /// Gets the attribute from the element.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the attribute from the element.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="ArgumentNullException">Throws when attribute is NULL.</exception>
        public static XAttribute GetAttribute(this XElement element, string attributeName, bool required = false)
        {
            if (element == null)
                throw new ArgumentNullException("element", "No element found");

            var attribute = element.Attribute(attributeName);
            if (attribute == null)
            {
                if (required)
                    throw new RequiredFeedAttributeException("No attribute found");
            }

            return attribute;
        }

        /// <summary>
        /// Converts the element value to <c>String</c> value.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns>Returns the converted <c>String</c> value.</returns>
        public static string GetString(this XElement element, string defaultValue = null)
        {
            return GetString(element, false, defaultValue);
        }

        /// <summary>
        /// Converts the element value to <c>String</c> value.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns>Returns the converted <c>String</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no element value is set.</exception>
        public static string GetString(this XElement element, bool required = false, string defaultValue = null)
        {
            if (element == null)
            {
                if (required)
                    throw new ArgumentNullException("element", "No element found");
                return defaultValue;
            }

            var value = element.Value;
            if (String.IsNullOrWhiteSpace(value))
            {
                if (required)
                    throw new RequiredFeedElementException("Value must be set");
                return defaultValue;
            }

            return value;
        }

        /// <summary>
        /// Converts the element value to <c>Int32</c> value.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns>Returns the converted <c>Int32</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no element value is set.</exception>
        public static int GetInt32(this XElement element, int defaultValue = Int32.MinValue)
        {
            return GetInt32(element, false, defaultValue);
        }

        /// <summary>
        /// Converts the element value to <c>Int32</c> value.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns>Returns the converted <c>Int32</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no element value is set.</exception>
        public static int GetInt32(this XElement element, bool required = false, int defaultValue = Int32.MinValue)
        {
            if (element == null)
            {
                if (required)
                    throw new ArgumentNullException("element", "No element found");
                return defaultValue;
            }

            var value = element.Value;
            if (String.IsNullOrWhiteSpace(value))
            {
                if (required)
                    throw new RequiredFeedElementException("Value must be set");
                return defaultValue;
            }

            int result;
            return Int32.TryParse(value, out result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the element value to <c>Boolean</c> value.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns>Returns the converted <c>DateTime</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no element value is set.</exception>
        public static bool GetBoolean(this XElement element, bool required = false, bool defaultValue = false)
        {
            if (element == null)
            {
                if (required)
                    throw new ArgumentNullException("element", "No element found");
                return defaultValue;
            }

            var value = element.Value;
            if (String.IsNullOrWhiteSpace(value))
            {
                if (required)
                    throw new RequiredFeedElementException("Value must be set");
                return defaultValue;
            }

            bool result;
            return Boolean.TryParse(value, out result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the element value to <c>DateTime</c> value in UTC.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the converted <c>DateTime</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no element value is set.</exception>
        public static DateTime GetDateTime(this XElement element, bool required = false)
        {
            if (element == null)
            {
                if (required)
                    throw new ArgumentNullException("element", "No element found");
                return DateTime.MinValue;
            }

            var value = element.Value;
            if (String.IsNullOrWhiteSpace(value))
            {
                if (required)
                    throw new RequiredFeedElementException("Value must be set");
                return DateTime.MinValue;
            }

            DateTime result;
            return DateTime.TryParse(value, out result) ? result.ToUniversalTime() : DateTime.MinValue;
        }

        /// <summary>
        /// Converts the element value to <c>UpdatePeriod</c> enum value.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <param name="defaultValue">Default value to return. Default value is <c>UpdatePeriod.Daily</c>.</param>
        /// <returns>Returns the converted <c>UpdatePeriod</c> enum value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no element value is set.</exception>
        public static UpdatePeriod GetUpdaetPeriod(this XElement element, bool required = false, UpdatePeriod defaultValue = UpdatePeriod.Daily)
        {
            if (element == null)
            {
                if (required)
                    throw new ArgumentNullException("element", "No element found");
                return defaultValue;
            }

            var value = element.Value;
            if (String.IsNullOrWhiteSpace(value))
            {
                if (required)
                    throw new RequiredFeedElementException("Value must be set");
                return defaultValue;
            }

            UpdatePeriod result;
            return Enum.TryParse(value, true, out result) ? result : defaultValue;
        }
    }
}