using BaseNPrimeNumbers.Helpers;
using BaseNPrimeNumbers.Interfaces;
using BaseNPrimeNumbers.Tests.Helpers;
using NUnit.Framework;

namespace BaseNPrimeNumbers.Tests
{
    public class PrimeNumbersGeneratorTests
    {
        private IPrimeNumbersGenerator primeGenerator;

        [SetUp]
        public void Setup()
        {
            primeGenerator = new PrimeNumbersGenerator();
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(99999)]
        public void AssertAmountOfGeneratedPrimes(int nPrimes)
        {
            //act
            var primes = primeGenerator.GenerateNPrimes(nPrimes);

            //assert
            Assert.AreEqual(primes.Length, nPrimes);
        }

        [Test]
        [TestCase(0, "")]
        [TestCase(1, "2")]
        [TestCase(5, "2,3,5,7,11")]
        [TestCase(10, "2,3,5,7,11,13,17,19,23,29")]
        [TestCase(15, "2,3,5,7,11,13,17,19,23,29,31,37,41,43,47")]
        public void AssertCorrectSmallPrimesList(int nPrimes, string expectedResult)
        {
            //act
            var primes = primeGenerator.GenerateNPrimes(nPrimes);
            var result = string.Join(',', primes);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(1000, "33f13c3005ec7395920099b99203135a")]
        [TestCase(5000, "0246b299fb265c06fafd3ca9a7e23665")]
        [TestCase(10000, "129b0a09006c64aefc9a14019c3542a2")]
        [TestCase(50000, "87d283ff0e7863756a1df0fd0ed54298")]
        [TestCase(100000, "27b53e6254b3054503a250b92947668a")]
        public void AssertCorrectBigPrimesList(int nPrimes, string expectedResultHash)
        {
            //act
            var primes = primeGenerator.GenerateNPrimes(nPrimes);
            var result = string.Join(',', primes);
            string resultHash = CryptoHelper.GetMd5Hash(result);

            //assert
            Assert.AreEqual(expectedResultHash, resultHash);
        }
    }
}