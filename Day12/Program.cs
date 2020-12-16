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
            System.Console.WriteLine(GetManhattan2(SeperatedInput));
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
                    //East
                    if(Cardinal == 0)
                    {
                        Location = (Location.Item1, Location.Item2 + Amount);
                    }
                    //South
                    else if(Cardinal == 90 || Cardinal == -270)
                    {
                        Location = (Location.Item1 - Amount, Location.Item2);
                    }
                    //West
                    else if(Cardinal == 180 || Cardinal == -180)
                    {
                        Location = (Location.Item1, Location.Item2 - Amount);
                    }
                    //North
                    else if(Cardinal == 270 || Cardinal == -90)
                    {
                        Location = (Location.Item1 + Amount, Location.Item2);
                    }
                }
            }
            return Math.Abs(Location.Item1) + Math.Abs(Location.Item2);
        }

        public static int GetManhattan2(List<(string, int)> Input)
        {
            var Waypoint = (1,10);
            var Location = (0,0);
            foreach(var Direction in Input)
            {
                string Way = Direction.Item1;
                int Amount = Direction.Item2;
                if(Way == "N")
                {
                    Waypoint = (Waypoint.Item1 + Amount, Waypoint.Item2);
                }
                else if(Way == "S")
                {
                    Waypoint = (Waypoint.Item1 - Amount, Waypoint.Item2);
                }
                else if(Way == "E")
                {
                    Waypoint = (Waypoint.Item1, Waypoint.Item2 + Amount);
                }
                else if(Way == "W")
                {
                    Waypoint = (Waypoint.Item1, Waypoint.Item2 - Amount);
                }
                else if(Way == "L")
                {
                    Waypoint = RotatePoint(Waypoint, Amount);
                }
                else if(Way == "R")
                {
                    Waypoint = RotatePoint(Waypoint, -Amount);
                }
                else if(Way == "F")
                {
                    Location.Item1 += Waypoint.Item1 * Amount;
                    Location.Item2 += Waypoint.Item2 * Amount;
                }
            }
            return Math.Abs(Location.Item1) + Math.Abs(Location.Item2);
        }

        private static (int, int) RotatePoint((int, int) Waypoint,int Angle)
        {
            int Y = Waypoint.Item1;
            int X = Waypoint.Item2;
            var RadianAngle = (Math.PI / 180) * Angle;
            var NewX = Convert.ToInt32((X * Math.Cos(RadianAngle)) - (Y * Math.Sin(RadianAngle)));
            var NewY = Convert.ToInt32((Y * Math.Cos(RadianAngle)) + (X * Math.Sin(RadianAngle)));
            return (NewY, NewX);
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
