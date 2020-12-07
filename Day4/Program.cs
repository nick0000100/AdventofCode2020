using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(SplitPassport(ReadInput()));
            // System.Console.WriteLine(PassportCheck(ReadInput()));
        }

        public static List<string> ReadInput()
        {
            List<string> Passports = new List<string>();
            
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
                    Passports.Add(TempLine);
                    TempLine = "";
                }
            }
            file.Close();
            return Passports;
        }

        public static int PassportCheck(List<string> Passports)
        {
            int count = 0;
            foreach(string Passport in Passports)
            {
                if(ValidChecker(Passport))
                {
                    count++;
                }
            }
            return count;
        }

        public static int PassportCheck2(List<string> Passports)
        {

            return 0;
        }

        private static bool ValidChecker(string Passports)
        {
            List<string> RequiredList = new List<string>() {"byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:"};
            foreach(string Required in RequiredList)
            {
                if(!Passports.Contains(Required))
                {
                    return false;
                }
            }
            return true;
        }

        private static int SplitPassport(List<string> Passports)
        {
            Dictionary<string, string> PassDict = new Dictionary<string, string>();
            int count = 0;
            string[] SplitPass;
            string[] SplitPass2;
            string[] EyeColors = {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
            foreach(string s in Passports)
            {
                if(ValidChecker(s))
                {
                    SplitPass = s.Split(" ");
                    foreach(string f in SplitPass)
                    {
                        SplitPass2 = f.Split(":");
                        if(!PassDict.ContainsKey(SplitPass2[0]))
                        {
                            PassDict.Add(SplitPass2[0],SplitPass2[1]);
                        }
                        else
                        {
                            PassDict[SplitPass2[0]] = SplitPass2[1];
                        }
                    }
                    Regex Hair = new Regex("#[0-9a-f]{6}");
                    Regex PID = new Regex("[0-9]{9}");
                    if(
                    (Int32.Parse(PassDict["byr"]) >= 1920 && Int32.Parse(PassDict["byr"]) <= 2002) && (PassDict["byr"].Length == 4) &&
                    (Int32.Parse(PassDict["iyr"]) >= 2010 && Int32.Parse(PassDict["iyr"]) <= 2020) && (PassDict["iyr"].Length == 4) &&
                    (Int32.Parse(PassDict["eyr"]) >= 2020 && Int32.Parse(PassDict["eyr"]) <= 2030 && (PassDict["eyr"].Length == 4)) && 
                    (EyeColors.Contains(PassDict["ecl"])) &&
                    (Hair.IsMatch(PassDict["hcl"])) &&
                    (PID.IsMatch(PassDict["pid"])) &&
                    (HeightCheck(PassDict))
                    )
                    {
                        count++;
                    }
                }

            }
            return count;
        }

        private static bool HeightCheck(Dictionary<string, string> Passport)
        {
            string Height = Passport["hgt"];
            int HeightNum = Int32.Parse(Height.Substring(0, Height.Length - 2));
            if((Height.Contains("cm") && HeightNum >= 150 && HeightNum <= 193) || (Height.Contains("in") && HeightNum >= 59 && HeightNum <= 76))
            {
                return true;
            }

            return false;
        }
    }
}
