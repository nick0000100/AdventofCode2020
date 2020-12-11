using System;
using System.Collections.Generic;

namespace day10
{
    class Program
    {
        static Dictionary<int, long> Permutations = new Dictionary<int, long>();
        static void Main(string[] args)
        {
            Dictionary<string, int> VoltageDifferences = CountOfAdapters(ReadInput());
            System.Console.WriteLine(VoltageDifferences["One"] * VoltageDifferences["Three"]);
            System.Console.WriteLine(GetPermutations(ReadInput(), 0));
        }

        public static List<int> ReadInput()
        {
            string Line;  
            List<int> Input = new List<int>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"./Input.txt");  
            while((Line = file.ReadLine()) != null)  
            {  
                Input.Add(Int32.Parse(Line));
            }
            file.Close();
            Input.Sort();
            Input.Insert(0, 0);
            return Input;
        }

        public static Dictionary<string, int> CountOfAdapters(List<int> Input)
        {
            Input.Add(Input[Input.Count - 1] + 3);
            Dictionary<string, int> Adapters = new Dictionary<string, int>()
            {
                {"One", 0},
                {"Two", 0},
                {"Three", 0}
            };
            for(int i = 0; i < Input.Count - 1; i++)
            {
                int Difference = Input[i + 1] - Input[i];
                if(Difference == 1)
                {
                    Adapters["One"]++;
                }
                else if(Difference == 2)
                {
                    Adapters["Two"]++;
                }
                else if(Difference == 3)
                {
                    Adapters["Three"]++;
                }
            }
            return Adapters;
        }

        public static long GetPermutations(List<int> Input, int Position)
        {
            // Checking if the current number has been checked already
            if(Permutations.ContainsKey(Position))
            {
                return Permutations[Position];
            }
            long Total = 0;
            int NextPostition = Position + 1;
            if(Position == Input.Count - 1)
            {
                return 1;
            }
            while((NextPostition < Input.Count) && (Input[NextPostition] - Input[Position] <= 3))
            {
                Total += GetPermutations(Input, NextPostition);
                NextPostition += 1;
            }
            // Adds current number to cache
            Permutations[Position] = Total;
            return Permutations[Position];
        }
    }
}
