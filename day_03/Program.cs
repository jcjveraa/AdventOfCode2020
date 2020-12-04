using System;
using System.Collections.Generic;
using _00_common;

namespace day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoaders fileLoaders = new FileLoaders(args);
            List<string> input = fileLoaders.LoadStrings();

            int inputWidth = input[0].Length;
            int currentPosition = 3;

            input.RemoveAt(0); // skip the first

            int star1 = 0;

            foreach (string line in input)
            {
                int transposedPostion = currentPosition % inputWidth;
                Console.WriteLine(line + " {0} {1}", currentPosition, transposedPostion);
                if (line.ToCharArray()[transposedPostion] == '#')
                {
                    star1++;
                }

                currentPosition += 3;
            }

            Console.WriteLine("Star 1 {0}", star1);
        }

    }
}
