using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                    if (Star2Decoder(line))
                    {
                        star2++;
                    }
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

        static bool Star2Decoder(string input)
        {
            var split = input.TrimEnd().Split(' ');
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            foreach (string item in split)
            {
                var split2 = item.Split(':');
                // Console.WriteLine(item);
                keyValuePairs.Add(split2[0], split2[1]);
            }
            // "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
            if (Int32.Parse(keyValuePairs["byr"]) < 1920 || Int32.Parse(keyValuePairs["byr"]) > 2002)
            {
                return false;
            }

            if (Int32.Parse(keyValuePairs["iyr"]) < 2010 || Int32.Parse(keyValuePairs["iyr"]) > 2020)
            {
                return false;
            }

            if (Int32.Parse(keyValuePairs["eyr"]) < 2020 || Int32.Parse(keyValuePairs["eyr"]) > 2030)
            {
                return false;
            }

            string hgt = keyValuePairs["hgt"];
            if (hgt.EndsWith("cm") &&
             hgt.Length == 5)
            {
                var val = Int32.Parse(hgt.Substring(0, 3));
                if (val < 150 || val > 193)
                {
                    return false;
                }
            }
            else if (hgt.EndsWith("in") && hgt.Length == 4)
            {
                var val = Int32.Parse(hgt.Substring(0, 2));
                if (val < 59 || val > 76)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


            string hclPattern = "#[0-9a-f]{6}";
            Regex regex = new Regex(hclPattern);
            if (!regex.Match(keyValuePairs["hcl"]).Success)
            {
                return false;
            }

            string[] allowableEyes = "amb blu brn gry grn hzl oth".Split(' ');
            if (!allowableEyes.Any(ae => ae == keyValuePairs["ecl"]))
            {
                return false;
            }

            string pidPattern = "^[0-9]{9}$";
            Regex regex2 = new Regex(pidPattern);
            if (!regex2.Match(keyValuePairs["pid"]).Success)
            {
                return false;
            }

            return true; // TODO
        }
    }
}
