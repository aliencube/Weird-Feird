using Aliencube.WeirdFeird.Extensions;
using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Extensions.Tests
{
    [TestFixture]
    public class XElementTest
    {
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        #endregion SetUp / TearDown

        #region Tests

        /// <summary>
        /// Checks the XElement instance returns the expected string value or not.
        /// </summary>
        /// <param name="elementName">Element name.</param>
        /// <param name="elementValue">Element value.</param>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeValue">Attribute value.</param>
        /// <param name="required">Value that specifies whether it is required or not.</param>
        /// <param name="expected">Excpected result.</param>
        [Test]
        [TestCase("element1", "elementValue1", "attribute1", "attributeValue1", true, true)]
        [TestCase("test2", "elementValue2", "attribute2", "attributeValue2", false, true)]
        [TestCase("test3", "elementValue3", "attribute3", "", false, true)]
        public void GetAttribute_SendElement_AttributeReturned(string elementName, string elementValue, string attributeName, string attributeValue, bool required, bool expected)
        {
            var element = new XElement(elementName, new XAttribute(attributeName, attributeValue)) { Value = elementValue};
            if (String.IsNullOrWhiteSpace(attributeValue))
                element = new XElement(elementName) { Value = elementValue };

            var result = element.GetAttribute(attributeName, required);

            Assert.AreEqual(expected, String.IsNullOrWhiteSpace(attributeValue) ? result == null : result != null);
        }

        /// <summary>
        /// Checks the XElement instance returns the expected string value or not.
        /// </summary>
        /// <param name="elementName">Element name.</param>
        /// <param name="elementValue">Element value.</param>
        /// <param name="required">Value that specifies whether it is required or not.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="expected">Excpected result.</param>
        [Test]
        [TestCase("test1", "This is test 1", true, null, true)]
        [TestCase("test2", "This is test 2", false, null, true)]
        [TestCase("test3", "", false, "", true)]
        public void GetElementValueAsString_SendElement_StringValueReturned(string elementName, string elementValue, bool required, string defaultValue, bool expected)
        {
            var element = new XElement(elementName) { Value = elementValue };
            var result = element.GetString(required, defaultValue);

            Assert.AreEqual(expected, result == elementValue);
        }

        /// <summary>
        /// Checks the XElement instance returns the expected integer value or not.
        /// </summary>
        /// <param name="elementName">Element name.</param>
        /// <param name="elementValue">Element value.</param>
        /// <param name="required">Value that specifies whether it is required or not.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="expected">Excpected result.</param>
        [Test]
        [TestCase("test1", "1", true, 1, true)]
        [TestCase("test2", "2", false, 2, true)]
        [TestCase("test3", "", false, 1, true)]
        public void GetElementValueAsInt32_SendElement_Int32ValueReturned(string elementName, string elementValue, bool required, int defaultValue, bool expected)
        {
            var element = new XElement(elementName) { Value = elementValue };
            var result = element.GetInt32(required, defaultValue);

            Assert.AreEqual(expected, result == (String.IsNullOrWhiteSpace(elementValue) ? defaultValue : Convert.ToInt32(elementValue)));
        }

        /// <summary>
        /// Checks the XElement instance returns the expected boolean value or not.
        /// </summary>
        /// <param name="elementName">Element name.</param>
        /// <param name="elementValue">Element value.</param>
        /// <param name="required">Value that specifies whether it is required or not.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="expected">Excpected result.</param>
        [Test]
        [TestCase("test1", "true", true, null, true)]
        [TestCase("test2", "false", false, null, true)]
        [TestCase("test3", "", false, false, true)]
        public void GetElementValueAsBoolean_SendElement_BooleanValueReturned(string elementName, string elementValue, bool required, bool defaultValue, bool expected)
        {
            var element = new XElement(elementName) { Value = elementValue };
            var result = element.GetBoolean(required, defaultValue);

            Assert.AreEqual(expected, result == (String.IsNullOrWhiteSpace(elementValue) ? defaultValue : Convert.ToBoolean(elementValue)));
        }

        /// <summary>
        /// Checks the XElement instance returns the expected datetime value or not.
        /// </summary>
        /// <param name="elementName">Element name.</param>
        /// <param name="elementValue">Element value.</param>
        /// <param name="required">Value that specifies whether it is required or not.</param>
        /// <param name="expected">Excpected result.</param>
        [Test]
        [TestCase("test1", "Thu, 02 Jan 2014 03:36:29 +0000", true, true)]
        [TestCase("test2", "Thu, 02 Jan 2014 03:36:29 +0000", false, true)]
        [TestCase("test3", "", false, true)]
        public void GetElementValueAsDateTime_SendElement_DateTimeValueReturned(string elementName, string elementValue, bool required, bool expected)
        {
            var defaultValue = DateTime.MinValue;
            var element = new XElement(elementName) { Value = elementValue };
            var result = element.GetDateTime(required);

            Assert.AreEqual(expected, result == (String.IsNullOrWhiteSpace(elementValue) ? defaultValue : Convert.ToDateTime(elementValue).ToUniversalTime()));
        }

        #endregion Tests
    }
}