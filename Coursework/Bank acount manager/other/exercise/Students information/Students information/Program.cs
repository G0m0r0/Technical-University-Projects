using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_information
{
    class Program
    {
        struct student
        {
            string name;
            string number;
            int numOfGrades;
            string grades;
            public void InputStudentInformation(student other)
            {
                Console.Write("Enter name: ");
                other.name = Console.ReadLine();
                Console.Write("Enter Student number: ");
                other.number = Console.ReadLine();
                Console.Write("Enter number of student grades: ");
                other.numOfGrades = int.Parse(Console.ReadLine());
                Console.Write("Enter the grades: ");
                other.grades = Console.ReadLine();
            }
            public void OutputStudentInformation(student pointer)
            {
                Console.WriteLine($"Name: {pointer.name}");
                Console.WriteLine($"Student number: {pointer.number}");
                Console.WriteLine("Grades: {0}",pointer.grades);
            }
        }
        
        static void Main(string[] args)
        {
            student a = new student();
            a.InputStudentInformation(a);
            a.OutputStudentInformation(a);

        }
    }
}
