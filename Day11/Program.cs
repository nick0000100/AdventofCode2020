using System;
using System.Collections.Generic;
using System.Linq;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<char>> Input = ReadInput();
            
            List<List<char>> NextLayout = NextRound(Input).Item1;
            while(!NextRound(NextLayout).Item2)
            {
                NextLayout = NextRound(NextLayout).Item1;
            }
            System.Console.WriteLine(NextLayout.SelectMany(InnerList => InnerList).Where(x => x == '#').Count());
        }

        public static List<List<char>> ReadInput()
        {
            string Line;  
            List<List<char>> Input = new List<List<char>>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"./Input.txt");
            while((Line = file.ReadLine()) != null)  
            {
                List<char> TempList = new List<char>();
                TempList.Add('.');
                TempList.AddRange(Line);
                TempList.Add('.');
                Input.Add(TempList);
            }
            Input.Insert(0,Enumerable.Repeat('.', Input[0].Count).ToList());
            Input.Add(Enumerable.Repeat('.', Input[0].Count).ToList());


            return Input;
        }

        public static Tuple<List<List<char>>, bool> NextRound(List<List<char>> Input)
        {
            bool Stable = true;
            List<List<char>> NewLayout = new List<List<char>>();
            foreach(List<char> c in Input)
            {
                List<char> TempList = new List<char>();
                foreach(char s in c)
                {
                    TempList.Add(s);
                }
                NewLayout.Add(TempList);
            }
            for(int i = 1; i < Input.Count - 1; i++)
            {
                for(int j = 1; j < Input[0].Count - 1; j++)
                {
                    char Current = Input[i][j];
                    List<char> Neighbors = new List<char>();
                    Neighbors.Add(Input[i - 1][j]);
                    Neighbors.Add(Input[i + 1][j]);
                    Neighbors.Add(Input[i][j - 1]);
                    Neighbors.Add(Input[i][j + 1]);
                    Neighbors.Add(Input[i - 1][j + 1]);
                    Neighbors.Add(Input[i - 1][j - 1]);
                    Neighbors.Add(Input[i + 1][j + 1]);
                    Neighbors.Add(Input[i + 1][j - 1]);

                    int Occupied = Neighbors.Where(x => x == '#').Count();
                    if(Current == 'L' && Occupied == 0)
                    {
                        NewLayout[i][j] = '#';
                        Stable = false;
                    }
                    else if(Current == '#' && Occupied >= 4)
                    {
                        NewLayout[i][j] = 'L';
                        Stable = false;
                    }
                }
            }
            return Tuple.Create(NewLayout, Stable);
        }
    }
}
