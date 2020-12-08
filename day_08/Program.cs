using System;
using System.Collections.Generic;
using _00_common;

namespace day_08
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoaders fileLoaders = new FileLoaders(args);
            List<string> input = fileLoaders.LoadStrings();

            Solutions s = new Solutions(input);

            Console.WriteLine("day_08 output finished");
        }
    }
}
