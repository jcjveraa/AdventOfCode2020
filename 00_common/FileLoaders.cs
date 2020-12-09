using System;
using System.IO;
using System.Collections.Generic;

namespace _00_common
{
    public class FileLoaders
    {
        public string fileName { get; set; }
        public FileLoaders(string[] programArgs)
        {
            bool liveMode = false;
            foreach (var item in programArgs)
            {
                if (item == "-- live")
                {
                    liveMode = true;
                }
            }

            fileName = "test_input.txt";
            if (liveMode)
            {
                fileName = "input.txt";
            }
        }

        public List<long> LoadInts()
        {
            string[] vs = File.ReadAllLines(fileName);
            List<long> result = new List<long>();
            foreach (string item in vs)
            {
                result.Add(Int64.Parse(item));
            }

            return result;
        }

        public List<string> LoadStrings()
        {
            string[] vs1 = File.ReadAllLines(fileName);
            List<string> vs = new List<string>(vs1);
            return vs;
        }


    }
    public class Helpers
    {
        public static void WriteToConsole<T>(IEnumerable<T> toWrite)
        {
            foreach (var item in toWrite)
            {
                Console.Write("{0}\t", item);
            }
            Console.WriteLine();
        }
    }
}
