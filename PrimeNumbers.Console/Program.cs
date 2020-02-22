using BaseNPrimeNumbers;
using Microsoft.Extensions.Configuration;
using System;

namespace PrimeNumbers
{
    class Program
    {
        public static void Main()
        {

            var config = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json", true, true)
                      .Build();
            var numbersBase = int.Parse(config["BaseNPrimeNumbers:NumbersBase"]);

            var primeGenerator = new BaseNPrimeNumbersGenerator();

            while (true)
            {
                Console.Write($"Generate N prime numbers (base {numbersBase}): ");
                var number = Console.ReadLine();
                var primeNumbers = primeGenerator.GeneratePrimeNumbers(number);
                Console.WriteLine(string.Join(", ", primeNumbers));


                Console.Write("Continue? (Yes: Enter / No: Escape)");
                var pressKey = Console.ReadKey(false);
                if (pressKey.Key == ConsoleKey.Escape) break;
            }
        }
    }
}
