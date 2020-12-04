using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool liveMode = false;

            foreach (var item in args)
            {
                if (item == "-- live")
                {
                    liveMode = true;
                }
            }
            List<long> inputInts = LoadInts(liveMode);

            long a = 0, b = 0, c = 0, d = 0, e = 0;

            for (int i = 0; i < inputInts.Count; i++)
            {
                for (int j = i + 1; j < inputInts.Count; j++)
                {
                    if (inputInts[i] + inputInts[j] == 2020)
                    {
                        a = inputInts[i];
                        b = inputInts[j];
                    }
                    for (int h = j + 1 + 1; h < inputInts.Count; h++)
                    {
                        if (inputInts[i] + inputInts[j] + inputInts[h] == 2020)
                        {
                            c = inputInts[i];
                            d = inputInts[j];
                            e = inputInts[h];
                        }
                    }
                }
            }

            Console.WriteLine("a={0}, b={1}, m={2}", a, b, a * b);
            Console.WriteLine("c={0}, d={1}, e={2}, m={3}, {3}", c, d, e, c * d * e);
        }


        static private List<long> LoadInts(bool liveMode)
        {
            string fileName = "test_input.txt";
            if (liveMode)
            {
                fileName = "input.txt";
            }
            string[] vs = File.ReadAllLines(fileName);
            List<long> result = new List<long>();
            foreach (string item in vs)
            {
                result.Add(Int64.Parse(item));
            }

            return result;
        }
    }
}
