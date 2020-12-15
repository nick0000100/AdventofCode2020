using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace day12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Input = ReadInput();
            List<(string, int)> SeperatedInput = SeperateInput(Input);
            System.Console.WriteLine(GetManhattan(SeperatedInput));
        }

        public static List<string> ReadInput()
        {
            string Line;  
            List<string> Input = new List<string>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"./Input.txt");
            while((Line = file.ReadLine()) != null)  
            {
                Input.Add(Line);
            }
            return Input;
        }

        public static int GetManhattan(List<(string, int)> Input)
        {
            int Degrees = 0;
            var Location = (0,0);
            foreach(var Direction in Input)
            {
                string Way = Direction.Item1;
                int Amount = Direction.Item2;
                if(Way == "N")
                {
                    Location = (Location.Item1 + Amount, Location.Item2);
                }
                else if(Way == "S")
                {
                    Location = (Location.Item1 - Amount, Location.Item2);
                }
                else if(Way == "E")
                {
                    Location = (Location.Item1, Location.Item2 + Amount);
                }
                else if(Way == "W")
                {
                    Location = (Location.Item1, Location.Item2 - Amount);
                }
                else if(Way == "L")
                {
                    Degrees -= Amount;
                }
                else if(Way == "R")
                {
                    Degrees += Amount;
                }
                else if(Way == "F")
                {
                    int Cardinal = Degrees % 360;
                    if(Cardinal == 0)
                    {
                        //East
                        Location = (Location.Item1, Location.Item2 + Amount);
                    }
                    else if(Cardinal == 90 || Cardinal == -90)
                    {
                        //South
                        Location = (Location.Item1 - Amount, Location.Item2);
                    }
                    else if(Cardinal == 180 || Cardinal == -180)
                    {
                        //West
                        Location = (Location.Item1, Location.Item2 - Amount);
                    }
                    else if(Cardinal == 270 || Cardinal == -270)
                    {
                        //North
                        Location = (Location.Item1 + Amount, Location.Item2);
                    }
                }
            }
            return Math.Abs(Location.Item1) + Math.Abs(Location.Item2);
        }

        public static List<(string, int)> SeperateInput(List<string> Input)
        {
            List<(string, int)> SeperatedInput = new List<(string, int)>();
            Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
            foreach(string Direction in Input)
            {
                Match Split = re.Match(Direction);
                SeperatedInput.Add((Split.Groups[1].Value, Int32.Parse(Split.Groups[2].Value)));
            }
            return SeperatedInput;
        }
    }
}
