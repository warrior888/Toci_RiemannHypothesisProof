using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Toci.PrimeNumbers
{
    class Program
    {
        static UInt64 Two = 2;
        static UInt64 MinusTwo = 0;
        static UInt64 Four = 4;
        static UInt64 Six = 6;
        static UInt64 Eight = 8;
        static UInt64 Ten = 10;
        static UInt64 N = 11;
        static int Length = 3;

        static void Main(string[] args)
        {
            Dictionary<int, Func<UInt64, UInt64>> NextPrimeNumber = new Dictionary<int, Func<UInt64, UInt64>>()
            {
                { 1, (n) => n + Two },
                { 2, (n) => n + Four },
                { 3, (n) => n + Two },
                { 4, (n) => n + Four },
                { 5, (n) => n + Six },
                { 6, (n) => n + Two },
                { 7, (n) => n + Six },
                { 8, (n) => n + Six },
                { 9, (n) => n + Four },
                { 10, (n) => n + Six },
                { 11, (n) => n + Six },
                { 12, (n) => n + Two },
                { 13, (n) => n + Six },
                { 14, (n) => n + Six },
                { 15, (n) => n + Four },
                { 16, (n) => n + Six },
                { 17, (n) => n + Six },
                { 18, (n) => n + Two },
                { 19, (n) => n + Six },
                { 20, (n) => n + Four },
            };

            StreamWriter swr = new StreamWriter(@"D:\Toci\Primes.txt");

            for (; ; )
            {
                foreach (KeyValuePair<int, Func<UInt64, UInt64>> next in NextPrimeNumber.OrderBy(n => n.Key))
                {
                    if (N.ToString().Length > Length)
                    {
                        Length = N.ToString().Length;

                        Two = 2 + Two * 10;
                        MinusTwo = 0;
                        //MinusTwo = 2 + MinusTwo * 10;
                        Four = 4 + Four * 10;
                        Six = 6 + Six * 10;
                        Eight = 8 + Eight * 10;
                        Ten = 10 + Ten * 10;
                    }

                    try
                    {
   
                            N = next.Value(N);
                            SaveToFile(N, swr);
                        
                        
                    }
                    catch
                    {
                        swr.Close();
                        return;
                    }
                }
            }
        }

        static void SaveToFile(UInt64 N, StreamWriter swr)
        {
            swr.WriteLine(N);
        }
    }
}
