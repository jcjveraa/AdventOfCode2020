using System;
using System.Collections.Generic;
using System.Linq;

namespace day_07
{
    class Solutions
    {
        public Solutions(List<string> input)
        {
            List<Bag> bags = new List<Bag>();
            List<Bag> NewShinyGoldBagContainers = new List<Bag>();
            List<Bag> ProcessedShinyGoldBagContainers = new List<Bag>();

            foreach (string line in input)
            {
                var words = line.Split(' ');
                var bagname = words[0] + " " + words[1];
                var bag = FindOrAddNewBag(bags, bagname);

                // check if it contains 'no' other bags
                if (line.IndexOf(" no ") > 0)
                {
                    continue;
                }

                var numberOfContainedBags = (words.Length / 4) - 1;
                // Console.WriteLine("{0}", numberOfContainedBags);

                for (int i = 0; i < numberOfContainedBags; i++)
                {
                    var numBags = Int32.Parse(words[4 * i + 4]);
                    var containedBagName = words[4 * i + 5] + " " + words[4 * i + 6];
                    var containedBag = FindOrAddNewBag(bags, containedBagName);
                    bag.ShouldContain.Add(new KeyValuePair<Bag, int>(containedBag, numBags));

                    if (containedBag.BagName == "shiny gold")
                    {
                        NewShinyGoldBagContainers.Add(bag);
                    }
                }

                // bag.writeToConsole();
            }

            while (NewShinyGoldBagContainers.Count > 0)
            {
                var bagToBeChecked = NewShinyGoldBagContainers[0];
                NewShinyGoldBagContainers.RemoveAt(0);
                var bagsThatCanHoldThisBag = bags.Where(b => b.ShouldContain.Any(a => a.Key == bagToBeChecked));
                foreach (var bag in bagsThatCanHoldThisBag)
                {
                    if (!ProcessedShinyGoldBagContainers.Contains(bag) && !NewShinyGoldBagContainers.Contains(bag))
                        NewShinyGoldBagContainers.Add(bag);
                }

                Console.WriteLine("Checking " + bagToBeChecked.BagName);
                foreach (var item in bagsThatCanHoldThisBag)
                {
                    Console.Write(item.BagName + ", ");
                }
                Console.WriteLine("\n");

                ProcessedShinyGoldBagContainers.Add(bagToBeChecked);
            }



            Console.WriteLine("Part 1 answer {0}", ProcessedShinyGoldBagContainers.Count);

        }

        private Bag FindOrAddNewBag(List<Bag> bags, string bagName)
        {
            var bag = bags.Find(b => b.BagName == bagName);

            if (bag != null)
            {
                return bag;
            }
            else
            {
                var newBag = new Bag(bagName);
                bags.Add(newBag);
                return newBag;
            }
        }
    }


    class Bag
    {
        public string BagName { get; set; }

        public Bag(string bagName)
        {
            BagName = bagName;
            ShouldContain = new List<KeyValuePair<Bag, int>>();
        }

        public List<KeyValuePair<Bag, int>> ShouldContain { get; set; }

        public void writeToConsole()
        {
            // vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
            Console.Write(BagName + " bags contain ");
            if (ShouldContain.Count == 0)
            {
                Console.WriteLine("no other bags.");
            }
            else
            {
                foreach (var item in ShouldContain)
                {
                    Console.Write(item.Value + " " + item.Key.BagName + " bags, ");
                }
                Console.WriteLine(".");
            }
        }

    }
}
