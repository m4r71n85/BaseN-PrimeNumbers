using BaseNPrimeNumbers.Exceptions;
using BaseNPrimeNumbers.Interfaces;
using System;

namespace BaseNPrimeNumbers.Helpers
{
    public class NumberBaseConverter : INumberBaseConverter
    {
        private readonly string baseSequence;
        private readonly int numberBase;

        public NumberBaseConverter(int numberBase, string baseSequence)
        {
            this.numberBase = numberBase;
            this.baseSequence = baseSequence.Substring(0, numberBase);
        }

        public string ToBaseN(int val)
        {
            if (val < 0) throw new ConvertNegativeNumberException();

            string result = string.Empty;

            do
            {
                result = baseSequence[val % numberBase] + result;
                val /= numberBase;
            }
            while (val > 0);

            return result;
        }

        public int ToBase10(string str)
        {
            double result = 0;
            for (int idx = 0; idx < str.Length; idx++)
            {
                var idxOfChar = baseSequence.IndexOf(str[idx]);
                result += idxOfChar * Math.Pow(numberBase, (str.Length - 1) - idx);
            }

            return (int)result;
        }
    }
}
