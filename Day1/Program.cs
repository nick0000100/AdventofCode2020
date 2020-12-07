using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(ExpenseReportFixer(ReadReport()));          
            System.Console.WriteLine(ExpenseReportFixerTwo(ReadReport()));          
        }

        public static List<int> ReadReport()
        {
            string line;  
            List<int> ExpenseReport = new List<int>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\v-nisor\Desktop\AdventCalendar\Day1\Report.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                ExpenseReport.Add(Int32.Parse(line));
            }
            file.Close();
            ExpenseReport.Sort();
            return ExpenseReport;
        }
        public static int ExpenseReportFixer(List<int> ExpenseReport)
        {
            for(int i = 0; i < ExpenseReport.Count; i++)
            {
                int Compare = ExpenseReport[i];
                for(int k = ExpenseReport.Count - 1; k > 0; k--)
                {
                    int CompareTo = ExpenseReport[k];
                    if(Compare + CompareTo == 2020)
                    {
                        return Compare * CompareTo;
                    }
                }
            }
            return 0;
        }
        public static int ExpenseReportFixerTwo(List<int> ExpenseReport)
        {
            for(int i = 0; i < ExpenseReport.Count; i++)
            {
                int Compare = ExpenseReport[i];
                for(int k = i + 1; k < ExpenseReport.Count; k++)
                {
                    int CompareTo = ExpenseReport[k];
                    if(Compare + CompareTo < 2020)
                    {
                        for(int j = k + 1; j < ExpenseReport.Count; j++)
                        {
                            int CompareToo = ExpenseReport[j];
                            if(Compare + CompareTo + CompareToo == 2020)
                            {
                                return Compare * CompareTo * CompareToo;
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}
