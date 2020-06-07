using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace gradebook
{
    public class Book
    {
        private List<double> grades;
        public string Name;
        
        public Book(string name)
        {
            this.grades = new List<double>();
            this.Name = name;
        }

        public Statistic GetStatistics()
        {
            var lowestGrade = double.MaxValue;
            var highestGrade = double.MinValue;

            double gradetmp = 0;
            foreach (double grade in this.grades)
            {
                lowestGrade = Math.Min(lowestGrade, grade);
                highestGrade = Math.Max(highestGrade, grade);
                gradetmp += grade;
            }

            Statistic stat = new Statistic();
            stat.Average = gradetmp / (this.grades.Count);
            stat.Highest = highestGrade;
            stat.Lowest = lowestGrade;

            return stat;
        }

        public void ShowStatistics()
        {
            var lowestGrade = double.MaxValue;
            var highestGrade = double.MinValue;

            double gradetmp = 0;
            foreach(double grade in this.grades)
            {
                lowestGrade = Math.Min(lowestGrade, grade);
                highestGrade = Math.Max(highestGrade, grade);
                gradetmp += grade;
            }


            Console.WriteLine($"Minimum Grade: {lowestGrade:N1}");
            Console.WriteLine($"Maximum Grade: {highestGrade:N1}");
            Console.WriteLine($"Average Grade: {gradetmp/(this.grades.Count):N1}");

            

        }
        
        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }
    }
}
