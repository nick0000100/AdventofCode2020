using System;
using System.Collections.Generic;
using System.Linq;

namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(SumCounts(ReadInput()));
            System.Console.WriteLine(SumCounts2(ReadInput()));
        }

        public static List<string> ReadInput()
        {
            List<string> Input = new List<string>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"./Input.txt");
            string TempLine = "";
            string Line = "";
            while(Line != null)  
            {
                Line = file.ReadLine();
                if(Line != "" && Line != null)
                {
                    if(TempLine != "")
                    {
                        TempLine += $" {Line}";
                    }
                    else
                    {
                        TempLine += Line;
                    }
                }
                else
                {
                    Input.Add(TempLine);
                    TempLine = "";
                }
            }
            file.Close();
            return Input;
        }

        public static int SumCounts(List<string> Input)
        {
            List<string[]> GroupAnswers = GroupAnswerHelper(Input);
            HashSet<char> GroupTotal = new HashSet<char>();
            int total = 0;
            foreach(string[] Answers in GroupAnswers)
            {
                foreach(string Answer in Answers)
                {
                    foreach(char Letter in Answer)
                    {
                        GroupTotal.Add(Letter);
                    }
                }
                total += GroupTotal.Count;
                GroupTotal.Clear();
            }
            return total;
        }

        public static int SumCounts2(List<string> Input)
        {
            int total = 0;
            foreach (string GroupAnswers in Input) 
            {
                List<char> CommonAnswers = new List<char>();
                // Splits each person's response into an arrays characters
                var Temp = GroupAnswers.Split(" ").Select(x => x.Distinct().ToList()).Where(x=>x.Count>0).ToList();
                for (int i = 0; i < Temp.Count; i++) 
                {
                    var CurrentAnswer = Temp[i];
                    if (i == 0)
                    {
                        CommonAnswers.AddRange(CurrentAnswer);
                    }
                    // Updates CommonAnswers to only repeated characters
                    else 
                    {
                        CommonAnswers = new List<char>(CommonAnswers.Intersect(CurrentAnswer).ToList());
                    }
                }

                total += CommonAnswers.Count;
            }

            return total;
        }

        private static List<string[]> GroupAnswerHelper(List<string> Input)
        {
            List<string[]> GroupAnswers = new List<string[]>();
            foreach(string Line in Input)
            {
                GroupAnswers.Add(Line.Split(" "));
            }
            foreach(string[] Group in GroupAnswers)
            {
                Array.Sort(Group);
            }
            return GroupAnswers;
        }
    }
}
