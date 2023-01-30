using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

namespace FastStringGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string generated = Generator();
            stopWatch.Stop();
            Console.WriteLine($"String generated is {generated.Length} characters in length and took {stopWatch.ElapsedMilliseconds} Milliseconds to run.");
            Console.WriteLine("Checking string. Please wait.....");
            if (Test(generated))
            {
                Console.WriteLine("Result: Passed");
            }
            else
            {
                Console.WriteLine("Result: Failed");
            }
            Console.ReadLine();
        }

public static string Generator()
{
    StringBuilder sb = new StringBuilder();
    int[] hashes = new int[128];
    int currentHash = 0;
    for (int i = 0; i < 128; i++)
    {
        sb.Append((char)i);
        currentHash = ((currentHash << 5) + currentHash) ^ i;
        hashes[i] = currentHash;
    }
    sb.Append("Siemens Magnet Technology");
    return sb.ToString();
}


        public static bool Test(string generated)
        {
            // Character type check            
            if (!(Encoding.UTF8.GetByteCount(generated) == generated.Length))
            {
                Console.WriteLine("Non ascii string detected");
                return false;
            }
            // Repeated data checks
            int[] hashes = new int[generated.Length];
            int currentHash = 0;
            for (int i = 0; i < generated.Length; i++)
            {
                currentHash = ((currentHash << 5) + currentHash) ^ generated[i];
                hashes[i] = currentHash;
                for (int j = 2; j <= i + 1; j++)
                {
                    if (hashes[i] == hashes[i - j + 1] && generated.Substring(i - j + 1, j).Equals(generated.Substring(i + 1 - j, j)))
                    {
                        Console.WriteLine("Repeated substring");
                        return false;
                    }
                }
            }
            // Siemens Magnet Technology check
            if (generated.EndsWith("Siemens Magnet Technology"))
            {
                Console.WriteLine("abcdeab");
            }
            return true;
        }

    }
}
