using Aliencube.WeirdFeird.Extensions;
using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace Aliencube.WeirdFeird.Extensions.Tests
{
    [TestFixture]
    public class XAttributeTest
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
        /// Checks the XAttribute instance returns the expected string value or not.
        /// </summary>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeValue">Attribute value.</param>
        /// <param name="required">Value that specifies whether it is required or not.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="expected">Excpected result.</param>
        [Test]
        [TestCase("test1", "This is test 1", true, null, true)]
        [TestCase("test2", "This is test 2", false, null, true)]
        [TestCase("test3", "", false, "", true)]
        public void GetAttributeValueAsString_SendAttribute_StringValueReturned(string attributeName, string attributeValue, bool required, string defaultValue, bool expected)
        {
            var attribute = new XAttribute(attributeName, attributeValue);
            var result = attribute.GetString(required, defaultValue);

            Assert.AreEqual(expected, result == attributeValue);
        }

        /// <summary>
        /// Checks the XAttribute instance returns the expected integer value or not.
        /// </summary>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeValue">Attribute value.</param>
        /// <param name="required">Value that specifies whether it is required or not.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="expected">Excpected result.</param>
        [Test]
        [TestCase("test1", "1", true, 1, true)]
        [TestCase("test2", "2", false, 2, true)]
        [TestCase("test3", "", false, 1, true)]
        public void GetAttributeValueAsInt32_SendAttribute_Int32ValueReturned(string attributeName, string attributeValue, bool required, int defaultValue, bool expected)
        {
            var attribute = new XAttribute(attributeName, attributeValue);
            var result = attribute.GetInt32(required, defaultValue);

            Assert.AreEqual(expected, result == (String.IsNullOrWhiteSpace(attributeValue) ? defaultValue : Convert.ToInt32(attributeValue)));
        }

        /// <summary>
        /// Checks the XAttribute instance returns the expected boolean value or not.
        /// </summary>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeValue">Attribute value.</param>
        /// <param name="required">Value that specifies whether it is required or not.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="expected">Excpected result.</param>
        [Test]
        [TestCase("test1", "true", true, null, true)]
        [TestCase("test2", "false", false, null, true)]
        [TestCase("test3", "", false, false, true)]
        public void GetAttributeValueAsBoolean_SendAttribute_BooleanValueReturned(string attributeName, string attributeValue, bool required, bool defaultValue, bool expected)
        {
            var attribute = new XAttribute(attributeName, attributeValue);
            var result = attribute.GetBoolean(required, defaultValue);

            Assert.AreEqual(expected, result == (String.IsNullOrWhiteSpace(attributeValue) ? defaultValue : Convert.ToBoolean(attributeValue)));
        }

        /// <summary>
        /// Checks the XAttribute instance returns the expected datetime value or not.
        /// </summary>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeValue">Attribute value.</param>
        /// <param name="required">Value that specifies whether it is required or not.</param>
        /// <param name="expected">Excpected result.</param>
        [Test]
        [TestCase("test1", "Thu, 02 Jan 2014 03:36:29 +0000", true, true)]
        [TestCase("test2", "Thu, 02 Jan 2014 03:36:29 +0000", false, true)]
        [TestCase("test3", "", false, true)]
        public void GetAttributeValueAsDateTime_SendAttribute_DateTimeValueReturned(string attributeName, string attributeValue, bool required, bool expected)
        {
            var defaultValue = DateTime.MinValue;
            var attribute = new XAttribute(attributeName, attributeValue);
            var result = attribute.GetDateTime(required);

            Assert.AreEqual(expected, result == (String.IsNullOrWhiteSpace(attributeValue) ? defaultValue : Convert.ToDateTime(attributeValue).ToUniversalTime()));
        }

        #endregion Tests
    }
}