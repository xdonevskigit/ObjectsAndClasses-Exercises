using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AvarageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Students> students = new List<Students>();

            for (int i = 0; i < n; i++)
            {
                Students student = new Students();
                string[] inputArguments = Console.ReadLine().Split();

                student.Name = inputArguments[0];
                student.Grades = inputArguments.Skip(1).Select(double.Parse).ToList();
                students.Add(student);
            }
            students.Where(s => s.Average >= 5.00)
                .OrderBy(s => s.Name)
                .ThenByDescending(s => s.Average)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.Name} -> {s.Average:F2}"));
            
        }
    }
    public class Students
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double Average => Grades.Average();
    }
}
