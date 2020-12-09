using System;
using System.Collections.Generic;
using System.Linq;
using _00_common;

namespace day_09
{
    class Solutions
    {
        public Solutions(List<string> input)
        {
            List<long> integerInput = new List<long>();
            foreach (var item in input)
            {
                integerInput.Add(Int64.Parse(item));
            }

            var preambleLength = 25;

            var numberQueue = new Queue<long>(preambleLength);

            for (int i = 0; i < preambleLength; i++)
            {
                numberQueue.Enqueue(integerInput[i]);
            }

            Helpers.WriteToConsole(numberQueue);

            long part1Answer = -1;

            for (int i = preambleLength; i < integerInput.Count; i++)
            {
                IEnumerable<long> allowableValues = GenerateAllowable(numberQueue);
                var thisValue = integerInput[i];
                if (allowableValues.Contains(thisValue))
                {
                    numberQueue.Dequeue();
                    numberQueue.Enqueue(thisValue);
                }
                else
                {
                    part1Answer = thisValue;
                    break;
                }
            }

            int targetIndex = integerInput.FindIndex(a => a == part1Answer);

            Console.WriteLine("Part 1 answer is {0}", part1Answer);
            var part2solution = Part2Solver(integerInput.Take(targetIndex), part1Answer);

            Console.WriteLine("Part 2 answer is {0}", part2solution.Max() + part2solution.Min());
        }

        private IEnumerable<long> GenerateAllowable(Queue<long> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = i + 1; j < items.Count; j++)
                {
                    yield return items.ElementAt(i) + items.ElementAt(j);
                }
            }

        }

        private IEnumerable<long> Part2Solver(IEnumerable<long> allNumbers, in long target)
        {
            // reverse as likely it's quicker
            for (int i = allNumbers.Count() - 1; i >= 0; i--)
            {
                for (int window = 2; window < allNumbers.Count(); window++)
                {
                    var tempList = allNumbers.Skip(i).Take(window);
                    if (tempList.Aggregate((a, next) => a + next) == target)
                    {

                        Helpers.WriteToConsole(tempList);
                        return tempList;
                    }
                }
            }

            return null;
        }

    }
}
