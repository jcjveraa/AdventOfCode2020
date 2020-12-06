using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _00_common;

namespace day_06
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoaders fileLoaders = new FileLoaders(args);
            List<string> input = fileLoaders.LoadStrings();

            var set = new HashSet<char>();
            var result = new List<int>();
            foreach (string line in input)
            {
                // Console.WriteLine(line);
                if (line.Trim().Length == 0)
                {
                    result.Add(set.Count);
                    set = new HashSet<char>();
                }
                else
                {
                    foreach (char c in line)
                    {
                        set.Add(c);
                    }
                }
            }
            result.Add(set.Count);

            var part1 = result.Aggregate((x, next) => x + next);
            Console.WriteLine("Part 1 result is {0}", part1);
        }
    }
}
