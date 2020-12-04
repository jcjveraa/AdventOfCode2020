using System;
using System.Collections.Generic;
using System.IO;

namespace day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<long> lists = LoadTestInts();

            
        }

        static private List<long> LoadTestInts()
        {
            string[] vs = File.ReadAllLines("test_input.txt");
            List<long> result = new List<long>();
            foreach (string item in vs)
            {
                result.Add(Int64.Parse(item));
            }

            return result;
        }
    }
}
