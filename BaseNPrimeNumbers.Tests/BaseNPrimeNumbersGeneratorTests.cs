using BaseNPrimeNumbers.Exceptions;
using BaseNPrimeNumbers.Interfaces;
using BaseNPrimeNumbers.Tests.Helpers;
using NUnit.Framework;

namespace BaseNPrimeNumbers.Tests
{
    public class BaseNPrimeNumbersGeneratorTests
    {
        IBaseNPrimeNumbersGenerator baseNPrimeGenerator;
        [SetUp]
        public void Setup()
        {
            baseNPrimeGenerator = new BaseNPrimeNumbersGenerator();
        }

        [Test]
        [TestCase("0", "")]
        [TestCase("5", "2,3,5,7,B")]
        [TestCase("A", "2,3,5,7,B,10,14,16,1A,23")]
        [TestCase("10", "2,3,5,7,B,10,14,16,1A,23,25,2B,32")]
        public void GenerateBase13PrimeNumbersSmallSequences(string base13Number, string expectedResult)
        {
            //act
            var generatedResultArr = baseNPrimeGenerator.GeneratePrimeNumbers(base13Number);
            var generatedResult = string.Join(',', generatedResultArr);

            //assert
            Assert.AreEqual(expectedResult, generatedResult);
        }

        [Test]
        [TestCase("5BC", "8a3222c4db17173e3162cdbd6a4abe8b")] //1000
        [TestCase("2378", "b432ccbce5b9261babf0c9642c82636d")] //5000
        [TestCase("4723", "71991f3238503a70c516b15968eaa520")] //10000
        [TestCase("199B2", "225d9730a83757894d8d87363a8680b5")] //50000
        [TestCase("36694", "ad9e05d6d310dcd80d26d322457bddb0")] //100000
        public void GenerateBase13PrimeNumbersBigSequences(string base13Number, string expectedResult)
        {
            //act
            var generatedResultArr = baseNPrimeGenerator.GeneratePrimeNumbers(base13Number);
            var generatedResult = string.Join(", ", generatedResultArr);
            string hashResult = CryptoHelper.GetMd5Hash(generatedResult);
            //assert
            Assert.AreEqual(expectedResult, hashResult);
        }

        [Test]
        [TestCase("-1")]
        [TestCase("-5")]
        [TestCase("-5BC")]
        [TestCase("-199B2")]
        public void GenerateNegativeAmountOfPrimesShouldThrowException(string base13Number)
        {
            //act
            //assert
            Assert.Throws<InvalidBaseNValueException>(() => baseNPrimeGenerator.GeneratePrimeNumbers(base13Number));
        }

    }
}
