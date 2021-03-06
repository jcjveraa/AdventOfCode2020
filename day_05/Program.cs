﻿using System;
using _00_common;
using System.Collections.Generic;

namespace day_05
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoaders fileLoaders = new FileLoaders(args);
            List<string> input = fileLoaders.LoadStrings();

            uint maxId = 0;
            List<uint> ids = new List<uint>();

            foreach (string line in input)
            {
                uint row = 0, col = 0;
                int counter = 0;
                foreach (char c in line)
                {
                    if (counter <= 6)
                    {
                        if (c == 'F')
                        {
                            row = row ^ 0;
                        }
                        if (c == 'B')
                        {
                            row = row ^ 1;
                        }

                        if (counter < 6)
                        {
                            row = row << 1;
                        }
                    }
                    else
                    {
                        if (c == 'L')
                        {
                            col = col ^ 0;
                        }
                        if (c == 'R')
                        {
                            col = col ^ 1;
                        }

                        if (counter < 9)
                        {
                            col = col << 1;
                        }
                    }
                    counter++;
                }

                uint id = row * 8 + col;
                ids.Add(id);
                if (id > maxId)
                {
                    maxId = id;
                }
                Console.WriteLine("Row is {0}, column = {1}, ID = {2}", row, col, id);
            }

            ids.Sort();
            uint star2 = 0;
            for (int i = 0; i < ids.Count; i++)
            {
                if (ids[i + 1] != ids[i] + 1)
                {
                    star2 = ids[i] + 1;
                    break;
                }
            }
            Console.WriteLine("Part 1 answer is {0}", maxId);
            Console.WriteLine("Part 2 answer is {0}", star2);
        }
    }
}
