using System;
using System.Collections.Generic;

namespace day_08
{
    class Solutions
    {
        public Solutions(List<string> input)
        {
            var ranTillTheEnd = false;
            int accumulator = TestForLoops(input, ref ranTillTheEnd);

            Console.WriteLine("Part 1 answer is {0}, ran tille end is {1}", accumulator, ranTillTheEnd);

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].StartsWith('a'))
                {
                    continue;
                }

                if (input[i].StartsWith('j'))
                {
                    input[i] = input[i].Replace('j', 'n');
                    accumulator = TestForLoops(input, ref ranTillTheEnd);
                    if (ranTillTheEnd)
                    {
                        break;
                    }
                    input[i] = input[i].Replace('n', 'j');
                    continue;
                }
                if (input[i].StartsWith('n'))
                {
                    input[i] = input[i].Replace('n', 'j');

                    accumulator = TestForLoops(input, ref ranTillTheEnd);
                    if (ranTillTheEnd)
                    {
                        break;
                    }
                    input[i] = input[i].Replace('j', 'n');
                    continue;
                }
            }

            Console.WriteLine("Part 2 answer is {0}, ran tille end is {1}", accumulator, ranTillTheEnd);
        }

        private static int TestForLoops(List<string> input, ref bool ranTillTheEnd)
        {
            var currentLine = 0;
            var accumulator = 0;
            var visitedLines = new List<int>();

            while (true && currentLine < input.Count)
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

            ranTillTheEnd = currentLine == input.Count;

            return accumulator;
        }
    }
}
