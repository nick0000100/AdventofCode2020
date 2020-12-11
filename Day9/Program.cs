using System;
using System.Collections.Generic;
using System.Linq;

namespace day9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> Input = ReadInput();
            System.Console.WriteLine(FirstIncorrect(ReadInput(), 25));
            System.Console.WriteLine(FindSum(Input, FirstIncorrect(Input, 25)));

        }

        public static List<long> ReadInput()
        {
            string line;  
            List<long> Input = new List<long>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"./Input.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                Input.Add(long.Parse(line));
            }
            file.Close();
            return Input;
        }
        public static long FirstIncorrect(List<long> Input, int CountOfNumbersToCheck)
        {
            int CurrentPosition = CountOfNumbersToCheck;
            long CurrentNumber = Input[CurrentPosition];
            var CurrentList = Input.Skip(CountOfNumbersToCheck - CurrentPosition).Take(CountOfNumbersToCheck).OrderBy(x => x).ToList();
            while(IncorrectChecker(CurrentList, CurrentNumber))
            {
                IncorrectChecker(CurrentList, CurrentNumber);
                CurrentPosition++;
                CurrentNumber = Input[CurrentPosition];
                CurrentList = Input.Skip(CurrentPosition - CountOfNumbersToCheck).Take(CountOfNumbersToCheck).OrderBy(x => x).ToList();
            }
            CurrentNumber = Input[CurrentPosition];
            return CurrentNumber;
        }

        public static long FindSum(List<long> Input, long IncorrectNumber)
        {
            int LowerBound = 0;
            int UpperBound = 1;
            List<long> Range = new List<long>()
            {
                Input[LowerBound],
                Input[UpperBound]
            };
            long Sum = Range.Sum();
            while(Sum != IncorrectNumber)
            {
                if(Sum > IncorrectNumber)
                {
                    LowerBound++;
                }
                else
                {
                    UpperBound++;
                }
                Range = Input.GetRange(LowerBound, UpperBound - LowerBound);
            }
            return Range.Min() + Range.Max();
        }

        private static bool IncorrectChecker(List<long> CurrentList, long CurrentNumber)
        {
            foreach(int ListNumber in CurrentList)
            {
                long Difference = CurrentNumber - ListNumber;
                if(CurrentList.Exists(x => x == Difference))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
