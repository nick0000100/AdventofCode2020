using System;
using System.Collections.Generic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = FindTrees(ReadPasswords(), 1, 1);
            int two = FindTrees(ReadPasswords(), 3, 1);
            int three = FindTrees(ReadPasswords(), 5, 1);
            int four = FindTrees(ReadPasswords(), 7, 1);
            int five = FindTrees(ReadPasswords(), 1, 2);
            System.Console.WriteLine(one*two*three*four*five);
            System.Console.WriteLine(one);
            System.Console.WriteLine(two);
            System.Console.WriteLine(three);
            System.Console.WriteLine(four);
            System.Console.WriteLine(five);
        }

        public static List<string> ReadPasswords()
        {
            string line;  
            List<string> Passwords = new List<string>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"./Map.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                Passwords.Add(line);

            }
            file.Close();
            return Passwords;
        }

        public static int FindTrees(List<String> Map, int Transition, int down)
        {
            int Trees = 0;
            for(int i = 0; i < Map.Count; i+=down)
            {
                if(Map[i][i * Transition % Map[i].Length] == '#')
                {
                    Trees++;
                }
            }
            return Trees;
        }
    }
}
