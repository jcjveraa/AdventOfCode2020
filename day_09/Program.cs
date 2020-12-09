using System;
using System.Collections.Generic;
using _00_common;

namespace day_09
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoaders fileLoaders = new FileLoaders(args);
            List<string> input = fileLoaders.LoadStrings();

            Solutions s = new Solutions(input);

            Console.WriteLine("day_09 output finished");
        }
    }
}
