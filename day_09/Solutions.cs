using System;
using System.Collections.Generic;
using System.Linq;

namespace day_09
{
    class Solutions
    {
        public Solutions(List<string> input)
        {
            var preambleLength = 25;

            var numberQueue = new Queue<int>(preambleLength);

            for (int i = 0; i < preambleLength; i++)
            {
                numberQueue.Enqueue(Int32.Parse(input[i]));
            }

            foreach (var item in numberQueue)
            {
                Console.Write("{0}\t", item);
            }
            Console.WriteLine();

            int part1Answer = -1;

            for (int i = preambleLength; i < input.Count; i++)
            {
                IEnumerable<int> allowableValues = GenerateAllowable(numberQueue);
                var thisValue = Int32.Parse(input[i]);
                if (allowableValues.Contains(thisValue))
                {
                    numberQueue.Dequeue();
                    numberQueue.Enqueue(thisValue);
                    // foreach (var item in numberQueue)
                    // {
                    //     Console.Write("{0}\t", item);
                    // }
                    // Console.WriteLine();
                }
                else
                {
                    part1Answer = thisValue;
                    break;
                }
            }

            Console.WriteLine("Part 1 answer is {0}", part1Answer);
        }

        private IEnumerable<int> GenerateAllowable(Queue<int> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {
                    yield return items.ElementAt(i) + items.ElementAt(j);
                }
            }

        }


    }
}
