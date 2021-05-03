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
        private const UInt64 V = 11000000000000000000;
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
                { 11, (n) => n + Six },
                { 12, (n) => n + Two },

            };

            //Azure.Response<ShareInfo> stream = client.Create(new ShareCreateOptions());

            StreamWriter swr = new StreamWriter(@"H:\TociPrime.txt");
            StreamWriter swr8 = new StreamWriter(@"H:\TociPrimes.txt");

            for (; ; )
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

                        if (N.ToString().Length > 19)
                        {
                            N = N | V;
                            SaveToFile(N.ToString().Substring(1, 1), swr); 
                            SaveToFile(N, swr8);
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
