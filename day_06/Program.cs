using System;
using System.Collections.Generic;
using System.Linq;
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
            var part1result = new List<int>();
            var part2buffer = new List<string>();
            int part2counter = 0;

            foreach (string line in input)
            {
                if (line.Trim().Length == 0)
                {
                    StoreResults(ref set, part1result, ref part2buffer, ref part2counter);
                }
                else
                {
                    part2buffer.Add(line);
                    foreach (char c in line)
                    {
                        set.Add(c);
                    }
                }
            }
            StoreResults(ref set, part1result, ref part2buffer, ref part2counter);

            var part1 = part1result.Aggregate((x, next) => x + next);
            Console.WriteLine("Part 1 result is {0}", part1);
            Console.WriteLine("Part 2 result is {0}", part2counter);
        }

        private static void StoreResults(ref HashSet<char> set, List<int> part1result, ref List<string> part2buffer, ref int part2counter)
        {
            part1result.Add(set.Count);
            foreach (char c in set)
            {
                if (CharPresentInAllLines(c, part2buffer))
                {
                    part2counter++;
                }
            }

            set = new HashSet<char>();
            part2buffer = new List<string>();
        }

        static bool CharPresentInAllLines(char c, List<string> strL)
        {

            foreach (var line in strL)
            {
                if (!line.Any(x => x == c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
