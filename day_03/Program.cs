using System;
using System.Collections.Generic;
using System.Linq;
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

            long star1 = Solve(input, inputWidth, currentPosition, 1);

            List<int> star2inputRight = new List<int> { 1, 3, 5, 7, 1 };
            List<int> star2inputDown = new List<int> { 1, 1, 1, 1, 2 };

            var result = star2inputRight.Zip(star2inputDown, (r, d) => Solve(input, inputWidth, r, d));

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            long star2 = result.Aggregate((x, next) => x * next);


            Console.WriteLine("Star 1 {0}", star1);
            Console.WriteLine("Star 2 {0}", star2);
        }

        private static long Solve(List<string> input, int inputWidth, int skipRight, int skipDown)
        {
            long result = 0;
            int currentPosition = skipRight;
            int currentPositionDown = 1;
            foreach (string line in input)
            {
                if (currentPositionDown % skipDown == 0)
                {
                    int transposedPostion = currentPosition % inputWidth;
                    // Console.WriteLine(line + " {0} {1}", currentPosition, transposedPostion);
                    if (line.ToCharArray()[transposedPostion] == '#')
                    {
                        result++;
                    }

                    currentPosition += skipRight;
                }
                currentPositionDown++;
            }

            return result;
        }
    }
}
