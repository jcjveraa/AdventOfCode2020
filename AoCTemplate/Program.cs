using System;
using System.Collections.Generic;
using _00_common;

namespace AoCTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoaders fileLoaders = new FileLoaders(args);
            List<string> input = fileLoaders.LoadStrings();

            Solutions s = new Solutions(input);

            Console.WriteLine("AoCTemplate output finished");
        }
    }
}
