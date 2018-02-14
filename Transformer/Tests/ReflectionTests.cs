using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Transformer.Messages;

namespace Transformer.Tests
{
    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public async Task Transform_To_String()
        {
            // Arrange
            var transformer = TransformerFactory.Create<Generic, string>();

            // Act
            var result = await transformer.Transform(new Generic {Name = "Krizanac, Matt"});

            // Assert
            StringAssert.AreEqualIgnoringCase("hello world", result);
        }

        [Test]
        public async Task Transform_To_Output()
        {
            // Arrange
            var transformer = TransformerFactory.Create<Generic, Output>();

            // Act
            var result = await transformer.Transform(new Generic {Name = "Krizanac, Matt"});

            // Assert
            StringAssert.AreEqualIgnoringCase("matt", result.FirstName);
            StringAssert.AreEqualIgnoringCase("krizanac", result.LastName);
        }

        [Test]
        public void Transform_MultipleMappings()
        {
            Assert.Throws<ArgumentException>(() => TransformerFactory.Create<int, int>());
        }

        [Test]
        public void Transform_NoMappings()
        {
            Assert.Throws<ArgumentException>(() => TransformerFactory.Create<long, int>());
        }

        [Test]
        public async Task Validate_InvalidName()
        {
            // arrange
            var transformer = TransformerFactory.Create<Generic, Output>();

            // Act
            var result = await transformer.Validate(new Generic { Name = "Krizanac Matt" });

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task Validate_ValidName()
        {
            // arrange
            var transformer = TransformerFactory.Create<Generic, Output>();

            // Act
            var result = await transformer.Validate(new Generic { Name = "Krizanac, Matt" });

            // Assert
            Assert.AreEqual(0, result.Count());
        }
    }
}