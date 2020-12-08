using System;
using System.Collections.Generic;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput();
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
                System.Console.WriteLine(line);

            }
            file.Close();
            return Input;
        }
    }
}