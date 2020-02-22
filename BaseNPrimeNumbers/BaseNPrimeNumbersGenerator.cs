using BaseNPrimeNumbers.Exceptions;
using BaseNPrimeNumbers.Helpers;
using BaseNPrimeNumbers.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace BaseNPrimeNumbers
{
    public class BaseNPrimeNumbersGenerator : IBaseNPrimeNumbersGenerator
    {
        private readonly INumberBaseConverter baseConverter;
        private readonly IPrimeNumbersGenerator primeNumbers;

        public BaseNPrimeNumbersGenerator(INumberBaseConverter baseConverter = null,
            IPrimeNumbersGenerator primeNumbers = null, IConfiguration config = null)
        {
            config = config ?? new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json", true, true)
                      .Build();
            var numbersBase = int.Parse(config["BaseNPrimeNumbers:NumbersBase"]);
            var baseSequence = config["BaseNPrimeNumbers:BaseSequence"];
            
            this.primeNumbers = primeNumbers ?? new PrimeNumbersGenerator();
            this.baseConverter = baseConverter ?? new NumberBaseConverter(numbersBase, baseSequence);
        }

        public IEnumerable<string> GeneratePrimeNumbers(string firstNPrimes)
        {
            var nPrimes = baseConverter.ToBase10(firstNPrimes);
            if (nPrimes < 0) throw new InvalidBaseNValueException();

            var base10Primes = primeNumbers.GenerateNPrimes(nPrimes);
            return base10Primes.Select(p => baseConverter.ToBaseN(p));
        }
    }
}
