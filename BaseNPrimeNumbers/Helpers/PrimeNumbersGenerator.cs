using BaseNPrimeNumbers.Interfaces;
using System;

namespace BaseNPrimeNumbers.Helpers
{
    public class PrimeNumbersGenerator : IPrimeNumbersGenerator
    {
        public int[] GenerateNPrimes(int n)
        {
            var primes = new int[n];
            int index = 0;
            int currentN = 2;

            if (n >= 1)
            {
                primes[index] = currentN; //2
                index++;
                currentN++; //3
            }

            if (n >= 2)
            {
                primes[index] = currentN; //2,3
                index++;
                currentN += 2; //5
            }

            while (index < n)
            {
                if (IsPrime(currentN, primes))
                {
                    primes[index] = currentN;
                    index++;
                }

                currentN += 2;

                //seems it optimizes the code a bit, but
                //I can't find documentation why this works
                //if (IsPrime(currentN, primes) && index<n)
                //{
                //    primes[index] = currentN;
                //    index++;
                //}

                //currentN += 4;
            }

            return primes;
        }

        static bool IsPrime(int checkNum, int[] primes)
        {
            int sqrtCheck = (int)Math.Sqrt(checkNum);

            foreach (var prime in primes)
            {
                if (prime > sqrtCheck)
                    break;
                if (checkNum % prime == 0)
                    return false;
            }

            if (checkNum % sqrtCheck == 0)
                return false;

            return true;
        }
    }
}
