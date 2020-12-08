using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Bag> BagsWithGold = new HashSet<Bag>();
            List<Bag> AllBags = FillBags(ReadInput());
            foreach(Bag Bag in AllBags)
            {
                if(!BagsWithGold.Contains(Bag))
                {
                    CheckShinyGold(Bag, BagsWithGold);
                }
            }
            System.Console.WriteLine(BagsWithGold.Count);
            Bag Goldie = AllBags.Where(x => x.Color == "shiny gold").FirstOrDefault();
            System.Console.WriteLine(GetInnards(Goldie, 1));
        }
        public static List<string> ReadInput()
        {
            string line;  
            List<string> Input = new List<string>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"./Input.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                Input.Add(line);
            }
            file.Close();
            return Input;
        }

        // Checks if bags contain a "Shiny Gold" Bag.
        public static bool CheckShinyGold(Bag Bag, HashSet<Bag> BagsWithGold)
        {
            bool HasShinyGold = false;
            if(Bag.Color == "shiny gold")
            {
                return true;
            }
            if(Bag.InnerBags.Count == 0)
            {
                return false;
            }
            foreach(KeyValuePair<Bag, int> CurrentBag in Bag.InnerBags)
            {
                if(CheckShinyGold(CurrentBag.Key, BagsWithGold))
                {
                    BagsWithGold.Add(Bag);
                    HasShinyGold = true;
                }
            }
            return HasShinyGold;
        }

        //Gets the number of bags inside a specified colored bag
        public static int GetInnards(Bag Bag, int NumberOfBags)
        {
            int Innards = 0;
            if(Bag.InnerBags.Count == 0)
            {
                return 0;
            }
            foreach(KeyValuePair<Bag, int> CurrentBag in Bag.InnerBags)
            {
                Innards += GetInnards(CurrentBag.Key, CurrentBag.Value * NumberOfBags) + CurrentBag.Value * NumberOfBags;
            }
            return Innards;
        }

        //Gets all of the bags from input.
        public static List<Bag> FillBags(List<string> Input)
        {
            List<Bag> AllBags = new List<Bag>();
            foreach(string Line in Input)
            {
                string[] InnerBags = Line.Split(new string[] {" contain ", ", ", ".", " bags", " bag"}, StringSplitOptions.RemoveEmptyEntries);
                if(!AllBags.Contains(AllBags.Where(x => x.Color == InnerBags[0]).FirstOrDefault()))
                {
                    AllBags.Add(new Bag(InnerBags[0], InnerBags));
                }
            }
            foreach(Bag Bag in AllBags)
            {
                Bag.FillBag(AllBags);
            }
            return AllBags;
        }
    }
}