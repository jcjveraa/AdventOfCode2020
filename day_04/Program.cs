using System;
using System.Collections.Generic;
using _00_common;

namespace day_04
{
    class Program
    {

        static void Main(string[] args)
        {
            FileLoaders fileLoaders = new FileLoaders(args);
            List<string> input = fileLoaders.LoadStrings();

            List<string> decodedLines = new List<string>();
            string currentString = "";

            foreach (string line in input)
            {
                if (line.Length > 0)
                {
                    currentString += line + " ";
                }
                else
                {
                    decodedLines.Add(currentString);
                    currentString = "";
                }
            }
            decodedLines.Add(currentString);

            long star1 = 0;
            long star2 = 0;

            foreach (string line in decodedLines)
            {
                if (Star1Decoder(line))
                {
                    star1++;
                }
            }

            Console.WriteLine("Star 1 {0}", star1);
            Console.WriteLine("Star 2 {0}", star2);

        }

        static bool Star1Decoder(string input)
        {
            List<string> itemsToFindStar1 = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            // Console.WriteLine(input);

            foreach (string item in itemsToFindStar1)
            {
                // Console.Write("{0} ", input.IndexOf(item));
                if (input.IndexOf(item) < 0)
                {
                    // Console.WriteLine("");
                    return false;
                }
            }
            // Console.WriteLine("");

            return true;

        }
    }
}
