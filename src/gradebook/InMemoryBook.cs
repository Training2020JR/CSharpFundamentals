using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace gradebook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistic GetStatistics();
        String Name { get; set; }
    }

    public abstract class Book : NamedObject, IBook
    {
        public abstract void AddGrade(double grade);

        public virtual Statistic GetStatistics()
        {
            throw new NotImplementedException();
        }

        public Book(string name): base(name)
        {

        }


    }

    public class InMemoryBook :Book, IBook
    {
        private List<double> grades;
        private string name;
        readonly string category;
        

        public InMemoryBook(string name) : base(name)
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

            switch (stat.Average)
            {
                case var d when d >= 90:
                    stat.letter = 'A';
                    break;
                case var d when d >= 80:
                    stat.letter = 'B';
                    break;
                case var d when d >= 70:
                    stat.letter = 'C';
                    break;
                case var d when d >= 60:
                    stat.letter = 'D';
                    break;
                default:
                    stat.letter = 'F';
                    break;

            }


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
        
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"The grade {grade} is invalid");
            }
        }
    }
}
