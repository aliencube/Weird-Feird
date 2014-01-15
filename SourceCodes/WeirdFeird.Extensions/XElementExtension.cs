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
        /// <returns>Returns the attribute from the element.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="ArgumentNullException">Throws when attribute is NULL.</exception>
        public static XAttribute GetAttribute(this XElement element, string attributeName)
        {
            if (element == null)
                throw new ArgumentNullException("element", "No element found");

            var attribute = element.Attribute(attributeName);
            if (attribute == null)
                throw new RequiredFeedAttributeException("No attribute found");

            return attribute;
        }

        /// <summary>
        /// Converts the element value to <c>String</c> value.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the converted <c>String</c> value.</returns>
        public static string ToString(this XElement element, bool required = false)
        {
            return ToString(element, null, required);
        }

        /// <summary>
        /// Converts the element value to <c>String</c> value.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the converted <c>String</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no element value is set.</exception>
        public static string ToString(this XElement element, string defaultValue = null, bool required = false)
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
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the converted <c>Int32</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no element value is set.</exception>
        public static int ToInt32(this XElement element, int defaultValue = Int32.MinValue, bool required = false)
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
        /// Converts the element value to <c>UpdatePeriod</c> enum value.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <param name="defaultValue">Default value to return. Default value is <c>UpdatePeriod.Daily</c>.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the converted <c>UpdatePeriod</c> enum value.</returns>
        /// <exception cref="ArgumentNullException">Throws when element is NULL.</exception>
        /// <exception cref="RequiredFeedElementException">Throws when no element value is set.</exception>
        public static UpdatePeriod ToUpdaetPeriod(this XElement element, UpdatePeriod defaultValue = UpdatePeriod.Daily, bool required = false)
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

    /// <summary>
    /// This represents an entity that extends the <c>XElement</c> class.
    /// </summary>
    public static class XAttributeExtension
    {
        /// <summary>
        /// Converts the element value to <c>String</c> value.
        /// </summary>
        /// <param name="attribute">XElement instance.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the converted <c>String</c> value.</returns>
        public static string ToString(this XAttribute attribute, bool required = false)
        {
            return ToString(attribute, null, required);
        }

        /// <summary>
        /// Converts the element value to <c>String</c> value.
        /// </summary>
        /// <param name="attribute">XElement instance.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the converted <c>String</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when attribute is NULL.</exception>
        /// <exception cref="RequiredFeedAttributeException">Throws when no attribute value is set.</exception>
        public static string ToString(this XAttribute attribute, string defaultValue = null, bool required = false)
        {
            if (attribute == null)
            {
                if (required)
                    throw new ArgumentNullException("attribute", "No element found");
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
        /// <param name="required">Value that specifies whether this is required or not. Default value is <c>False</c>.</param>
        /// <returns>Returns the converted <c>Int32</c> value.</returns>
        /// <exception cref="ArgumentNullException">Throws when attribute is NULL.</exception>
        /// <exception cref="RequiredFeedAttributeException">Throws when no attribute value is set.</exception>
        public static int ToInt32(this XAttribute attribute, int defaultValue = Int32.MinValue, bool required = false)
        {
            if (attribute == null)
            {
                if (required)
                    throw new ArgumentNullException("attribute", "No element found");
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
    }
}