using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        private const int V = 3;
        static void Main(string[] args)
        {
            IBook book = new InDiskBook("Manuel book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatisticts();
            Console.WriteLine($"The average grade is {stats.Average:N5}");
            Console.WriteLine($"The maximun grade is {stats.High:N2}");
            Console.WriteLine($"The minimun grade is {stats.Low:N2}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            do
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "Q" || input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {

                }
            } while (true);
        }

        static void OnGradeAdded(object sender, EventArgs e) 
        {
            Console.WriteLine("A grade object was added");
        }
    }

}
