
namespace BaseNPrimeNumbers.Interfaces
{
    /// <summary>
    /// An optimized prime number array generator
    /// </summary>
    public interface IPrimeNumbersGenerator
    {
        /// <summary>
        /// Generates an array of prime numbers
        /// </summary>
        /// <param name="n">The amount of prime numbers to be
        /// generated</param>
        /// <returns>An array of prime numbers</returns>
        int[] GenerateNPrimes(int n);
    }
}
