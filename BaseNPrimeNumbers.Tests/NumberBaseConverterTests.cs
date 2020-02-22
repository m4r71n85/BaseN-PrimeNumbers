using BaseNPrimeNumbers.Exceptions;
using BaseNPrimeNumbers.Helpers;
using BaseNPrimeNumbers.Interfaces;
using NUnit.Framework;

namespace BaseNPrimeNumbers.Tests
{
    public class BaseNPrimeNumbersTests
    {
        private INumberBaseConverter baseConverter;
        readonly int numberBase = 13;
        readonly string baseSequence = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        [SetUp]
        public void Setup()
        {
            baseConverter = new NumberBaseConverter(numberBase, baseSequence);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(99999)]
        public void ConvertFromBase10ToBase13AndBack(int base10Number)
        {
            //act
            var base13 = baseConverter.ToBaseN(base10Number);
            var base10 = baseConverter.ToBase10(base13);

            //assert
            Assert.AreEqual(base10Number, base10);
        }

        [Test]
        [TestCase(0, "0")]
        [TestCase(433, "274")]
        [TestCase(866, "518")]
        [TestCase(1299, "78C")]
        [TestCase(1732, "A33")]
        [TestCase(2165, "CA7")]
        [TestCase(2598, "124B")]
        [TestCase(3031, "14C2")]
        [TestCase(3464, "1766")]
        [TestCase(99999, "36693")]
        public void ManualAssertConversionInBothDirections(int base10Number, string base13Number)
        {
            //act
            var base10To13 = baseConverter.ToBaseN(base10Number);
            var base13To10 = baseConverter.ToBase10(base13Number);

            //assert
            Assert.AreEqual(base10To13, base13Number);
            Assert.AreEqual(base13To10, base10Number);
        }

        [Test]
        [TestCase(-1)]
        public void CheckNegativeNumbersShouldThrowException(int base10Number)
        {
            //act
            //assert
            Assert.Throws<ConvertNegativeNumberException>(() => baseConverter.ToBaseN(base10Number));
        }
    }
}