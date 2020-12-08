using System;
using System.Collections.Generic;

namespace day_08
{
    class Solutions
    {
        public Solutions(List<string> input)
        {
            var currentLine = 0;
            var accumulator = 0;
            var visitedLines = new List<int>();

            while (true)
            {
                if (visitedLines.Contains(currentLine))
                {
                    break;
                }

                visitedLines.Add(currentLine);

                var charArr = input[currentLine].ToCharArray();

                var instruction = charArr[0];
                var sign = charArr[4] == '+' ? 1 : -1;
                var val = Int32.Parse(input[currentLine].Substring(5));

                if (instruction == 'n')
                {
                    currentLine++;
                    continue;
                }

                if (instruction == 'j')
                {
                    currentLine += sign * val;
                    continue;
                }

                if (instruction == 'a')
                {
                    accumulator += sign * val;
                    currentLine++;
                    continue;
                }
            }

            Console.WriteLine("Part 1 answer is {0}", accumulator);
        }
    }
}
