//using Azure.Storage.Files.Shares.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toci.PrimeNumbers
{
    class Program
    {
        protected static void isPrime(string can)
        {
            UInt64 numToCheck = UInt64.Parse(can);
            Dictionary<UInt64, bool?> factors = CheckForPrime(numToCheck);

            if (factors.Count == 0)
            {
                Console.WriteLine($"{numToCheck} is prime.");
            }
            else
            {
                Console.WriteLine($"{numToCheck} is a composite number.");
                Console.WriteLine($"There are {factors.Count} factors in {numToCheck}.");

                IEnumerable<UInt64> primeFactors = from factor in factors
                                                where factor.Value == true
                                                select factor.Key;

                Console.WriteLine($"The largest prime factor is {primeFactors.Max()}");

                Console.WriteLine();
                Console.WriteLine("Here are all of the prime factors: ");

                foreach (var factor in primeFactors)
                {
                    Console.WriteLine(factor);
                }
            }
        }

        private static  Dictionary<UInt64, bool?> CheckForPrime(UInt64 num)
        {
            Dictionary<UInt64, bool?> output = new Dictionary<UInt64, bool?>();

            UInt64 max = num / 2;

            for (UInt64 i = 2; i <= max; i++)
            {
                if (num % i == 0)
                {
                    output.Add(i, null);
                }
            }

            if (output.Count > 0)
            {
                foreach (var factor in output.Keys.ToList())
                {
                    if (CheckForPrime(factor).Count == 0)
                    {
                        output[factor] = true;
                    }
                    else
                    {
                        output[factor] = false;
                    }
                }
            }

            return output;
        }

        private const UInt64 V = 11; //000000000000000000;
        static UInt64 Two = 2;
        static UInt64 MinusTwo = 2;
        static UInt64 Four = 4;
        static UInt64 Six = 6;
        static UInt64 Eight = 8;
        static UInt64 Ten = 10;
        static UInt64 N = 11;
        static int Length = 3;
        static StringBuilder stringBuilder = new StringBuilder();
        //static Azure.Storage.Files.Shares.ShareClient client = new Azure.Storage.Files.Shares.ShareClient("", "PrimeNumerToci.txt");

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
                { 8, (n) => n - MinusTwo },
                { 9, (n) => n + Six },
                { 10, (n) => n + Two },
                { 11, (n) => n + Four },
                //{ 12, (n) => n + Two },

            };

            //Azure.Response<ShareInfo> stream = client.Create(new ShareCreateOptions());

            StreamWriter swr = new StreamWriter(@"C:\Users\bzapa\source\repos\toci_phoenix\happy13\happy13\TociPrime.txt");
            StreamWriter swr8 = new StreamWriter(@"C:\Users\bzapa\source\repos\toci_phoenix\happy13\happy13\TociPrimes.txt");

            for (int i = 0; i < 20; i++)
            {
                foreach (KeyValuePair<int, Func<UInt64, UInt64>> next in NextPrimeNumber.OrderBy(n => n.Key))
                {
                    if (N.ToString().Length > Length)
                    {
                        Length = N.ToString().Length;

                        Two = Two + Two * 10;
                        MinusTwo += MinusTwo;
                        Four = Four + Four * 10;
                        Six = Six + Six * 10;
                        Eight = 8 + Eight * 10;
                        Ten = 10 + Ten * 10;
                    }

                    try
                    {
                        N = next.Value(N);

                        //if (N.ToString().Length > 19)
                        {
                            N = N | V;
                            //SaveToFile(N.ToString().Substring(1, 1), swr); 
                            //SaveToFile(N, swr8);

                            isPrime(N.ToString());
                            //stream.GetRawResponse().ContentStream.Write(UTF8Encoding.GetEncoding(852).GetBytes(N.ToString().Substring(1, 1)));
                        }
                    }
                    catch
                    {
                        swr.Close();
                        swr8.Close();
                    }
                }
            }
        }

        static void SaveToFile(UInt64 N, StreamWriter swr)
        {
            swr.WriteLine(N);
        }

        static void SaveToFile(string stringBuilder, StreamWriter swr)
        {

            swr.Write(stringBuilder);
        }
    }
}
