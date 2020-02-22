using System.Collections.Generic;

namespace BaseNPrimeNumbers.Interfaces
{
    /// <summary>
    /// A facade interface handling changing number base and
    /// generating an array of prime numbers in base N format
    /// </summary>
    public interface IBaseNPrimeNumbersGenerator
    {
        /// <summary>
        /// Generates an array of prime numbers
        /// </summary>
        /// <param name="firstNPrimes">Specify the amount of 
        /// prime numbers to be generated</param>
        /// <returns>An array of prime numbers</returns>
        IEnumerable<string> GeneratePrimeNumbers(string firstNPrimes);
    }
}