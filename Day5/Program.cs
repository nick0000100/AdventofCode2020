using System;
using System.Collections.Generic;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(Highest(ReadInput(), 128, 8));
        }

        public static int? Highest(List<string> Input, int PossibleRow, int PossibleCol)
        {
            int UpperRow = PossibleRow;
            int LowerRow = 0;
            int UpperCol = PossibleCol;
            int LowerCol = 0;
            int Max = 0;
            int Seat;
            List<int> SeatNumbers = new List<int>();
            foreach(string Line in Input)
            {
                UpperRow = PossibleRow;
                UpperCol = PossibleCol;
                LowerCol = 0;
                LowerRow = 0;
                for(int i = 0; i < Line.Length; i++)
                {
                    int RowMid = (UpperRow + LowerRow) / 2;
                    int ColMid = (UpperCol + LowerCol) / 2;
                    if(Line[i] == 'F')
                    {
                        UpperRow = RowMid;
                    }else if(Line[i] == 'B')
                    {
                        LowerRow = RowMid;
                    }else if(Line[i] == 'L')
                    {
                        UpperCol = ColMid;
                    }else if(Line[i] == 'R')
                    {
                        LowerCol = ColMid;
                    }
                }
                Seat = (8 * LowerRow) + LowerCol;
                SeatNumbers.Add(Seat);
                if(Max < Seat)
                {
                    Max = Seat;
                }
            }
            SeatNumbers.Sort();
            for(int i = 1; i < SeatNumbers.Count - 1; i++)
            {
                int current = SeatNumbers[i];
                int next = SeatNumbers[i+1];
                if(current + 1 != next)
                {
                    System.Console.WriteLine(current + 1); // Part 2
                }
            }
            return Max;
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
    }
}
