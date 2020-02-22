namespace BaseNPrimeNumbers.Interfaces
{
    /// <summary>
    /// Converts numbers from base 10 to any base 
    /// and from base n to base 10
    /// </summary>
    public interface INumberBaseConverter
    {
        int ToBase10(string str);
        string ToBaseN(int val);
    }
}