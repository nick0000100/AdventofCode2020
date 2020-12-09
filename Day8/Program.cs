using System;
using System.Collections.Generic;

namespace day8
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(GetAcc(ReadInput())["Acc"]);
            System.Console.WriteLine(FixCorruption(ReadInput()));
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

        public static Dictionary<string, int> GetAcc(List<string> Input)
        {
            var Info = new Dictionary<string, int>()
            {
                {"Acc", 0},
                {"Position", 0}
            };
            int Acc = 0;
            HashSet<int> SeenSteps = new HashSet<int>();
            for(int i = 0; i < Input.Count; i++)
            {
                string[] SplitStep = Input[i].Split(" ");
                string Step = SplitStep[0];
                int StepAmount = Int32.Parse(SplitStep[1]);
                if(SeenSteps.Contains(i))
                {
                    return Info;
                }
                SeenSteps.Add(i);
                if(Step == "acc")
                {
                    Info["Acc"] += StepAmount;
                    Acc += StepAmount;
                }
                else if(Step == "jmp")
                {
                    i += StepAmount - 1;
                }
                Info["Position"] = i;
            }
            return Info;
        }

        public static int FixCorruption(List<string> Input)
        {
            var Info = new Dictionary<string, int>()
            {
                {"Acc", 0},
                {"Position", 0}
            };
            for(int i = 0 ; i < Input.Count; i++)
            {
                List<string> ChangingInput = new List<string>(Input);
                string[] SplitStep = ChangingInput[i].Split(" ");
                string Step = SplitStep[0];
                if(Step == "jmp")
                {
                    ChangingInput[i] = ChangingInput[i].Replace("jmp", "nop");
                }
                else if(Step == "nop")
                {
                    ChangingInput[i] = ChangingInput[i].Replace("nop", "jmp");
                }
                Info = GetAcc(ChangingInput);
                if(Info["Position"] == Input.Count - 1)
                {
                    return Info["Acc"];
                }
            }
            return -1;
        }
    }
}
