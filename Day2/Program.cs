using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(GetValidPasswords(FormatLines(ReadPasswords())));
            System.Console.WriteLine(GetValidPasswordsTwo(FormatLines(ReadPasswords())));
        }

        public static List<string> ReadPasswords()
        {
            string line;  
            List<string> Passwords = new List<string>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\v-nisor\Desktop\AdventCalendar\Day2\Passwords.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                Passwords.Add(line);
            }
            file.Close();
            return Passwords;
        }

        public static List<Line> FormatLines(List<string> Passwords)
        {
            List<Line> Lines = new List<Line>();
            foreach(string Password in Passwords)
            {
                String[] Split = Password.Split(" ");
                String[] Allowed = Split[0].Split("-");
                Lines.Add(new Line(Int32.Parse(Allowed[0]), Int32.Parse(Allowed[1]), Split[1][0], Split[2])); 
            }
            return Lines;
        }

        public static int GetValidPasswords(List<Line> Passwords)
        {
            int Valid = 0;
            foreach(Line Password in Passwords)
            {
                if(Password.Min > Password.Pass.Length)
                {
                    continue;
                }
                int count = 0;
                for(int i = 0; i < Password.Pass.Length; i++)
                {
                    if(Password.Pass[i] == Password.Letter)
                    {
                        count++;
                    }
                }
                if(count <= Password.Max && count >= Password.Min)
                {
                    Valid++;
                }
            }
            return Valid;
        }

        public static int GetValidPasswordsTwo(List<Line> Passwords)
        {
            int Valid = 0;
            foreach(Line Password in Passwords)
            {
                if(Password.Max > Password.Pass.Length)
                {
                    continue;
                }
                if((Password.Pass[Password.Min - 1] == Password.Letter && Password.Pass[Password.Max -1] != Password.Letter) || (Password.Pass[Password.Min - 1] != Password.Letter && Password.Pass[Password.Max - 1] == Password.Letter))
                {
                    Valid++;
                }
            }
            return Valid;
        }
    }
}
