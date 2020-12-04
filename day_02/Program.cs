using System;
using System.Collections.Generic;
using _00_common;

namespace day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoaders fileLoaders = new FileLoaders(args);
            List<string> input = fileLoaders.LoadStrings();

            var countValid = 0;
            var countValidTwo = 0;

            foreach (var item in input)
            {
                string[] components = item.Split(' ');
                int minNumber = Int32.Parse(components[0].Split('-')[0]);
                int maxNumber = Int32.Parse(components[0].Split('-')[1]);

                char letter = components[1].ToCharArray()[0];

                string password = components[2];

                int numTimes = countCharOccurrence(letter, password);
                // Console.WriteLine(numTimes);
                bool test = numTimes >= minNumber && numTimes <= maxNumber;
                if (test)
                {
                    countValid++;
                }

                if (starTwo(letter, password, minNumber, maxNumber))
                {
                    countValidTwo++;
                }

            }

            Console.WriteLine("Number of valid items for star 1 is {0}", countValid);
            Console.WriteLine("Number of valid items for star 2 is {0}", countValidTwo);
        }

        static int countCharOccurrence(char c, string s)
        {
            int i = 0, j = 0;

            while (true)
            {
                j = s.IndexOf(c, j);
                if (j < 0)
                {
                    break;
                }
                // Console.Write(j);
                j++;
                i += 1;
            }
            return i;
        }

        static bool starTwo(char c, string s, int pos1, int pos2)
        {
            bool test1 = s.ToCharArray()[pos1 - 1] == c;
            bool test2 = s.ToCharArray()[pos2 - 1] == c;
            return test1 ^ test2; // ^= XOR
        }
    }
}
